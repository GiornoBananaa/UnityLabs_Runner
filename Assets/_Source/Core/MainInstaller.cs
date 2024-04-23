using CameraSystem;
using TileGenerationSystem;
using UnityEngine;
using Zenject;

namespace Core
{
    public class MainInstaller : MonoInstaller
    {
        [SerializeField] private CameraMovement _cameraMovement;
        
        public override void InstallBindings()
        {
            //TODO: Load SO
            Container.Bind<TileGenerator>().AsSingle();
            Container.Bind<CameraMovement>().FromInstance(_cameraMovement);
        }
    }
}