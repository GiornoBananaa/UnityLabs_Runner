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
        private GameStateMachine _gameStateMachine;
        
        [Inject] 
        private void Construct(GameStateMachine gameStateMachine)
        {
            _gameStateMachine = gameStateMachine;
        }

        private void Awake()
        {
            _gameStateMachine.ChangeState<RunningGameState>();
        }
    }
}
