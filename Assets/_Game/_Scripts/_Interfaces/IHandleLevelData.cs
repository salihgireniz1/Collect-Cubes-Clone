using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHandleLevelData
{
    public int CurrentLevel { get; }
    void SaveLevel();
    int GetCurrentLevel();
    void IncreaseLevel();
}
