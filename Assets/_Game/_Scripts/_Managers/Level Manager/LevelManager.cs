using UnityEngine;
using System;

public class LevelManager : MonoBehaviour
{
    #region Event
    public static event Action<LevelInfo> OnNormalLevelGenerated;
    public static event Action<LevelInfoAsset> OnTimerLevelGenerated;
    public static event Action<LevelInfoAsset> OnAILevelGenerated;
    #endregion

    #region Variables
    [SerializeField]
    private LevelInfoAsset levelInfoAsset;

    [SerializeField]
    private string levelRecordKey = "Level";
    #endregion

    #region MonoBehaviour Callbacks
    private void OnEnable()
    {
        GameManager.OnGameStateChange += GenerateLevel;
    }
    private void OnDisable()
    {
        GameManager.OnGameStateChange -= GenerateLevel;
    }
    #endregion

    #region Methods

    /// <summary>
    /// Generate level due to selected game type.
    /// </summary>
    /// <param name="type">Selected game type.</param>
    public void GenerateLevel(GameState type)
    {
        switch (type)
        {
            case GameState.Normal:
                Debug.Log("Normal Level Started..");
                GenerateLevelFromImage();
                break;
            case GameState.WithTimer:
                Debug.Log("Timer Level Started..");
                OnTimerLevelGenerated?.Invoke(levelInfoAsset);
                break;
            case GameState.AICompetative:
                Debug.Log("Timer Level Started..");
                OnAILevelGenerated?.Invoke(levelInfoAsset);
                break;
            case GameState.ImageWon:
                IncreaseLevelIndex();
                break;
            default:
                break;
        }
    }

    /// <summary>
    /// Gets the last level and saves it back to PlayerPrefs after increasing it '1'.
    /// </summary>
    public void IncreaseLevelIndex()
    {
        int currentLevel = Recorder.GetRecord(levelRecordKey);
        int newLevel = currentLevel + 1;
        Recorder.Record(levelRecordKey, newLevel);
        Debug.Log("Next Level: " + newLevel);
    }

    /// <summary>
    /// Initializes level according to a image that game will print as cubes.
    /// </summary>
    void GenerateLevelFromImage()
    {
        LevelInfo info = GetCurrentLevelInfo();

        OnNormalLevelGenerated?.Invoke(info);
    }
    LevelInfo GetCurrentLevelInfo()
    {
        int currentLevel = Recorder.GetRecord(levelRecordKey);

        // Logic below will return all the levels until the last unique level.
        // Then it will return first level again. That will cause a loop.
        int infoIndex = currentLevel % levelInfoAsset.levelInfos.Count;
        LevelInfo info = levelInfoAsset.levelInfos[infoIndex];
        return info;
    }
    #endregion
}
