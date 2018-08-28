using DG.Tweening;
using Services;
using Signals;
using UnityEngine.SceneManagement;
using Views.Ui;

namespace Mediators.UI
{
    public class MenuBtnMediator : TargetMediator<MenuBtnView>
    {
        /// <summary>
        /// Balls state service
        /// </summary>
        [Inject]
        public BallsStateService BallsStateService { get; set; }

        /// <summary>
        /// Pause game signal
        /// </summary>
        [Inject]
        public PauseGameSignal PauseGameSignal { get; set; }

        /// <summary>
        /// On register mediator
        /// </summary>
        public override void OnRegister()
        {
            View.OnCallMenu += () =>
            {
                PauseGameSignal.Dispatch();
                SceneManager.LoadScene("Menu", LoadSceneMode.Additive);
            };
        }
    }
}