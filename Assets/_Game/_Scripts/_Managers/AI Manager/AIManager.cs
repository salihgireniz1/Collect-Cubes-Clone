using UnityEngine;
using UnityEngine.AI;

public class AIManager : MonoBehaviour
{
    [SerializeField]
    private GameObject aiPlayer;
    
    [SerializeField]
    private GameObject aiBase;

    AIStateMachine aiStateMachine;

    private void OnEnable()
    {
        GameManager.OnGameStateChange += HandleObjectActivity;
    }
    private void OnDisable()
    {
        GameManager.OnGameStateChange -= HandleObjectActivity;
    }
    private void Start()
    {
        aiStateMachine = aiPlayer.GetComponent<AIStateMachine>();
    }
    public void HandleObjectActivity(GameState state)
    {
        switch (state)
        {
            case GameState.MainMenu:
                ActivateAIObjects(false);
                break;
            case GameState.AICompetative:
                ActivateAIObjects(true);
                break;
            default:
                aiStateMachine.ChangeState(aiStateMachine.idle);
                break;
        }
    }
    void ActivateAIObjects(bool condition)
    {
        aiBase.SetActive(condition);
        aiPlayer.SetActive(condition);
    }
}
