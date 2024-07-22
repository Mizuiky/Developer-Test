using UnityEngine;
using UnityEngine.SceneManagement;

namespace Test.UI
{
    public class PauseMenu : MonoBehaviour
    {
        private bool _isOpen;
        private int _paused = 1;

        public void Init()
        {
            _isOpen = false;
            gameObject.SetActive(false);
        }

        public void Open()
        {
            if (!_isOpen)
            {
                gameObject.SetActive(true);
                _isOpen = true;
                _paused = 0;
            }          
            else
            {
                gameObject.SetActive(false);
                _paused = 1;
                _isOpen = false;
            }

            Time.timeScale = _paused;
        }

        public void ExitToMainMenu()
        {
            _paused = 1;
            Time.timeScale = _paused;
            SceneManager.LoadSceneAsync(0);
        }
    }
}