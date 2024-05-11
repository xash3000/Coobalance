using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    [SerializeField] private GameObject panel;
    [SerializeField] private TextMeshProUGUI highestScore;
    private void Start()
    {
        GameManager.Instance.GameOverEvent += Show;
    }

    private void Show()
    {
        highestScore.text = "Highest Score: " + GameManager.Instance.highestScore.ToString();
        panel.SetActive(true);
    }

    public void RestartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
