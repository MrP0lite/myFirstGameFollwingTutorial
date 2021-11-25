using System;
using System.Collections;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    public float invincibilityTimeAfterHit = 3F;
    public float invincibilityFlashDelay = 0.2F;
    public Boolean isInvincible = false;

    public SpriteRenderer graphics;
    public HealthBar healthBar;

    public static PlayerHealth instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("There is more than one instance of PlayerHealth existing in the scene.");
            return;
        }

        instance = this;
    }




    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.H))
        {
            TakeDamage(60);
        }
    }

    public void HealPlayer(int amount)
    {
        
        currentHealth += amount;
        
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        healthBar.SetHealth(currentHealth);
    }

    public void TakeDamage(int damage)
    {
        if (!isInvincible)
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
        // la même chose
        //currentHealth = currentHealth - damage;

        //vérifier si le joueur est toujours vivant
        if (currentHealth < 1)
        {
            Die();
            return; 
        }

        isInvincible = true;
        StartCoroutine(InvincibilityFlash());
        StartCoroutine(HandleInvincibilityDelay());

    }

    public void Die()
    {
        Debug.Log("The player is dead.");

        //bloquer les mouvements du joueur plus précisément l instance du script PlayerMovement
        PlayerMovement.instance.enabled = false;

        //jouer l'animation d'élimination , dans PlayerMovement il y a une instance de l animator
        PlayerMovement.instance.animator.SetTrigger("Die");

        //empêcher les interaction physique avec les autres éléments de la scène et évitet que le serpent nous pousse ou qu a chaque contact l animation de mort s effectue
        PlayerMovement.instance.rb.bodyType = RigidbodyType2D.Kinematic;
        //mettre à 0 l inertie du joueur lors de sa mort
        PlayerMovement.instance.rb.velocity = Vector3.zero;
        PlayerMovement.instance.playerCollider.enabled = false;

        //appel du screen gameOver lors de la mort
        GameOverManager.instance.OnPlayerDeath();

        // le joueur mort avec de l elan garde son élan , meme pb qu avec les echelles, peut etre bool puis si bool alors meme rx et ry = 0
    }

    public void respawn()
    {
        Debug.Log("The player is respawned.");

        //bloquer les mouvements du joueur plus précisément l instance du script PlayerMovement ; inverse
        PlayerMovement.instance.enabled = true;

        //jouer l'animation d'élimination , dans PlayerMovement il y a une instance de l animator; inverse
        PlayerMovement.instance.animator.SetTrigger("Respawn");

        //empêcher les interaction physique avec les autres éléments de la scène et évitet que le serpent nous pousse ou qu a chaque contact l animation de mort s effectue; inverse
        PlayerMovement.instance.rb.bodyType = RigidbodyType2D.Dynamic;
        PlayerMovement.instance.playerCollider.enabled = true;

        //redonner de la vie avec le visuel
        currentHealth = maxHealth;
        healthBar.SetHealth(currentHealth);

    }

    public IEnumerator InvincibilityFlash()
    {
        while(isInvincible)
        {
            graphics.color = new Color(1f, 1f, 1f, 0f);
            yield return new WaitForSeconds(invincibilityFlashDelay);
            graphics.color = new Color(1f, 1f, 1f, 1f);
            yield return new WaitForSeconds(invincibilityFlashDelay);
        }
    }

    public IEnumerator HandleInvincibilityDelay()
    {
        yield return new WaitForSeconds(invincibilityTimeAfterHit);
        isInvincible = false;
    }
}
