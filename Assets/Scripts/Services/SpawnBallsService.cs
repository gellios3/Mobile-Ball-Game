using Signals;
using UnityEngine;

namespace Services
{
    public class SpawnBallsService
    {
        /// <summary>
        /// Balls state service
        /// </summary>
        [Inject]
        public BallsStateService BallsStateService { get; set; }

        /// <summary>
        /// Spawn balls signal
        /// </summary>
        [Inject]
        public SpawnBallsSignal SpawnBallsSignal { get; set; }

        /// <summary>
        /// Get spawn position
        /// </summary>
        /// <returns></returns>
        public Vector2 GetSpawnPosition()
        {
            var randomWight = Random.Range(100, Screen.width - 100);
            if (Camera.main == null)
            {
                return Vector2.zero;
            }

            return Camera.main.ScreenToWorldPoint(new Vector3(randomWight, -100, 0));
        }

        /// <summary>
        /// Check and call next stage
        /// </summary>
        public void CheckAndCallNextStage()
        {
            if (BallsStateService.CurrentStageBallsCount != BallsStateService.SpawnCount)
                return;
            BallsStateService.StageCount++;
            SpawnBallsSignal.Dispatch();
        }
    }
}