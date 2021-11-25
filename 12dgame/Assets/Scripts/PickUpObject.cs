using UnityEngine;

public class PickUpObject : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Inventory.instance.addCoins(1);
            CurrentSceneManager.instance.coinsPickedUpInThisSceneCount++;
            Destroy(gameObject);
        }
    }
}
