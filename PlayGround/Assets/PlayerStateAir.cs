using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.XR;

public class PlayerStateAir : PlayerState
{
    public float air_max_speed = 20f;
    public float air_acceleration = 0.5f;
    public float air_friction = 0.25f;

    public float gravity = -1f;

    //State machine will call this when it enters a new state.
    public override void Enter(PlayerStateMachine state_machine, Player player)
    {

    }

    //State machine will call this when it leaves the state.
    public override void Exit(PlayerStateMachine state_machine, Player player)
    {

    }

    //State machine calls this during the update function.
    public override void Update(PlayerStateMachine state_machine, Player player)
    {

    }

    //State machine calls this during its fixed update function.
    public override void FixedUpdate(PlayerStateMachine state_machine, Player player)
    {
        //Create a direction vector from the input
        Vector3 direction = new Vector3(player.move_input_vec.x, 0, player.move_input_vec.y);

        //Only accelerate if a key is pressed
        if (direction.magnitude > 0.1f)
        {
            //Find the ange that we need for ournew movement direction
            float target_angle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg + player.cam.transform.eulerAngles.y;

            //Use the target angle to find the direction to move in
            Vector3 move_direction = Quaternion.Euler(0f, target_angle, 0f) * Vector3.forward;

            //Add to the velocity 
            player.velocity += move_direction.normalized * air_acceleration;
        }

        //Separate the x/z velocity from the y velocity
        Vector2 xz_vel = new Vector2(player.velocity.x, player.velocity.z);

        //cap speed for forward/backward movement
        xz_vel = Vector2.ClampMagnitude(xz_vel, air_max_speed);

        //Friction on forward/backward movement
        if (player.move_input_vec == Vector2.zero)
        {
            xz_vel = Vector2.MoveTowards(xz_vel, Vector2.zero, air_friction);
        }

        //Gravity
        player.velocity.y += gravity;


        //Put the velocity back together
        player.velocity = new Vector3(xz_vel.x, player.velocity.y, xz_vel.y);

        //Move the player
        player.controller.Move(player.velocity * Time.fixedDeltaTime);

        //Switch states.
        if (player.controller.isGrounded)
        {
            state_machine.SwitchState(this, state_machine.ground_state);
        }
    }
}
