using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CubeState
{
    //State machine will call this when it enters a new state.
    public virtual void Enter(CubeStateMachine state_machine, GameObject obj)
    {

    }

    //State machine will call this when it leaves the state.
    public virtual void Exit(CubeStateMachine state_machine, GameObject obj)
    {

    }

    //State machine calls this during the update function.
    public virtual void Update(CubeStateMachine state_machine, GameObject obj)
    {

    }

    //State machine calls this during its fixed update function.
    public virtual void FixedUpdate(CubeStateMachine state_machine, GameObject obj)
    {

    }

}
