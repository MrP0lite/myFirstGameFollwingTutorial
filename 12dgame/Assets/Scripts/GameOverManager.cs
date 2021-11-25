using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public GameObject gameOverUI;

    public static GameOverManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("There is more than one instance of GameOverManager existing in the scene.");
            return;
        }

        instance = this;
    }
    public void OnPlayerDeath()
    {
        if(CurrentSceneManager.instance.isPlayerPresentByDefault)
        {
            DontDestroyOnLoadScene.instance.RemoveFromDontDestroyOnLoad();
        }
        gameOverUI.SetActive(true);
    }

    public void RetryButton()
        //recommencer le niveau
    {
        //recharger la scene (par index du build pour par nom)
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        //replacer le joueur au spawn
        //reactiver les mouvements du joueurs 

        //+ lui rendre sa vie + l animation de retour
        PlayerHealth.instance.respawn();


        //reset le nombre de piece recu dans le niveau de mort
        Inventory.instance.RemoveCoins(CurrentSceneManager.instance.coinsPickedUpInThisSceneCount);

        //désactiver l UI de gameOver
        gameOverUI.SetActive(false);
    }

    public void MainMenuButton()
        //retour au menu principal
    {
        DontDestroyOnLoadScene.instance.RemoveFromDontDestroyOnLoad();
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitButton()
        //quitter le jeu
    {
        Application.Quit();
    }
}
