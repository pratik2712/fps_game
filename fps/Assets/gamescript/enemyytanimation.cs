using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyytanimation : MonoBehaviour
{
    // Start is called before the first frame update
    Animator anim;
    enemyattack enemyattack;
   // enemymove enemymove;
    enemyhealth enemyhealth;
    GameObject enemy;
  //  bool attack;
   // bool walk;

    void Start()
    {
        enemy = GameObject.FindGameObjectWithTag("enemy");
        enemyattack = enemy.GetComponent<enemyattack>();
      //  enemymove = enemy.GetComponent<enemymove>();
        enemyhealth = enemy.GetComponent<enemyhealth>();
        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        if (enemyattack.playerInRange.Equals(true))
        {
           // attack = true;
            anim.SetBool("isattacking", true);
        }
        else if (enemyattack.playerInRange.Equals(false))
        {
            //attack = false;
            anim.SetBool("isattacking", false);
        }

      


        if (enemyhealth.isDead.Equals(true))
        {
            anim.SetTrigger("die");
        }
    }
}
