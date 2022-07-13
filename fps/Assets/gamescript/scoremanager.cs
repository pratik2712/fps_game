using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scoremanager : MonoBehaviour
{


    public static int score;        // The player's score.


    Text text;                      // Reference to the Text component.
                                    // Start is called before the first frame update

    void Awake()
    {
        // Set up the reference.
        text = GetComponent<Text>();

        // Reset the score.
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "Score: " + score;
    }
}
