using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class edemoanim : MonoBehaviour
{
    // Start is called before the first frame update

    Animator anim;
    enemyattack enemyattack;
    enemymove enemymove;
    enemyhealth enemyhealth;
    GameObject enemydemo;

    void Start()
    {
        enemydemo = GameObject.FindGameObjectWithTag("enemydemo");
        enemyattack = enemydemo.GetComponent<enemyattack>();
        enemymove = enemydemo.GetComponent<enemymove>();
        enemyhealth = enemydemo.GetComponent<enemyhealth>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        if (enemyattack.playerInRange.Equals(true))
        {
            // attack = true;
            anim.SetBool("demoattack", true);
        }
        else if (enemyattack.playerInRange.Equals(false))
        {
            //attack = false;
            anim.SetBool("demoattack", false);
        }

    }
}
