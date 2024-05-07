using System.Collections.Generic;
using Core;
using UnityEngine;
using Zenject;

namespace TileGenerationSystem
{
    public class TileGenerator
    {
        private class Tile
        {
            public GameObject GameObject;
            public TileDataSO TileData;

            public Tile(GameObject gameObject, TileDataSO tileData)
            {
                GameObject = gameObject;
                TileData = tileData;
            }
        }

        private const int ENABLED_TILES_COUNT = 5;
        private const int TILE_INSTANCES_COUNT = 3;
        
        private readonly Vector3 _tileSpawnOffset = new (0,0,20);
        private readonly Vector3 _firstTilePosition = new (0,0,0);
        private List<Tile> _disabledTile;
        private List<Tile> _enabledTile;
        private TileDataSO _startTile;

        public Transform LastTile => _enabledTile[^1].GameObject.transform;
        public Transform FirstTile => _enabledTile[0].GameObject.transform;
        
        [Inject]
        public TileGenerator(TilesDataSO tilesData)
        {
            _disabledTile = new List<Tile>();
            _enabledTile = new List<Tile>();
            
            _startTile = tilesData.FirstTile;
            
            float allTilesWeight = 0;
            foreach (var tileData in tilesData.Tiles)
            {
                allTilesWeight += tileData.Weight;

                for (int i = 0; i < TILE_INSTANCES_COUNT; i++)
                {
                    Tile newTile = new Tile(Object.Instantiate(tileData.Prefab), tileData);
                    newTile.GameObject.SetActive(false);
                    _disabledTile.Add(newTile);
                }
            }
            
            for (int i = 0; i < ENABLED_TILES_COUNT; i++)
            {
                AddLastTile();
            }
        }
        
        public void RemoveFirstTile()
        {
            Tile tile = _enabledTile[0];
            tile.GameObject.SetActive(false);
            _enabledTile.Remove(tile);
            _disabledTile.Add(tile);
        }

        public void AddLastTile()
        {
            List<TileDataSO> uncheckedConnectedTiles = _enabledTile.Count > 0
                ? new List<TileDataSO>(_enabledTile[^1].TileData.ConnectableTiles)
                : new List<TileDataSO>(_startTile.ConnectableTiles);
            
            Tile nextTile = null;
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
                        nextTile = tile;
                        break;
                    }
                }
                
                if (nextTile != null) break;
                uncheckedConnectedTiles.Remove(pickedTileData);
            }

            EnableTile(nextTile);
        }
        
        private void EnableTile(Tile tile)
        {
            Vector3 lastTilePosition;
            if (_enabledTile.Count != 0)
                lastTilePosition = _enabledTile[^1].GameObject.transform.position;
            else
                lastTilePosition = _firstTilePosition;

            _disabledTile.Remove(tile);
            _enabledTile.Add(tile);
            tile.GameObject.transform.position = lastTilePosition + _tileSpawnOffset;
            tile.GameObject.SetActive(true);
        }
    }
}
