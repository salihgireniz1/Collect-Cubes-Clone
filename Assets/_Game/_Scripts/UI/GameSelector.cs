using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSelector : MonoBehaviour
{
    public GameState gameType;

    public void SelectGame()
    {
        GameManager.Instance.UpdateGameState(gameType);
    }
}
