using System;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance;
    public event Action GameOverEvent;
    public event Action ScoreChangeEvent;

    public bool gameRunning = false;

    public int score = 0;
    public int highestScore = 0;

    private void Awake()
    {
        if(Instance == null)
            Instance = this;
    }

    public void IncrementScore()
    {
        score++;
        if(score >= highestScore)
        {
            highestScore = score;
        }
        ScoreChangeEvent?.Invoke();
    }

    public void DecrementScore()
    {
        score--;
        ScoreChangeEvent?.Invoke();
    }

    public void GameOver()
    {
        gameRunning = false;
        StartCoroutine(WaitAndShowGameOver());
    }

    IEnumerator WaitAndShowGameOver()
    {
        yield return new WaitForSeconds(1.5f);
        GameOverEvent?.Invoke();
    }
}
