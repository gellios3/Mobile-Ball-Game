using DG.Tweening;
using Services;
using Signals;
using UnityEngine.SceneManagement;
using Views.Ui;

namespace Mediators.UI
{
    public class SettingsBtnMediator : TargetMediator<SettingsBtnView>
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
            View.OnCallSettings += () =>
            {
                PauseGameSignal.Dispatch();
                SceneManager.LoadScene("Settings", LoadSceneMode.Additive);
            };
        }
    }
}