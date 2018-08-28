using System;
using DG.Tweening;
using strange.extensions.mediation.impl;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Views.MainGame
{
    public class BallView : EventView
    {
        /// <summary>
        /// On add trate to card
        /// </summary>
        public event Action OnHitBall;
        
        /// <summary>
        /// On add trate to card
        /// </summary>
        public event Action OnMissBall;

        /// <summary>
        /// Play ball animation
        /// </summary>
        /// <param name="pos"></param>
        public void PlayAnimation(Vector2 pos)
        {
            transform.localPosition = pos;
            // get random animation duration
            var duration = Random.Range(2f, 5f);
            // init move animation
            var move = transform.DOMoveY(Mathf.Abs(pos.y), duration).SetEase(Ease.Linear);
            // on complete call on miss ball 
            move.onComplete += () => { OnMissBall?.Invoke(); };
            DOTween.Play(transform);
        }

        /// <summary>
        /// On mouse down
        /// </summary>
        private void OnMouseDown()
        {
            OnHitBall?.Invoke();
        }
    }
}