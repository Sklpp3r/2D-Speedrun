using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdlestate : AbstractPlayerState
{
    public PlayerIdlestate(PlayerStateMachine PlayerStateMachine, Animator Animator) : base(PlayerStateMachine, Animator)
    {
    }

    public override void Enter()
    {
    }

    public override void Tick()
    {
        if (Input.GetAxisRaw("Horizontal").Equals(0.00f))
        {
            return;

            PlayerStateMachine.SetMoveState(PlayerStateMachine.MoveState);
        }
    }

    public override void Exit()
    {
    }

    public override void FixedTick()
    {
    }

    public override void LateTick()
    {
    }

}
