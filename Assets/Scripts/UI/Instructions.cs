using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Instructions : MonoBehaviour
{
    [SerializeField] private GameObject panel;

    public void StartButton()
    {
        panel.SetActive(false);
        GameManager.Instance.gameRunning = true;
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
