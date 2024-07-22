using UnityEngine;
using UnityEngine.SceneManagement;

namespace Test.UI
{
    public class MainMenu : MonoBehaviour
    {
        public void StartGame()
        {
            SceneManager.LoadSceneAsync(1);
        }

        public void ExitGame()
        {
            Application.Quit();
        }
    }
}