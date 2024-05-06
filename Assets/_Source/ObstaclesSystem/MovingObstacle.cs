using System;
using UnityEngine;

namespace ObstaclesSystem
{
    public class MovingObstacle : MonoBehaviour, ITriggerListener
    {
        [SerializeField] private Transform _obstacleTransform;
        [SerializeField] private TriggerDetector _triggerDetector;
        [SerializeField] private LayerMask _layerMask;
        [SerializeField] private float _speed;

        private Vector3 _startLocalPosition;
        private bool _isLaunched;
        
        private void Awake()
        {
            _triggerDetector.Subscribe(this, _layerMask);
            _startLocalPosition = _obstacleTransform.localPosition;
        }

        private void Update()
        {
            Move();
        }
        
        private void OnEnable()
        {
            ResetObstacle();
        }
        
        public void TriggerEnter(Collider other)
        {
            if (!_isLaunched)
                _isLaunched = true;
        }

        private void Move()
        {
            if(!_isLaunched) return;
            
            _obstacleTransform.position += new Vector3(0, 0, -_speed * Time.deltaTime);
        }
        
        private void ResetObstacle()
        {
            _isLaunched = false;
            _obstacleTransform.localPosition = _startLocalPosition;
        }
    }

    public interface ITriggerListener
    {
        void TriggerEnter(Collider other);
    }
}
