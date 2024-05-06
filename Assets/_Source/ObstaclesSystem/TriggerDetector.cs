using System.Collections.Generic;
using UnityEngine;
using Utils;

namespace ObstaclesSystem
{
    public class TriggerDetector : MonoBehaviour
    {
        private readonly Dictionary<ITriggerListener, LayerMask> _collisionListener = new();
        
        public void Subscribe(ITriggerListener listener, LayerMask layerMask)
        {
            _collisionListener.Add(listener, layerMask);
        }
        
        public void Subscribe(ITriggerListener listener)
        {
            _collisionListener.Add(listener, Physics.AllLayers);
        }
        
        public void UnSubscribe(ITriggerListener listener)
        {
            _collisionListener.Remove(listener);
        }
        
        private void OnTriggerEnter(Collider other)
        {
            foreach (var listener in _collisionListener)
            {
                if (listener.Value.Contains(other.gameObject.layer))
                {
                    listener.Key.TriggerEnter(other);
                }
            }
        }
    }
}