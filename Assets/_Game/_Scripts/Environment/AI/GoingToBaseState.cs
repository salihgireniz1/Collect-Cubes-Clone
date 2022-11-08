using UnityEngine;

public class GoingToBaseState : AIBaseState
{
    public override void EnterState(AIStateMachine machine)
    {
        machine.playerAgent.SetDestination(machine.aiBase.position);
    }


    public override void UpdateState(AIStateMachine machine)
    {
        float distanceFromBase = Vector3.Distance(machine.transform.position, machine.aiBase.position);
        if(distanceFromBase < 2f)
        {
            machine.ChangeState(machine.searchState);
        }
    }
}
