using GameStateSystem;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UI
{
    public class EndPanel : MonoBehaviour
    {
        [SerializeField] private RectTransform _panel;
        [SerializeField] private Button _restartButton;
        [SerializeField] private TMP_Text _scoreText;
        
        private Game _game;
        
        [Inject]
        public void Construct(Game game)
        {
            _game = game;
        }
        
        private void Awake()
        {
            _restartButton.onClick.AddListener(OnRestart);
        }

        public void OpenPanel(int score)
        {
            _panel.gameObject.SetActive(true);
            _scoreText.text = score.ToString();
        }

        private void OnRestart()
        {
            _game.Restart();
        }
    }
}
