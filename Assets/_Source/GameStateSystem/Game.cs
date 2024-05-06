using UnityEngine.SceneManagement;

namespace GameStateSystem
{
    public class Game
    {
        private const int ARCADE_SCENE_INDEX = 0;
        private const int MAINMENU_SCENE_INDEX = 1;
        
        public void Start()
        {
            SceneManager.LoadScene(ARCADE_SCENE_INDEX);
        }

        public void Restart()
        {
            Start();
        }
        
        public void MainMenu()
        {
            SceneManager.LoadScene(MAINMENU_SCENE_INDEX);
        }
    }
}
