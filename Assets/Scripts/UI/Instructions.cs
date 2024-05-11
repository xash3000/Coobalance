using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instructions : MonoBehaviour
{
    [SerializeField] private GameObject panel;

    public void StartButton()
    {
        panel.SetActive(false);
        GameManager.Instance.gameRunning = true;
    }
}
