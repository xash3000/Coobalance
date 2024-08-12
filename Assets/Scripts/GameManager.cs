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

    [SerializeField] private AudioSource mainMusic;
    [SerializeField] private AudioSource gameOverMusic;

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
        if (score < 0) score = 0;
        ScoreChangeEvent?.Invoke();
    }

    public void GameOver()
    {
        gameRunning = false;
        mainMusic.Stop();
        gameOverMusic.Play();
        StartCoroutine(WaitAndShowGameOver());
    }

    IEnumerator WaitAndShowGameOver()
    {
        yield return new WaitForSeconds(1.5f);
        GameOverEvent?.Invoke();
    }
}
