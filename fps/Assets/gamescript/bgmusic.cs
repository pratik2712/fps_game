using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class bgmusic : MonoBehaviour
{

    GameObject player;                          // Reference to the player GameObject.
    playerhealth playerHealth;
    AudioSource bgAudio;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<playerhealth>();
        bgAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(playerHealth.currentHealth <= 0)
        {
            bgAudio.Stop();
            Cursor.lockState = CursorLockMode.Confined;
            SceneManager.LoadScene(2);
        }
    }
}
