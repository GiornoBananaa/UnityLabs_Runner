using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace TileGenerationSystem
{
    public class TileGenerator
    {
        public class Tile
        {
            public GameObject GameObject;
            public TileDataSO TileData;

            public Tile(GameObject gameObject, TileDataSO tileData)
            {
                GameObject = gameObject;
                TileData = tileData;
            }
        }

        private const int ENABLED_TILES_COUNT = 3;
        
        private readonly Vector3 _tileSpawnOffset = new Vector3(0,5,0);
        private List<Tile> _disabledTile;
        private List<Tile> _enabledTile;

        public Transform LastTile => _enabledTile[^1].GameObject.transform;
        public Transform FirstTile => _enabledTile[0].GameObject.transform;
        
        [Inject]
        public TileGenerator(TileDataSO[] tilesData)
        {
            _disabledTile = new List<Tile>();
            _enabledTile = new List<Tile>();
            
            float allTilesWeight = 0;
            foreach (var tileData in tilesData)
            {
                allTilesWeight += tileData.Weight;
                _disabledTile.Add(new Tile(Object.Instantiate(tileData.Prefab),tileData));
                _disabledTile.Add(new Tile(Object.Instantiate(tileData.Prefab),tileData));
            }

            for (int i = 0; i < ENABLED_TILES_COUNT; i++)
            {
                AddLastTile();
            }
        }
        
        public void RemoveFirstTile()
        {
            _enabledTile[^1].GameObject.SetActive(false);
        }

        public void AddLastTile()
        {
            List<TileDataSO> uncheckedTiles = _enabledTile.Count > ENABLED_TILES_COUNT ? 
                new List<TileDataSO>(_enabledTile[^1].TileData.ConnectableTiles) 
                : new List<TileDataSO>(_disabledTile[Random.Range(0,_disabledTile.Count)].TileData.ConnectableTiles);
            
            Tile nextTile = null;
            while (uncheckedTiles.Count != 0)
            {
                float allTilesWeight = 0;
                for (int i = 0; i < uncheckedTiles.Count; i++)
                {
                    allTilesWeight += uncheckedTiles[i].Weight;
                }
                
                float randomFloat = Random.Range(0,allTilesWeight);
                float currentfloat = 0;
                TileDataSO pickedTileData = null;
                foreach (var tile in uncheckedTiles)
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
                uncheckedTiles.Remove(pickedTileData);
            }

            EnableTile(nextTile);
        }
        
        private void EnableTile(Tile tile)
        {
            Transform lastTilePosition = _enabledTile[^1].GameObject.transform;
            tile.GameObject.transform.position = lastTilePosition.position + _tileSpawnOffset;
            tile.GameObject.SetActive(true);
        }
    }
}
