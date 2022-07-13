using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coincollect : MonoBehaviour
{
    GameObject player;
   // playerhealth playerHealth;
    public bool playercollect;
    public static int nocoins = 0;
   // public int nocoins2 = 0;

    AudioSource cointing;
    public AudioClip coinclip;
   
    // Start is called before the first frame update
    void Start()
    {
       player = GameObject.FindGameObjectWithTag("Player");
       cointing = GetComponent<AudioSource>();
       // playerHealth = player.GetComponent<playerhealth>();
        
    }

    void OnTriggerEnter(Collider other)
    {
        // If the entering collider is the player...
        if (other.gameObject == player)
        {
            // ... the player is in range.
            playercollect = true;
        }
    }


    void OnTriggerExit(Collider other)
    {
        // If the exiting collider is the player...
        if (other.gameObject == player)
        {
            // ... the player is no longer in range.
            playercollect = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (playercollect.Equals(true))
        {
            AudioSource.PlayClipAtPoint(coinclip, transform.position);
            Destroy(gameObject);
            nocoins += 10;
          
        }

       PlayerPrefs.SetInt("dollar", nocoins);
    }
}
