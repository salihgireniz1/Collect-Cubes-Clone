using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelInfoAsset", menuName = "Level/Level Info Asset")]
public class LevelInfoAsset : ScriptableObject
{
    public float TimerAsSeconds;
    public FountainInfo levelFountainInfo;
    public List<LevelInfo> levelInfos = new List<LevelInfo>();
}

[System.Serializable]
public struct LevelInfo
{
    public Sprite levelImage;
    public float cubeSize;
}