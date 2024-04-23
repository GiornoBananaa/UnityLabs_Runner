using UnityEngine;

namespace TileGenerationSystem
{
    [CreateAssetMenu(fileName = "TileData",menuName = "Tile/TileData")]
    public class TileDataSO : ScriptableObject
    {
        [field: SerializeField] public GameObject Prefab { get; private set; }
        [field: SerializeField] public float Weight { get; private set; }
        [field: SerializeField] public TileDataSO[] ConnectableTiles { get; private set; }
    }
}
