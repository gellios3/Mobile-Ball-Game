using Commands;
using Mediators;
using Mediators.MainGame;
using Mediators.UI;
using strange.extensions.command.api;
using strange.extensions.command.impl;
using strange.extensions.context.api;
using strange.extensions.context.impl;
using Services;
using Signals;
using UnityEngine;
using Views;
using Views.MainGame;
using Views.Ui;

namespace Contexts
{
    public class MainGameContext : MVCSContext
    {
        public MainGameContext(MonoBehaviour view) : base(view)
        {
            _instance = this;
        }

        public MainGameContext(MonoBehaviour view, ContextStartupFlags flags) : base(view, flags)
        {
            _instance = this;
        }

        private static MainGameContext _instance;

        public static T Get<T>()
        {
            return _instance.injectionBinder.GetInstance<T>();
        }

        /// <inheritdoc />
        /// <summary>
        /// Unbind the default EventCommandBinder and rebind the SignalCommandBinder
        /// </summary>
        protected override void addCoreComponents()
        {
            base.addCoreComponents();
            injectionBinder.Unbind<ICommandBinder>();
            injectionBinder.Bind<ICommandBinder>().To<SignalCommandBinder>().ToSingleton();
        }

        /// <summary>
        /// Override Start so that we can fire the StartSignal 
        /// </summary>
        /// <returns></returns>
        public override IContext Start()
        {
            base.Start();
            var startSignal = injectionBinder.GetInstance<StartGameSignal>();
            startSignal.Dispatch();
            return this;
        }

        /// <inheritdoc />
        /// <summary>
        /// Override Bindings map
        /// </summary>
        protected override void mapBindings()
        {
            // init Signals
            injectionBinder.Bind<StartGameSignal>().ToSingleton();
            injectionBinder.Bind<PauseGameSignal>().ToSingleton();
            injectionBinder.Bind<SpawnBallsSignal>().ToSingleton();
            injectionBinder.Bind<PlayGameSignal>().ToSingleton().CrossContext();

            // Init commands
            commandBinder.Bind<OnHitBallSignal>().To<OnHitBallCommand>();
            commandBinder.Bind<OnMissBallSignal>().To<OnMissBallCommand>();

            // Init services
            injectionBinder.Bind<SpawnBallsService>().ToSingleton();
            injectionBinder.Bind<BallsStateService>().ToSingleton();

            // Init mediators
            mediationBinder.Bind<BallView>().To<BallMediator>();
            mediationBinder.Bind<BallSpawnerView>().To<BallSpawnerMediator>();
            mediationBinder.Bind<ScoreView>().To<ScoreMediator>();
            mediationBinder.Bind<MenuBtnView>().To<MenuBtnMediator>();
            mediationBinder.Bind<SettingsBtnView>().To<SettingsBtnMediator>();
        }
    }
}