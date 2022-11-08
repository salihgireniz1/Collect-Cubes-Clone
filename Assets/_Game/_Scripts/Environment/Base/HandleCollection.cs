using System;
using TMPro;
using UnityEngine;

public class HandleCollection : MonoBehaviour, IHandleCollection
{
    public int TotalCollection
    {
        get => totalCollection;
        set
        {
            totalCollection = value;
            ScoreText.text = totalCollection.ToString();
        }
    }

    public TextMeshPro ScoreText => scoreText;

    public PlayerType playerType = PlayerType.NormalPlayer;

    [SerializeField]
    private int totalCollection;

    [SerializeField]
    private TextMeshPro scoreText;
    public void UpdateCollectionScore(int amount)
    {
        TotalCollection += amount;
        GameManager.Instance.HandleScores(playerType, TotalCollection);
    }
    public void ResetCollectionScore()
    {
        TotalCollection = 0;
        GameManager.Instance.ResetLastScores();
    }
}
