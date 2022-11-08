using UnityEngine;

[RequireComponent(typeof(IHandleMovement))]
[RequireComponent(typeof(IInitializePlayer))]
public class Player : MonoBehaviour
{
    IHandleMovement movementRespond;
    IInitializePlayer playerInitRespond;

    private void Awake()
    {
        movementRespond = GetComponent<IHandleMovement>();
        playerInitRespond = GetComponent<IInitializePlayer>();
    }
    private void OnEnable()
    {
        GameManager.OnGameStateChange += ChangeMovementAbility;
    }
    private void OnDisable()
    {
        GameManager.OnGameStateChange -= ChangeMovementAbility;
    }
    private void FixedUpdate()
    {
        movementRespond.Move();
    }
    public void ChangeMovementAbility(GameState state)
    {
        switch (state)
        {
            case GameState.Normal:
                movementRespond.CanMove = true;
                playerInitRespond.Initialize();
                break;
            case GameState.WithTimer:
                movementRespond.CanMove = true;
                playerInitRespond.Initialize();
                break;
            case GameState.AICompetative:
                movementRespond.CanMove = true;
                playerInitRespond.Initialize();
                break;
            default:
                movementRespond.CanMove = false;
                break;
        }
    }
}
