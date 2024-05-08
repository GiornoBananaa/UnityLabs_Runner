using System;
using CharacterSystem;

namespace ScoreSystem
{
    public class ScoreCounter
    {
        private const float SCORE_MULTIPLIER = 1f;
        
        public int Score { get; private set; }
        public event Action<int> OnScoreChange;
        
        public ScoreCounter(MovementController characterMovement)
        {
            characterMovement.OnDistanceChanged += OnPassedDistanceChanged;
        }

        private void OnPassedDistanceChanged(float distance)
        {
            Score = (int)(distance * SCORE_MULTIPLIER);
            OnScoreChange?.Invoke(Score);
        }
    }
}