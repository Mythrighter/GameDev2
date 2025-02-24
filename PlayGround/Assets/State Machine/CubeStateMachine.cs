using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeStateMachine : MonoBehaviour
{
    //Reference to the game object the state machine is on.
    private GameObject obj;

    //The current state the state machine is in.
    private CubeState state;

    //States the game object can be in.
    public RedState red_state = new RedState();
    public BlueState blue_state = new BlueState();
    public YellowState yellow_state = new YellowState();
    
    // Start is called before the first frame update
    void Start()
    {
        //Get the cube as our object.
        obj = gameObject;

        //Set the initial state of the state machine.
        state = yellow_state;

        //Enter the initial state, setting it up.
        state.Enter(this, obj);
    }

    // Update is called once per frame
    void Update()
    {
        state.Update(this, obj);
    }

    private void FixedUpdate()
    {
        state.FixedUpdate(this, obj);
    }

    public void SwitchState(CubeState current_state, CubeState new_state)
    {
        //Exit the current state.
        current_state.Exit(this, obj);

        //Change to the new state.
        state = new_state;

        //Enter the new state.
        state.Enter(this, obj);
    }
}

