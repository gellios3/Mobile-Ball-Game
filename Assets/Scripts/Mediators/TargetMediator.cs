using strange.extensions.mediation.impl;

namespace Mediators
{
    public class TargetMediator<T> : EventMediator
        where T : EventView
    {
        [Inject] public T View { protected get; set; }
    }
}