using UnityEngine;
public abstract class AIBaseState
{
    public abstract void EnterState(AIStateMachine machine);
    public abstract void UpdateState(AIStateMachine machine);
}
