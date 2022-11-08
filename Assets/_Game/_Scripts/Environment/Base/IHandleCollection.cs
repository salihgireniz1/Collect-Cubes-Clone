using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

interface IHandleCollection 
{
    int TotalCollection { get; set; }
    TextMeshPro ScoreText { get; }
    void UpdateCollectionScore(int amount);
    void ResetCollectionScore();
}
