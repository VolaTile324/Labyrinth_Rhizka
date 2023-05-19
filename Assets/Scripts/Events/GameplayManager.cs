using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameplayManager : MonoBehaviour
{
    [SerializeField] GameObject resultCanvas;
    [SerializeField] TMP_Text resultText;
    [SerializeField] CustomEvent gameOverEvent;
    [SerializeField] CustomEvent gameWinEvent;

    int coin = 100;

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

    public void GameOver()
    {
        resultText.text = "You fell..";
        resultCanvas.SetActive(true);
    }

    public void GameWin()
    {
        resultText.text = "You won!\n Score: " + GetScore();
        resultCanvas.SetActive(true);
    }

    public int GetScore()
    {
        return coin * 10;
    }
}
