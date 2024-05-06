using InputSystem;
using UI;
using Zenject;

namespace GameStateSystem
{
    public class EndGameState: AState
    {
        private readonly InputListener _inputListener;
        private readonly EndPanel _endPanel;
        private readonly ScoreCounter _scoreCounter;

        [Inject]
        public EndGameState(ScoreCounter scoreCounter, 
            InputListener inputListener, EndPanel endPanel)
        {
            _scoreCounter = scoreCounter;
            _inputListener = inputListener;
            _endPanel = endPanel;
        }
        
        public override void Enter()
        {
            _inputListener.DisableInput();
            _endPanel.OpenPanel(_scoreCounter.Score);
        }

        public override void Exit()
        {
            
        }
    }
}