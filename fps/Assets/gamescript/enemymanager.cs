using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemymanager : MonoBehaviour
{
    // Start is called before the first frame update

    public playerhealth playerHealth;       // Reference to the player's heatlh.
    public GameObject enemy;                // The enemy prefab to be spawned.
    public GameObject manager2;
   // public GameObject manager4;
    public float spawnTime ;            // How long between each spawn.
    public float a = 3f;
    public Transform[] spawnPoints;         // An array of the spawn points this enemy can spawn from.
    public int limitscore;
    //int result;
    private float fSpeed_Increase;

    void Start()
    {
        //manager2.GetComponent<bossspwan>().enabled = false;
      

        spawnTime = a;

        InvokeRepeating("Spawn", spawnTime, spawnTime);

        InvokeRepeating("subIncrease_Spawn_Speed", 30, 40);

      
    
    }


    void subIncrease_Spawn_Speed()
    {

         fSpeed_Increase  = 0.1f;

        //Cancel the current subSpawn_Object Invoke.
        CancelInvoke("Spawn");

        //This will limit the spawn speed to a min of 1.
        if ((spawnTime - fSpeed_Increase) < 1)
        {
            spawnTime = 1;
        }
        else
        {
            spawnTime = spawnTime - fSpeed_Increase;
        }

        //Restart subSpawn_Object with new repeat time.
        //You may want to adjust for the time since the last spawn
        //by setting up a time since last spawn var and using that
        //calculation rather than 0.
        InvokeRepeating("Spawn", 0, spawnTime);
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



        if (scoremanager.score>= limitscore)
        {
            // Find a random index between zero and one less than the number of spawn points.
            int spawnPointIndex = Random.Range(0, spawnPoints.Length);

            // Create an instance of the enemy prefab at the randomly selected spawn point's position and rotation.
            Instantiate(enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
        }

        if (scoremanager.score > 200 )
        {
            // manager2.GetComponent<bossspwan>().enabled = true;
            manager2.SetActive(true);
           // manager4.SetActive(true);
          
        }




    }

    


}
