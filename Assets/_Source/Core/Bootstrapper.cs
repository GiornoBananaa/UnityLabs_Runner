using System;
using CharacterSystem;
using GameStateSystem;
using Zenject;
using TileGenerationSystem;
using UnityEngine;

namespace Core
{
    public class Bootstrapper : MonoBehaviour
    {
        private TileSpawner _tileSpawner;
        private GameStateMachine _gameStateMachine;
        
        [Inject] 
        private void Construct(TileSpawner tileSpawner, GameStateMachine gameStateMachine)
        {
            _tileSpawner = tileSpawner;
            _gameStateMachine = gameStateMachine;
        }

        private void Awake()
        {
            _gameStateMachine.ChangeState<RunningGameState>();
        }
    }
}
