using DG.Tweening;
using Services;
using Signals;
using UnityEngine;
using UnityEngine.SceneManagement;
using Views.MainGame;

namespace Mediators.MainGame
{
    public class BallSpawnerMediator : TargetMediator<BallSpawnerView>
    {
        /// <summary>
        /// Start game signal
        /// </summary>
        [Inject]
        public StartGameSignal StartGameSignal { get; set; }

        /// <summary>
        /// Spawn balls signal
        /// </summary>
        [Inject]
        public SpawnBallsSignal SpawnBallsSignal { get; set; }

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
        /// Pause game signal
        /// </summary>
        [Inject]
        public PlayGameSignal PlayGameSignal { get; set; }

        /// <summary>
        /// On register mediator
        /// </summary>
        public override void OnRegister()
        {
            PlayGameSignal.AddListener(() =>
            {
                foreach (Transform item in View.transform)
                {
                    item.gameObject.SetActive(true);
                }

                BallsStateService.HasPaused = false;
                DOTween.TogglePauseAll();
            });

            PauseGameSignal.AddListener(() =>
            {
                BallsStateService.HasPaused = true;
                DOTween.TogglePauseAll();

                foreach (Transform item in View.transform)
                {
                    item.gameObject.SetActive(false);
                }

                
            });

            StartGameSignal.AddListener(() =>
            {
                BallsStateService.SpawnCount = View.SpawnCount;
                for (var i = 0; i < View.SpawnCount; i++)
                {
                    View.SpawnBall();
                }
            });

            SpawnBallsSignal.AddListener(() =>
            {
                BallsStateService.CurrentStageBallsCount = 0;
                for (var i = 0; i < View.SpawnCount; i++)
                {
                    View.SpawnBall();
                }
            });
        }
    }
}