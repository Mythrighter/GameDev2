using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    //Input
    [HideInInspector] public Vector2 move_input_vec = Vector2.zero;

    //Movement variables
    [HideInInspector] public CharacterController controller;
    [HideInInspector] public Vector3 velocity;

    [HideInInspector] public bool wants_to_jump = false;

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
                wants_to_jump = true;
            }
        }

    }

}
