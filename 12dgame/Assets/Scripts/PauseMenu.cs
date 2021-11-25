using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool gameIsPaused = false;

    public GameObject pauseMenuUI;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(gameIsPaused)
            {
                Resume();
            }
            else
            {
                Paused();
            }
        }
    }

    void Paused()
    {
        PlayerMovement.instance.enabled = false;//pour éviter de sauter en sortir d echappe
        //activer notre menu pause et l afficher
        pauseMenuUI.SetActive(true);
        //ârreter le temps
        Time.timeScale = 0; // le temps se déroule a une vitesse de 0
        //changer le statut du jeu, la variable gameIsPaused
        gameIsPaused = true;
    }

    public void Resume()
    {
        PlayerMovement.instance.enabled = true;
        //desactiver notre menu pause et l afficher
        pauseMenuUI.SetActive(false);
        //remettre le temps
        Time.timeScale = 1; // le temps se déroule a une vitesse normale , 1 dans le jeu pour 1 IRL
        //changer le statut du jeu, la variable gameIsPaused
        gameIsPaused = false;
    }

    public void LoadMainMenu()
    {
        DontDestroyOnLoadScene.instance.RemoveFromDontDestroyOnLoad();
        Resume();
        SceneManager.LoadScene("MainMenu");
    }
}
