using TMPro;
using UnityEngine;

public class ScoreSystem : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI highestScoreText;

    void Start()
    {
        GameManager.Instance.ScoreChangeEvent += ScoreChanged;
    }

    private void ScoreChanged()
    {
        scoreText.text = "Score: " + GameManager.Instance.score.ToString();
        highestScoreText.text = "Highest Score: " + GameManager.Instance.highestScore.ToString();
    }
}
