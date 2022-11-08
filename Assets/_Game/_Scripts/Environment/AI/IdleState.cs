using UnityEngine;

public class IdleState : AIBaseState
{
    public override void EnterState(AIStateMachine machine)
    {
        if (!machine.gameObject.activeInHierarchy) return;
        machine.playerAgent.isStopped = true;
        machine.playerAgent.ResetPath();
        machine.GetComponent<IInitializePlayer>().Initialize();
        Debug.Log("AI is idle!");
    }

    public override void UpdateState(AIStateMachine machine)
    {
        if (Input.GetMouseButtonDown(0))
        {
            machine.ChangeState(machine.searchState);
        }
    }
}
