using UnityEngine;

public class CurrentSceneManager : MonoBehaviour
{
    public bool isPlayerPresentByDefault = false;
    public int coinsPickedUpInThisSceneCount;

    public static CurrentSceneManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("There is more than one instance of CurrentSceneManager existing in the scene.");
            return;
        }

        instance = this;
    }
}
