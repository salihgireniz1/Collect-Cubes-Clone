using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHandleCoinData
{
    public int CoinScore { get; }
    void SaveCoinScore();
    int GetCurrentCoinScore();
    void UpdateCoinScore(int amount);
}
