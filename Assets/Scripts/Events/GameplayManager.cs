using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameplayManager : MonoBehaviour
{
    [SerializeField] GameObject firstTimePanel;
    [SerializeField] GameObject resultCanvas;
    [SerializeField] TMP_Text resultText;
    [SerializeField] GameObject nextButton;
    [SerializeField] CalibrateCountdown calibrateCountdown;
    [SerializeField] CustomEvent gameOverEvent;
    [SerializeField] AudioSource gameOverSound;
    [SerializeField] CustomEvent gameWinEvent;
    [SerializeField] AudioSource gameWinSound;

    private void OnEnable()
    {
        gameOverEvent.OnInvoked.AddListener(GameOver);
        gameWinEvent.OnInvoked.AddListener(GameWin);

    }

    private void OnDisable()
    {
        gameOverEvent.OnInvoked.RemoveListener(GameOver);
        gameWinEvent.OnInvoked.RemoveListener(GameWin);
    }

    private void Start()
    {
        if (PlayerPrefs.HasKey("FirstTimeSetup"))
        {
            calibrateCountdown.StartCountdown();
            Time.timeScale = 0f;
        }
        else
        {
            firstTimePanel.SetActive(true);
            Time.timeScale = 0f;
        }
        
    }

    public void CalibrateCompleted()
    {
        PlayerPrefs.SetString("FirstTimeSetup", "done");
        PlayerPrefs.Save();
    }

    public void StartGame()
    {
        Time.timeScale = 1f;
    }

    public void GameOver()
    {
        resultText.text = "You fell..";
        resultCanvas.SetActive(true);
        nextButton.SetActive(false);
        Time.timeScale = 0f;
        gameOverSound.Play();
    }

    public void GameWin()
    {
        resultText.text = "You won!";
        resultCanvas.SetActive(true);
        Time.timeScale = 0f;
        gameWinSound.Play();
    }
}
