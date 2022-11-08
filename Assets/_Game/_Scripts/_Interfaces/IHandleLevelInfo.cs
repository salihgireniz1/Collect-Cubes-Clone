using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHandleLevelInfo
{
    public LevelInfoAsset LevelInfoAsset { get; }
    LevelInfo GetLevelInfo(int levelIndex);
}
