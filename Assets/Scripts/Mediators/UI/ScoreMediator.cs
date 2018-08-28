using Signals;
using Views.Ui;

namespace Mediators.UI
{
    public class ScoreMediator: TargetMediator<ScoreView>
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
            OnHitBallSignal.AddListener(() =>
            {
                View.IncreaseScore(50);
            });
            
            OnMissBallSignal.AddListener(() =>
            {
                View.DecreaseScore(100);
            });
        }
    }
}