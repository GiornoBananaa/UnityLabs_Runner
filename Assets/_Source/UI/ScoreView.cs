using TMPro;
using UnityEngine;
using Zenject;

namespace UI
{
    public class ScoreView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _scoreText;

        private ScoreCounter _scoreCounter;
        
        [Inject]
        public void Construct(ScoreCounter scoreCounter)
        {
            _scoreCounter = scoreCounter;
            _scoreCounter.OnScoreChange += ChangeScore;
        }

        private void ChangeScore(int score)
        {
            _scoreText.text = $"Score: {score}";
        }
    }
}
