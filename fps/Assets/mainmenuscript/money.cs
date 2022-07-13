using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class money : MonoBehaviour
{
    // Start is called before the first frame update
    // coincollect Coincollect;
    // GameObject coinmoney;
    public TMPro.TextMeshProUGUI text;
    int currentcoins;
    int coin21;
   // int coin22;
    void Start()
    {
        

        currentcoins = PlayerPrefs.GetInt("dollar");
        PlayerPrefs.DeleteKey("dollar");
        PlayerPrefs.SetInt("dollar1", (PlayerPrefs.GetInt("dollar1") + currentcoins));
        coin21 = PlayerPrefs.GetInt("dollar1");
        text.text  = " " + coin21;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
