using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine : MonoBehaviour
{
    //Reference to the player the state machine is on.
    private Player player;

    //The current state the state machine is in.
    private PlayerState state;

    //States the playert can be in.
    public PlayerStateGround ground_state = new PlayerStateGround();
    public PlayerStateAir air_state = new PlayerStateAir();


    // Start is called before the first frame update
    void Start()
    {
        //Get the player as our object.
        player = GetComponent<Player>();

        //Set the initial state of the state machine.
        state = ground_state;

        //Enter the initial state, setting it up.
        state.Enter(this, player);
    }

    // Update is called once per frame
    void Update()
    {
        state.Update(this, player);
    }

    private void FixedUpdate()
    {
        state.FixedUpdate(this, player);
    }

    public void SwitchState(PlayerState current_state, PlayerState new_state)
    {
        //Exit the current state.
        current_state.Exit(this, player);

        //Change to the new state.
        state = new_state;

        //Enter the new state.
        state.Enter(this, player);
    }
}
