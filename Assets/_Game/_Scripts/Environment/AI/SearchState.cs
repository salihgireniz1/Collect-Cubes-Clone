using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchState : AIBaseState
{
    IGetTarget targetRespond;
    Transform currentTarget;
    Transform tmpTarget;
    public override void EnterState(AIStateMachine machine)
    {
        targetRespond = machine.GetComponent<IGetTarget>();
        currentTarget = null;
        Debug.Log("AI is Search State..");
    }

    public override void UpdateState(AIStateMachine machine)
    {
        tmpTarget = targetRespond.FindTarget(machine.transform);
        if(tmpTarget != null && currentTarget != tmpTarget)
        {
            currentTarget = tmpTarget;
        }

        if(currentTarget != null)
        {
            machine.playerAgent.SetDestination(currentTarget.position);
            float distanceFromTarget = Vector3.Distance(machine.transform.position, currentTarget.position);
            if (distanceFromTarget < 0.75f)
            {
                // Change state as TowardBaseState.
                machine.ChangeState(machine.goingBaseState);
            }
        }
    }
}
