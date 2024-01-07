using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractPlayerState : AbstractState
{
    protected PlayerStateMachine PlayerStateMachine = null;
    protected Animator Animator = null;

    public AbstractPlayerState(PlayerStateMachine PlayerStateMachine, Animator Animator)
    {
        this.PlayerStateMachine = PlayerStateMachine;
        this.Animator = Animator;
    }
    
}
