using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private Transform playerSpawn;

    private void Awake()
    {
        playerSpawn = GameObject.FindGameObjectWithTag("PlayerSpawn").transform;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            playerSpawn.position = transform.position;
            //pour detruire l objet et son graphisme enfant
            //Destroy(gameObject);

            //autre maniere de faire , on conserve le graphisme du checkpoint
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }
    }
}
