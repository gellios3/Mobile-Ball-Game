using Signals;
using Views.MainGame;

namespace Mediators.MainGame
{
    public class BallMediator : TargetMediator<BallView>
    {
        /// <summary>
        /// On hit ball Signal
        /// </summary>
        [Inject]
        public OnHitBallSignal OnHitBallSignal { get; set; }
        
        /// <summary>
        /// On miss ball Signal
        /// </summary>
        [Inject]
        public OnMissBallSignal OnMissBallSignal { get; set; }

        /// <summary>
        /// On register mediator
        /// </summary>
        public override void OnRegister()
        {
            View.OnMissBall += () =>
            {
                OnMissBallSignal.Dispatch();
                Destroy(View.gameObject);
            };

            View.OnHitBall += () =>
            {
                
                OnHitBallSignal.Dispatch();
                Destroy(View.gameObject);
            };
        }
    }
}