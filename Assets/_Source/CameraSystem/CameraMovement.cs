using System;
using UnityEngine;

namespace CameraSystem
{
    public class CameraMovement : MonoBehaviour
    {
        [SerializeField] private float _speed;
        
        private void LateUpdate()
        {
            MoveForward();
        }

        private void MoveForward()
        {
            transform.position += new Vector3(0,_speed * Time.deltaTime,0);
        }
    }
}
