using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState
{
    //State machine will call this when it enters a new state.
    public virtual void Enter(PlayerStateMachine state_machine, Player player)
    {

    }

    //State machine will call this when it leaves the state.
    public virtual void Exit(PlayerStateMachine state_machine, Player player)
    {

    }

    //State machine calls this during the update function.
    public virtual void Update(PlayerStateMachine state_machine, Player player)
    {

    }

    //State machine calls this during its fixed update function.
    public virtual void FixedUpdate(PlayerStateMachine state_machine, Player player)
    {

    }
}
