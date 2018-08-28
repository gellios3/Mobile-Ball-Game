using strange.extensions.mediation.impl;
using Services;
using UnityEngine;

namespace Views.MainGame
{
    public class BallSpawnerView : EventView
    {
        [SerializeField] private int _spawnCount = 3;

        public int SpawnCount
        {
            get { return _spawnCount; }
            set { _spawnCount = value; }
        }

        [Inject] public SpawnBallsService SpawnBallsService { get; set; }


        /// <summary>
        /// Spawn ball
        /// </summary>
        public void SpawnBall()
        {
            // Load Card
            var ballGoGameObject = (GameObject) Instantiate(
                Resources.Load("Prefabs/Ball", typeof(GameObject)),
                Vector3.zero,
                Quaternion.identity,
                transform
            );

            var view = ballGoGameObject.GetComponent<BallView>();
            view.PlayAnimation(SpawnBallsService.GetSpawnPosition());
        }
    }
}