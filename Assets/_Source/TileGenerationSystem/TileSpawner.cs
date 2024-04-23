using System;
using CameraSystem;
using UnityEngine;
using Zenject;

namespace TileGenerationSystem
{
    public class TileSpawner : MonoBehaviour
    {
        [SerializeField] private float _minDistanceToLastTile;
        [SerializeField] private float _maxDistanceToFisrtTile;
        
        private CameraMovement _cameraMovement; 
        private TileGenerator _tileGenerator;
        
        [Inject]
        public void Construct(CameraMovement cameraMovement, TileGenerator tileGenerator)
        {
            _cameraMovement = cameraMovement;
            _tileGenerator = tileGenerator;
        }

        private void Update()
        {
            CheckFirstTile();
            CheckLastTile();
        }

        private void CheckLastTile()
        {
            if (Vector3.Distance(_cameraMovement.transform.position, _tileGenerator.LastTile.position) <= _minDistanceToLastTile)
            {
                _tileGenerator.AddLastTile();
            }
        }
        
        private void CheckFirstTile()
        {
            if (Vector3.Distance(_cameraMovement.transform.position, _tileGenerator.FirstTile.position) <= _maxDistanceToFisrtTile)
            {
                _tileGenerator.RemoveFirstTile();
            }
        }
    }
}
