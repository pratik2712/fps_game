using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class mouselook : MonoBehaviour
{
    // Start is called before the first frame update
    public float mousesen = 100f;
    public Transform playerbody;
    float xrotation = 0f;

    private Player playerinput;




    private void Awake()
    {
        playerinput = new Player();
    }

    private void OnEnable()
    {
        playerinput.Enable();
    }

    private void OnDisable()
    {
        playerinput.Disable();
    }

    void Start()
    {
      //  Cursor.lockState = CursorLockMode.Locked;
        mousesen = PlayerPrefs.GetFloat("sen");
    }

    // Update is called once per frame
    void Update()
    {

        Vector2 delta = playerinput.playermain.look.ReadValue<Vector2>();
        // += delta.x * mousesen * Time.deltaTime;

        // float x = Input.GetAxis("Mouse X") * mousesen * Time.deltaTime;

        //float y = Input.GetAxis("Mouse Y") * mousesen * Time.deltaTime;
        float x = delta.x * mousesen * Time.deltaTime;
        float y = delta.y * mousesen * Time.deltaTime;
        xrotation -= y;
        xrotation = Mathf.Clamp(xrotation, -90f, 90f);
        transform.localRotation = Quaternion.Euler(xrotation, 0f, 0f);


        playerbody.Rotate(Vector3.up * x);


    }

   


}
