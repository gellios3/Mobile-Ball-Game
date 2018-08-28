using Contexts;
using strange.extensions.context.impl;

namespace Views.Root
{
    public class MenuRoot : ContextView
    {
        private void Awake()
        {
            context = new MenuContext(this);
        }
    }
}