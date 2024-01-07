using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractState 
{
    public abstract void Enter();
    public abstract void Tick();
    public abstract void FixedTick();
    public abstract void LateTick();
    public abstract void Exit();
}
