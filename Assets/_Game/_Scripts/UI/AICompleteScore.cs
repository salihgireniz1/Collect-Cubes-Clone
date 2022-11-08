using TMPro;
using UnityEngine;

public class AICompleteScore : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI yourScore;
    [SerializeField]
    TextMeshProUGUI enemyScore;

    private void OnEnable()
    {
        yourScore.text = "Your Score: " + GameManager.Instance.PlayerScore.ToString();
        enemyScore.text = "Enemy Score: " + GameManager.Instance.AIScore.ToString();
    }
}