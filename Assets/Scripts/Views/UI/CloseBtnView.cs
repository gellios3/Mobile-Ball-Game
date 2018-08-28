using System;
using strange.extensions.mediation.impl;

namespace Views.Ui
{
    public class CloseBtnView : EventView
    {
        
        /// <summary>
        /// On add trate to card
        /// </summary>
        public event Action OnCloseMenu;

        /// <summary>
        /// On close scene
        /// </summary>
        public void OnCloseScene()
        {
            OnCloseMenu?.Invoke();
        }
    }
}