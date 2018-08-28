using Signals;
using UnityEngine;
using UnityEngine.SceneManagement;
using Views.Ui;

namespace Mediators.UI
{
    public class CloseBtnMediator : TargetMediator<CloseBtnView>
    {
        /// <summary>
        /// Pause game signal
        /// </summary>
        [Inject]
        public PlayGameSignal PlayGameSignal { get; set; }

        /// <summary>
        /// On register mediator
        /// </summary>
        public override void OnRegister()
        {
            View.OnCloseMenu += () =>
            {
                if (SceneManager.GetSceneByName("Menu").isLoaded)
                {
                    SceneManager.UnloadSceneAsync("Menu");
                }

                if (SceneManager.GetSceneByName("Settings").isLoaded)
                {
                    SceneManager.UnloadSceneAsync("Settings");
                }

                PlayGameSignal.Dispatch();
            };
        }
    }
}