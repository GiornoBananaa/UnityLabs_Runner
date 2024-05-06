using System;
using UnityEngine;
using Zenject;

namespace CharacterSystem
{
    public class ObstaclesInteraction: ICollisionListener
    {
        private readonly CollisionDetector _collisionDetector;
        private readonly MovementController _movementController;
        private readonly CharacterAnimationController _animationController;
        
        public event Action OnObstacleHit;
        
        [Inject]
        public ObstaclesInteraction(CollisionDetector collisionDetector,
            CharacterAnimationController animationController, 
            MovementController movementController, LayerMask obstacleLayers)
        {
            _animationController = animationController;
            _movementController = movementController;
            collisionDetector.Subscribe(this, obstacleLayers);
        }
        
        public void CollisionEnter(Collision other)
        {
            PlayLoose();
        }

        private void PlayLoose()
        {
            _animationController.PlayObstacleHit();
            _movementController.StopMoveForward();
            OnObstacleHit?.Invoke();
        }
    }
}
