using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermovement : MonoBehaviour
{
    // Start is called before the first frame update
    public CharacterController controller;
    public float speed = 20f;
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


    // Update is called once per frame
    void Update()
    {
       // float x = Input.GetAxis("Horizontal");
       // float z = Input.GetAxis("Vertical");

        //float x = Joystick.Horizontal;
        //float z = Joystick.Vertical;
        Vector2 movementinput = playerinput.playermain.move.ReadValue<Vector2>();

        Vector3 move = new Vector3(movementinput.x, 0f, -movementinput.y);
        controller.Move(move * speed * Time.deltaTime);
    }
}
