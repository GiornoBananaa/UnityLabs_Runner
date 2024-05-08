using CharacterSystem;
using GameStateSystem;
using InputSystem;
using ScoreSystem;
using TileGenerationSystem;
using UI;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace Core
{
    public class MainInstaller : MonoInstaller
    {
        private const string TILES_DATA_PATH = "TilesData";
        
        [SerializeField] private InputListener _inputListener;
        [SerializeField] private Rigidbody _character;
        [SerializeField] private Transform _cameraTransform;
        [SerializeField] private CollisionDetector _characterCollisionDetector;
        [SerializeField] private CharacterAnimationController _characterAnimationController;
        [SerializeField] private EndPanel _endPanel;
        [SerializeField] private ScoreView _scoreView;
        [SerializeField] private Bootstrapper _bootstrapper;
        [SerializeField] private LayerMask _groundLayerMask;
        [SerializeField] private LayerMask _obstacleLayerMask;
        
        public override void InstallBindings()
        {
            //Core
            Container.Bind<InputListener>().FromInstance(_inputListener).AsSingle();
            Container.Bind<Bootstrapper>().FromInstance(_bootstrapper).AsSingle();
            Container.Bind<Game>().AsSingle();
            Container.Bind<GameStateMachine>().AsSingle();
            
            //GameState
            Container.Bind<AState>().To<RunningGameState>().AsSingle();
            Container.Bind<AState>().To<EndGameState>().AsSingle();
            
            //Character
            Container.Bind<CharacterAnimationController>().FromInstance(_characterAnimationController).AsSingle();
            Container.Bind<CollisionDetector>().FromInstance(_characterCollisionDetector).AsSingle();
            Container.Bind<ObstaclesInteraction>().AsSingle().WithArguments(_obstacleLayerMask);
            Container.BindInterfacesAndSelfTo<MovementController>().AsSingle().WithArguments(_character, _cameraTransform, _groundLayerMask);
            
            //Generation
            Container.BindInterfacesAndSelfTo<TileSpawner>().AsSingle().NonLazy();
            Container.Bind<TileGenerator>().AsSingle();
            
            //SO
            TilesDataSO tilesData = Resources.Load<TilesDataSO>(TILES_DATA_PATH);
            Container.Bind<TilesDataSO>().FromInstance(tilesData).AsSingle();
            
            //Score
            Container.Bind<ScoreCounter>().AsSingle();
            
            //UI
            Container.Bind<ScoreView>().FromInstance(_scoreView).AsSingle();
            Container.Bind<EndPanel>().FromInstance(_endPanel).AsSingle();
        }
    }
}