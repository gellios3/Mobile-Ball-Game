using System;
using strange.extensions.mediation.impl;
using TMPro;
using UnityEngine;

namespace Views.Ui
{
    public class ScoreView : EventView
    {
        [SerializeField] private TextMeshProUGUI _score;

        protected override void Start()
        {
            _score.text = "1000";
        }

        public void IncreaseScore(int value)
        {
            var current = Convert.ToInt32(_score.text) + value;
            _score.text = current.ToString();
        }

        public void DecreaseScore(int value)
        {
            var current = Convert.ToInt32(_score.text) - value;
            _score.text = current.ToString();
        }
    }
}