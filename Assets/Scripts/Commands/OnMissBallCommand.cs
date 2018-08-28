using strange.extensions.command.impl;
using Services;

namespace Commands
{
    public class OnMissBallCommand : Command
    {
        
        /// <summary>
        /// Balls state service
        /// </summary>
        [Inject]
        public BallsStateService BallsStateService { get; set; }

        /// <summary>
        /// Spawn balls service
        /// </summary>
        [Inject]
        public SpawnBallsService SpawnBallsService { get; set; }
        
        /// <summary>
        /// Execute on hit ball
        /// </summary>
        public override void Execute()
        {
            BallsStateService.CurrentStageBallsCount++;
            BallsStateService.MissBallsCount++;

            SpawnBallsService.CheckAndCallNextStage();
        }
    }
}