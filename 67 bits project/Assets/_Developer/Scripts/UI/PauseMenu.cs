using UnityEngine;
using UnityEngine.SceneManagement;

namespace Test.UI
{
    public class PauseMenu : MonoBehaviour
    {
        private bool _isOpen;

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
            }          
            else
            {
                gameObject.SetActive(false);
                _isOpen = false;
            }              
        }

        public void ExitToMainMenu()
        {

        }
    }
}