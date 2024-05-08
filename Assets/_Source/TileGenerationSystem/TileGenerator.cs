using System.Collections.Generic;
using Core;
using UnityEngine;
using Zenject;

namespace TileGenerationSystem
{
    public class TileGenerator
    {
        /*
        public class ObjectPool<T>
        {
            private IFactory<T> _objectFactory;
            
            private List<T> _disabledTile;
            private List<T> _enabledTile;
            
            public Transform Last => _enabledTile[^1].GameObject.transform;
            public Transform First => _enabledTile[0].GameObject.transform;
            
            public ObjectPool(IFactory<T> objectFactory)
            {
                _objectFactory = objectFactory;
            }
        }*/
        
        private class TileInstance
        {
            public GameObject GameObject;
            public TileDataSO TileData;

            public TileInstance(GameObject gameObject, TileDataSO tileData)
            {
                GameObject = gameObject;
                TileData = tileData;
            }
        }

        private const int ENABLED_TILES_COUNT = 5;
        private const int TILE_INSTANCES_COUNT = 3;
        
        private readonly Vector3 _tileSpawnOffset = new (0,0,20);
        private readonly Vector3 _firstTilePosition = new (0,0,0);
        private List<TileInstance> _disabledTile;
        private List<TileInstance> _enabledTile;
        private TileDataSO _startTile;

        public Transform LastTile => _enabledTile[^1].GameObject.transform;
        public Transform FirstTile => _enabledTile[0].GameObject.transform;
        
        [Inject]
        public TileGenerator(TilesDataSO tilesData)
        {
            _disabledTile = new List<TileInstance>();
            _enabledTile = new List<TileInstance>();
            
            _startTile = tilesData.FirstTile;
            
            float allTilesWeight = 0;
            foreach (var tileData in tilesData.Tiles)
            {
                allTilesWeight += tileData.Weight;

                for (int i = 0; i < TILE_INSTANCES_COUNT; i++)
                {
                    TileInstance newTileInstance = new TileInstance(Object.Instantiate(tileData.Prefab), tileData);
                    newTileInstance.GameObject.SetActive(false);
                    _disabledTile.Add(newTileInstance);
                }
            }
            
            for (int i = 0; i < ENABLED_TILES_COUNT; i++)
            {
                AddLastTile();
            }
        }
        
        public void RemoveFirstTile()
        {
            TileInstance tileInstance = _enabledTile[0];
            tileInstance.GameObject.SetActive(false);
            _enabledTile.Remove(tileInstance);
            _disabledTile.Add(tileInstance);
        }

        public void AddLastTile()
        {
            List<TileDataSO> uncheckedConnectedTiles = _enabledTile.Count > 0
                ? new List<TileDataSO>(_enabledTile[^1].TileData.ConnectableTiles)
                : new List<TileDataSO>(_startTile.ConnectableTiles);
            
            TileInstance nextTileInstance = null;
            while (uncheckedConnectedTiles.Count != 0)
            {
                float allTilesWeight = 0;
                for (int i = 0; i < uncheckedConnectedTiles.Count; i++)
                {
                    allTilesWeight += uncheckedConnectedTiles[i].Weight;
                }
                
                float randomFloat = Random.Range(0,allTilesWeight);
                float currentfloat = 0;
                TileDataSO pickedTileData = null;
                foreach (var tile in uncheckedConnectedTiles)
                {
                    pickedTileData = tile;
                    currentfloat += pickedTileData.Weight;
                    if (currentfloat >= randomFloat)
                    {
                        break;
                    }
                }
                
                foreach (var tile in _disabledTile)
                {
                    if (tile.TileData == pickedTileData)
                    {
                        nextTileInstance = tile;
                        break;
                    }
                }
                
                if (nextTileInstance != null) break;
                uncheckedConnectedTiles.Remove(pickedTileData);
            }

            EnableTile(nextTileInstance);
        }
        
        private void EnableTile(TileInstance tileInstance)
        {
            Vector3 lastTilePosition;
            if (_enabledTile.Count != 0)
                lastTilePosition = _enabledTile[^1].GameObject.transform.position;
            else
                lastTilePosition = _firstTilePosition;

            _disabledTile.Remove(tileInstance);
            _enabledTile.Add(tileInstance);
            tileInstance.GameObject.transform.position = lastTilePosition + _tileSpawnOffset;
            tileInstance.GameObject.SetActive(true);
        }
    }
}
