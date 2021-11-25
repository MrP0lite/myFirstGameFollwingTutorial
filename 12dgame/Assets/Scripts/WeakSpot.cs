using System.Security.Cryptography;
using UnityEngine;

public class WeakSpot : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            //WeakSpot est dans Enemy, ainsi Enemy sera détruit avec ses sous objets
            Destroy(transform.parent.gameObject);
        }
    }

    //void OnCollisionEnter2D(Collision2D other)
    //{
    //    if(other.collider.CompareTag("Player"))
    //    {
    //        Destroy(transform.parent.gameObject);
    //    }
    //}
}
