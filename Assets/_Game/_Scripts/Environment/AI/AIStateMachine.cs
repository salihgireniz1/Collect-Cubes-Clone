using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class AIStateMachine : MonoBehaviour
{
    public Transform aiBase;
    public NavMeshAgent playerAgent;
    AIBaseState currentState;

    public AIBaseState idle = new IdleState();
    public AIBaseState searchState = new SearchState();
    public AIBaseState goingBaseState = new GoingToBaseState();
    private void Awake()
    {
        playerAgent = GetComponent<NavMeshAgent>();
        ChangeState(idle);
    }
    public void ChangeState(AIBaseState state)
    {
        currentState = state;
        currentState.EnterState(this);
    }
    private void Update()
    {
        currentState.UpdateState(this);
    }
}
