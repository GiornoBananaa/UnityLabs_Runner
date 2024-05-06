using CharacterSystem;
using UnityEngine;
using Zenject;

namespace TileGenerationSystem
{
    public class TileSpawner : ITickable
    {
        private float _minDistanceToLastTile = 3f;
        
        private MovementController _movementController; 
        private TileGenerator _tileGenerator;
        
        [Inject]
        public TileSpawner(MovementController movementController, TileGenerator tileGenerator)
        {
            _movementController = movementController;
            _tileGenerator = tileGenerator;
        }
        
        public void Tick()
        {
            CheckLastTile();
        }

        private void CheckLastTile()
        {
            if (Vector3.Distance(_movementController.CameraTransform.position, _tileGenerator.LastTile.position) < _minDistanceToLastTile)
            {
                _tileGenerator.AddLastTile();
                _tileGenerator.RemoveFirstTile();
            }
        }
    }
}
