using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine : MonoBehaviour
{
    public PlayerIdlestate IdleState { get; private set; }
    public PlayerIdlestate MoveState { get; private set; }

    private AbstractPlayerState _currentMoveState = null;

    public void SetMoveState(AbstractPlayerState Newstate)
    {
        _currentMoveState?.Exit();
        _currentMoveState = Newstate;
        _currentMoveState?.Enter();
    }
}
