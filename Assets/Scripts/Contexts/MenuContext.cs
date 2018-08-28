using Mediators.UI;
using strange.extensions.command.api;
using strange.extensions.command.impl;
using strange.extensions.context.api;
using strange.extensions.context.impl;
using UnityEngine;
using Views.Ui;

namespace Contexts
{
    public class MenuContext : MVCSContext
    {
         public MenuContext(MonoBehaviour view) : base(view)
        {
            _instance = this;
        }

        public MenuContext(MonoBehaviour view, ContextStartupFlags flags) : base(view, flags)
        {
            _instance = this;
        }

        private static MenuContext _instance;

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
            return this;
        }

        /// <inheritdoc />
        /// <summary>
        /// Override Bindings map
        /// </summary>
        protected override void mapBindings()
        {
            // init Signals


            // Init commands


            // Init services


            // Init mediators
            mediationBinder.Bind<CloseBtnView>().To<CloseBtnMediator>();
        }
    }
}