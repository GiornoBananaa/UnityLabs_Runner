using System;
using DG.Tweening;
using UnityEngine;
using Zenject;

namespace CharacterSystem
{
    public class MovementController : ITickable, ICollisionListener
    {
        private readonly CharacterAnimationController _animationController;
        private readonly Rigidbody _rigidbody;
        private readonly Transform _transform;
        private const int _linesCount = 3;
        private const float _lineWidth = 2.5f;
        private const float _duration = 0.2f;
        private const float _jumpForce = 350;
        private const float _forwardSpeed = 5;
        private int _currentLine;
        private float _passedDistance;
        private bool _isChangingSide;
        private bool _isJumping;
        private bool _isSliding;
        private bool _continueSlide;
        private bool _slideAnimationIsEnded;
        private bool _isMovingForward;
        
        public event Action<float> OnDistanceChanged;
        
        public Transform CameraTransform { get; private set; }
        
        [Inject]
        public MovementController(CollisionDetector collisionDetector, 
            CharacterAnimationController animationController,
            Rigidbody rigidbody, Transform cameraTransform, LayerMask groundLayerMask)
        {
            _rigidbody = rigidbody;
            _transform = rigidbody.transform;
            CameraTransform = cameraTransform;
            _animationController = animationController;
            collisionDetector.Subscribe(this, groundLayerMask);
            _isMovingForward = true;
        }
        
        public void Tick()
        {
            MoveForward();
        }
        
        public void MoveRight()
        {
            if(_currentLine >= _linesCount / 2)
                return;
            _currentLine++;
            MoveX();
        }
        
        public void Jump()
        {
            if(_isJumping)
                return;
            
            _rigidbody.AddForce(new Vector3(0, _jumpForce, 0));
            _isJumping = true;
            _animationController.PlayJump();
            if (_isSliding) EndSlide();
        }

        public void Slide()
        {
            _rigidbody.AddForce(new Vector3(0, -_jumpForce * 2, 0));
            _animationController.PlaySlide();
            _isSliding = true;
            _continueSlide = true;
            _slideAnimationIsEnded = false;
            _animationController.OnSlideEnd += OnSlideAnimationEnd;
        }
        
        public void MoveLeft()
        {
            if(_currentLine <= -_linesCount / 2)
                return;
            _currentLine--;
            MoveX();
        }
        
        public void CollisionEnter(Collision other)
        {
            if (_isJumping && _rigidbody.velocity.y <= 0)
            {
                StopJump();
            }
        }
        
        public void StopMoveForward()
        {
            _isMovingForward = false;
        }
        
        public void StopSlideLoop()
        {
            _continueSlide = false;
            if (_slideAnimationIsEnded)
                EndSlide();
        }
        
        private void MoveForward()
        {
            if(!_isMovingForward) return;
            
            float addedDistance = _forwardSpeed * Time.deltaTime;
            _passedDistance += addedDistance;
            CameraTransform.position += new Vector3(0, 0, addedDistance);
            OnDistanceChanged?.Invoke(_passedDistance);
        }
        
        private void OnSlideAnimationEnd()
        {
            _slideAnimationIsEnded = true;
            if(!_continueSlide)
            {
                EndSlide();
            }
        }
        
        private void EndSlide()
        {
            _isSliding = false;
            _continueSlide = false;
            _animationController.StopSlide();
            _animationController.OnSlideEnd -= OnSlideAnimationEnd;
        }
        
        private void StopJump()
        {
            _isJumping = false;
        }
        
        private void MoveX()
        {
            _isChangingSide = true;
            _transform.DOMoveX(_currentLine * _lineWidth, _duration).OnComplete(() => _isChangingSide = false);
        }
    }
}
