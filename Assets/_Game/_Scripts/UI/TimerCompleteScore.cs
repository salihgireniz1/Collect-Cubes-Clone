using TMPro;
using UnityEngine;

public class TimerCompleteScore : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI scoreText;
    [SerializeField]
    private TextMeshProUGUI highScoreText;

    private void OnEnable()
    {
        scoreText.text = "Collected: " + GameManager.Instance.PlayerScore.ToString();
        highScoreText.text = "HIGHSCORE: " + GameManager.Instance.GetHighScore().ToString();
    }
}
