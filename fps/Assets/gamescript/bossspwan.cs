using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossspwan : MonoBehaviour
{

    public playerhealth playerHealth;       // Reference to the player's heatlh.
    public GameObject enemy;                // The enemy prefab to be spawned.
    public GameObject manager1;
    public GameObject manager3;

    // public float spawnTime;            // How long between each spawn.
    //  public float a = 3f;
    public Transform[] spawnPoints;         // An array of the spawn points this enemy can spawn from.
   // public int limitscore;
   // int result;
   // private float fSpeed_Increase;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawn", 0f, 50f);
    }

    // Update is called once per frame
    void Spawn()
    {
        // If the player has no health left...
        if (playerHealth.currentHealth <= 0f)
        {
            // ... exit the function.
            return;
        }


        //  result = scoremanager.score % 100;
        //  if (spawnTime >= 1)
        //  {
        //      if (result == 0 && scoremanager.score != 0)
        //       {
        //        spawnTime = spawnTime - 1;
        //      }
        //   }



       // if (scoremanager.score >= limitscore)
      // {
            // Find a random index between zero and one less than the number of spawn points.
            int spawnPointIndex = Random.Range(0, spawnPoints.Length);

            // Create an instance of the enemy prefab at the randomly selected spawn point's position and rotation.
            Instantiate(enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
        // }

        //manager1.GetComponent<enemymanager>().enabled = false;
        //  manager3.GetComponent<enemymanager>().enabled = false;

       // manager1.SetActive(false);
       // manager3.SetActive(false);
    }
}
