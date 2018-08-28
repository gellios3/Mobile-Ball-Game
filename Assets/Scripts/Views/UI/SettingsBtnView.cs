using System;
using strange.extensions.mediation.impl;
using UnityEngine;
using UnityEngine.UI;

namespace Views.Ui
{
    public class SettingsBtnView : EventView
    {
        [SerializeField] private Button _btn;

        /// <summary>
        /// On add trate to card
        /// </summary>
        public event Action OnCallSettings;

        /// <inheritdoc />
        /// <summary>
        /// On start view
        /// </summary>
        protected override void Start()
        {
            _btn.onClick.AddListener(() =>
            {
                OnCallSettings?.Invoke();
            });
        }
    }
}