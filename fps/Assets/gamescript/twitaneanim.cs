using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class twitaneanim : MonoBehaviour
{
    Animator anim;
    enemyattack enemyattack;
   // enemymove enemymove;
    enemyhealth enemyhealth;
    GameObject enemy;
    // Start is called before the first frame update
    void Start()
    {
        enemy = GameObject.FindGameObjectWithTag("twitenemy");
        enemyattack = enemy.GetComponent<enemyattack>();
        //  enemymove = enemy.GetComponent<enemymove>();
        enemyhealth = enemy.GetComponent<enemyhealth>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        if (enemyhealth.isDead.Equals(true))
        {
            anim.SetTrigger("die");
        }



        int rand = Random.Range(1 , 3);

        if (enemyattack.playerInRange.Equals(true) && rand == 1)
        {
            // attack = true;
            anim.SetBool("attack1", true);
        }
        else if (enemyattack.playerInRange.Equals(false))
        {
            //attack = false;
            anim.SetBool("attack1", false);
        }



        if (enemyattack.playerInRange.Equals(true) && rand == 2)
        {
            // attack = true;
            anim.SetBool("attack2", true);
        }
        else if (enemyattack.playerInRange.Equals(false))
        {
            //attack = false;
            anim.SetBool("attack2", false);
        }

    }
}
