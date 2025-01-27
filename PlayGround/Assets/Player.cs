using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    //Input
    private Vector2 move_input_vec = Vector2.zero;

    //Movement variables
    private CharacterController controller;
    private Vector3 velocity;
    public float max_speed = 10f;
    public float acceleration = 2f;
    public float friction = 1.5f;
    public float gravity = -1f;
    public float jump_power = 21f;

    //Camera
    public Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        //Hide and lock the mouse cursor
        Cursor.lockState = CursorLockMode.Locked;
        
        //Get the controller component
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Create a direction vector from the input
        Vector3 direction = new Vector3(move_input_vec.x, 0, move_input_vec.y);

        //Only accelerate if a key is pressed
        if(direction.magnitude > 0.1f)
        {
            //Find the ange that we need for ournew movement direction
            float target_angle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg + cam.transform.eulerAngles.y;

            //Use the target angle to find the direction to move in
            Vector3 move_direction = Quaternion.Euler(0f, target_angle, 0f) * Vector3.forward;
            
            //Add to the velocity 
            velocity += move_direction.normalized * acceleration;
        }

        //Separate the x/z velocity from the y velocity
        Vector2 xz_vel = new Vector2(velocity.x, velocity.z);

        //cap speed for forward/backward movement
        xz_vel = Vector2.ClampMagnitude(xz_vel, max_speed);

        //Friction on forward/backward movement
        if(move_input_vec == Vector2.zero)
        {
            xz_vel = Vector2.MoveTowards(xz_vel, Vector2.zero, friction);
        }

        //Gravity
        velocity.y += gravity;
        if(controller.isGrounded && velocity.y < -2f)
        {
            velocity.y = -2f;
        }

        //Put the velocity back together
        velocity = new Vector3(xz_vel.x, velocity.y, xz_vel.y);

        //Move the player
        controller.Move(velocity * Time.fixedDeltaTime);
    }

    public void CaptureMoveInput(InputAction.CallbackContext context)
    {
        move_input_vec = context.ReadValue<Vector2>();
    }

    public void CaptureJumpInput(InputAction.CallbackContext context)
    {
        if(context.phase == InputActionPhase.Started)
        {
            if(controller.isGrounded)
            {
                velocity.y = jump_power;
            }
        }

    }

}
