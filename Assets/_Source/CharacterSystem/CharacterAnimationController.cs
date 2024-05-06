using System;
using UnityEngine;
using Zenject;

namespace CharacterSystem
{
    [RequireComponent(typeof(Animator))]
    public class CharacterAnimationController: MonoBehaviour
    {
        private static readonly int SLIDE_HASH = Animator.StringToHash("Slide");
        private static readonly int JUMP_HASH = Animator.StringToHash("Jump");
        private static readonly int OBSTACLE_HASH = Animator.StringToHash("Obstacle");
        
        [SerializeField] private Animator _animator;

        public event Action OnSlideEnd;
        
        public void PlaySlide()
        {
            _animator.SetTrigger(SLIDE_HASH);
        }
        
        public void PlayJump()
        {
            _animator.SetTrigger(JUMP_HASH);
        }
        
        public void PlayObstacleHit()
        {
            _animator.SetTrigger(OBSTACLE_HASH);
        }

        public void EndSlide()
        {
            OnSlideEnd?.Invoke();
        }
    }
}