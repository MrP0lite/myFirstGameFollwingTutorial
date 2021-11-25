using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string levelToLoad;
    public GameObject settingsWindows;

    public void StartGame()
    {
        SceneManager.LoadScene(levelToLoad);
    }

    public void SettingsButton()
    {
        settingsWindows.SetActive(true);
    }

    public void CloseSettingsWindows()
    {
        settingsWindows.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
