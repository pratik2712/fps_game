using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sensi : MonoBehaviour
{
    [SerializeField] private Slider senslider = null;

    private void Start()
    {
        loadvalues();
    }

    public void senchange ()
    {
        float sen = senslider.value;
        PlayerPrefs.SetFloat("sen", sen);
        loadvalues();
    }

    void loadvalues()
    {
        float sen = PlayerPrefs.GetFloat("sen");
        senslider.value = sen;
    }
}
