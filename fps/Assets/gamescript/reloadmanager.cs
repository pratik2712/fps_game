using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class reloadmanager : MonoBehaviour
{
    // Start is called before the first frame update
   
    public static int reload;
    Text text;
  

    void Start()
    {
       
        // Set up the reference.
        text = GetComponent<Text>();

        // Reset the score.
        reload = 0;
    }

    // Update is called once per frame
    void Update()
    {
        text.text = reload + "/inf";//+ playershooting.startammo ;
    }
}
