using TileGenerationSystem;
using UnityEngine;

namespace Core
{
    [CreateAssetMenu(fileName = "TilesData",menuName = "Tile/TilesData")]
    public class TilesDataSO : ScriptableObject
    {
        [field: SerializeField] public TileDataSO[] Tiles { get; private set; }
        [field: SerializeField] public TileDataSO FirstTile { get; private set; }
    }
}