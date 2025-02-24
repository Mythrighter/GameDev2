using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueState : CubeState
{
    //State machine will call this when it enters a new state.
    public override void Enter(CubeStateMachine state_machine, GameObject obj)
    {
        obj.GetComponent<Renderer>().material.color = Color.blue;
    }

    //State machine will call this when it leaves the state.
    public override void Exit(CubeStateMachine state_machine, GameObject obj)
    {
        Debug.Log("Exited Blue State");
    }

    //State machine calls this during the update function.
    public override void Update(CubeStateMachine state_machine, GameObject obj)
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            state_machine.SwitchState(this, state_machine.yellow_state);
        }
    }

    //State machine calls this during its fixed update function.
    public override void FixedUpdate(CubeStateMachine state_machine, GameObject obj)
    {

    }
}
