using UnityEngine;
using UnityEngine.UI;

public class Ladder : MonoBehaviour
{
    private bool isInRange;
    private PlayerMovement playerMovement;
    public BoxCollider2D topcollider; // ajout du new pour éviter une erreure non fatale, pas de pb a priori
    public Text InteractUI;

    // Start is called before the first frame update
    void Awake()
    {
        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        InteractUI = GameObject.FindGameObjectWithTag("InteractUI").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("update du ladder");
        //sortir de l echelle
            if (isInRange && playerMovement.isClimbing && Input.GetKeyDown(KeyCode.E))
        {
            playerMovement.isClimbing = false;
            topcollider.isTrigger = false;
            //Debug.Log("Descente de l'échelle.");
            return;
        }
        //entrer dans l echelle
        if (isInRange && Input.GetKeyDown(KeyCode.E))
        {
            //Debug.Log("Entrée dans l echelle");
            playerMovement.isClimbing = true;
            topcollider.isTrigger = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            //Debug.Log("J entre dans l echelle");
            InteractUI.enabled = true;
            isInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isInRange = false;
            playerMovement.isClimbing = false;
            topcollider.isTrigger = false;
            InteractUI.enabled = false;
        }
    }
}
