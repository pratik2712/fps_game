using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerhealth : MonoBehaviour
{
    // Start is called before the first frame update

    public int startingHealth = 100;                            // The amount of health the player starts the game with.
    public int currentHealth;                                   // The current health the player has.
    public Slider healthSlider;                                 // Reference to the UI's health bar.
    public AudioClip deathClip;
    public RawImage damageImage;
    public float flashSpeed = 5f;                               // The speed the damageImage will fade at.
    public Color flashColour = new Color(1f, 0f, 0f, 0.1f);     // The colour the damageImage is set to, to flash.
    AudioSource playerAudio;
    playermovement playerMovement;
    playershooting playerShooting;
    bool isDead;                                                // Whether the player is dead.
    bool damaged;                                               // True when the player gets damaged.
   
    void Awake()
    {
        // Setting up the references.
        playerAudio = GetComponent<AudioSource>();
        playerMovement = GetComponent<playermovement>();
        playerShooting = GetComponentInChildren<playershooting>();
       
        // Set the initial health of the player.
        currentHealth = startingHealth;
    }

    // Update is called once per frame
    void Update()
    {
        // If the player has just been damaged...
        if (damaged)
        {
            // ... set the colour of the damageImage to the flash colour.
            damageImage.color = flashColour;
        }
        // Otherwise...
        else
        {
            // ... transition the colour back to clear.
            damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
        }

        // Reset the damaged flag.
        damaged = false;
    }

    public void TakeDamage(int amount)
    {
        // Set the damaged flag so the screen will flash.
        damaged = true;

        // Reduce the current health by the damage amount.
        currentHealth -= amount;

        // Set the health bar's value to the current health.
        healthSlider.value = currentHealth;

        // Play the hurt sound effect.
        playerAudio.Play();

        // If the player has lost all it's health and the death flag hasn't been set yet...
        if (currentHealth <= 0 && !isDead)
        {
            // ... it should die.
            Death();
        }
    }

    void Death()
    {
        // Set the death flag so this function won't be called again.
        isDead = true;

        // Turn off any remaining shooting effects.
       //playerShooting.DisableEffects();

        // Tell the animator that the player is dead.
      //  anim.SetTrigger("Die");

        // Set the audiosource to play the death clip and play it (this will stop the hurt sound from playing).
        playerAudio.clip = deathClip;
        playerAudio.Play();

        // Turn off the movement and shooting scripts.
        playerMovement.enabled = false;
        playerShooting.enabled = false;
       
    }
}
