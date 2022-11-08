using UnityEngine;
using System;
using Sirenix.OdinInspector;
public enum PlayerType
{
    NormalPlayer,
    AI
}
public enum GameState
{
    MainMenu,
    Normal,
    WithTimer,
    AICompetative,
    WholePartsCollected,
    ImageWon,
    TimerWon,
    AIWon,
    Fail
}
public class GameManager : MonoSingleton<GameManager>
{
    public static event Action<GameState> OnGameStateChange;

    public GameState GameState
    {
        get => gameState;
        set
        {
            gameState = value;
            OnGameStateChange?.Invoke(gameState);
        }
    }
    public int PlayerScore => playerScore;
    public int AIScore => aiScore;


    [SerializeField]
    private string highScoreKey = "HighScore";

    [SerializeField]
    private int playerScore;
    [SerializeField]
    private int aiScore;


    private GameState gameState;

    private void Start()
    {
        UpdateGameState(GameState.MainMenu);
    }

    [Button("Test Game Selection")]
    public void UpdateGameState(GameState state)
    {
        GameState = state;
    }
    public int GetHighScore()
    {
        return Recorder.GetRecord(highScoreKey);
    }
    public void ResetLastScores()
    {
        playerScore = 0;
        aiScore = 0;
    }
    public void HandleScores(PlayerType playerType, int playerCollected)
    {
        switch (GameState)
        {
            case GameState.Normal:
                int targetAmount = Printer.ActiveObjects.Count;
                Debug.Log(playerCollected + "/" + targetAmount);
                if (playerCollected >= targetAmount)
                {
                    UpdateGameState(GameState.ImageWon);
                    ObjectPooler.ResetQueue();
                }
                break;
            case GameState.WithTimer:
                playerScore = playerCollected;
                HandleHighScore(playerScore);
                break;
            case GameState.AICompetative:
                switch (playerType)
                {
                    case PlayerType.NormalPlayer:
                        playerScore = playerCollected;
                        break;
                    case PlayerType.AI:
                        aiScore = playerCollected;
                        break;
                }
                break;
        }
    }
    public void HandleImageLevelDone(int playerCollected)
    {
        int targetAmount = Printer.ActiveObjects.Count;
        if (playerCollected >= targetAmount)
        {
            UpdateGameState(GameState.ImageWon);
        }
    }

    public void HandleHighScore(int playerCollected)
    {
        if (playerCollected > Recorder.GetRecord(highScoreKey))
        {
            Recorder.Record(highScoreKey, playerCollected);
        }
    }
    public void HandleTimeOut()
    {
        switch (gameState)
        {
            case GameState.WithTimer:
                UpdateGameState(GameState.TimerWon);
                break;
            case GameState.AICompetative:
                if(aiScore < playerScore) UpdateGameState(GameState.AIWon);
                else UpdateGameState(GameState.Fail);
                break;
            default:
                break;
        }
    }
}