using CharacterSystem;
using InputSystem;
using Zenject;

namespace GameStateSystem
{
    public class RunningGameState: AState
    {
        private readonly InputListener _inputListener;
        private readonly ObstaclesInteraction _obstaclesInteraction;
        
        [Inject]
        public RunningGameState(InputListener inputListener, ObstaclesInteraction obstaclesInteraction)
        {
            _inputListener = inputListener;
            _obstaclesInteraction = obstaclesInteraction;
        }
        
        public override void Enter()
        {
            _inputListener.EnableInput();
            _obstaclesInteraction.OnObstacleHit += OnLoose;
        }

        private void OnLoose()
        {
            Owner.ChangeState<EndGameState>();
        }
        
        public override void Exit()
        {
            
        }
    }
}