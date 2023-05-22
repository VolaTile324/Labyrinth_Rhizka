using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class LevelTwoCoins : MonoBehaviour
{
    [SerializeField] Image coinOne;
    [SerializeField] Image coinTwo;
    [SerializeField] Image coinThree;
    [SerializeField] Coin coinOneObj;
    [SerializeField] Coin coinTwoObj;
    [SerializeField] Coin coinThreeObj;
    [SerializeField] Image coinOneResult;
    [SerializeField] Image coinTwoResult;
    [SerializeField] Image coinThreeResult;
    [SerializeField] CustomEvent coinOneEvent;
    [SerializeField] CustomEvent coinTwoEvent;
    [SerializeField] CustomEvent coinThreeEvent;
    [SerializeField] CustomEvent gameWinEvent;

    bool coinOneGrabbed;
    bool coinTwoGrabbed;
    bool coinThreeGrabbed;

    private void OnEnable()
    {
        coinOneEvent.OnInvoked.AddListener(GetCoinOne);
        coinTwoEvent.OnInvoked.AddListener(GetCoinTwo);
        coinThreeEvent.OnInvoked.AddListener(GetCoinThree);
        gameWinEvent.OnInvoked.AddListener(CoinResult);
    }

    private void OnDisable()
    {
        coinOneEvent.OnInvoked.RemoveListener(GetCoinOne);
        coinTwoEvent.OnInvoked.RemoveListener(GetCoinTwo);
        coinThreeEvent.OnInvoked.RemoveListener(GetCoinThree);
        gameWinEvent.OnInvoked.AddListener(CoinResult);
    }

    public void CoinCheck()
    {
        if (PlayerPrefs.GetInt("lv2coin1", 0) == 1)
        {
            GetCoinOne();
            coinOneObj.AlreadyCollected();
        }
        if (PlayerPrefs.GetInt("lv2coin2", 0) == 1)
        {
            GetCoinTwo();
            coinTwoObj.AlreadyCollected();
        }
        if (PlayerPrefs.GetInt("lv2coin3", 0) == 1)
        {
            GetCoinThree();
            coinThreeObj.AlreadyCollected();
        }
    }

    public void CoinResult()
    {
        coinOneResult.gameObject.SetActive(true);
        coinTwoResult.gameObject.SetActive(true);
        coinThreeResult.gameObject.SetActive(true);

        if (coinOneGrabbed)
        {
            PlayerPrefs.SetInt("lv2coin1", 1);
            coinOneResult.color = new Color(255, 255, 255, 255);
        }
        if (coinTwoGrabbed)
        {
            PlayerPrefs.SetInt("lv2coin2", 1);
            coinTwoResult.color = new Color(255, 255, 255, 255);
        }
        if (coinThreeGrabbed)
        {
            PlayerPrefs.SetInt("lv2coin3", 1);
            coinThreeResult.color = new Color(255, 255, 255, 255);
        }
        PlayerPrefs.Save();
    }

    public void GetCoinOne()
    {
        coinOne.color = new Color(255, 255, 255, 255);
        coinOneGrabbed = true;
    }

    public void GetCoinTwo()
    {
        coinTwo.color = new Color(255, 255, 255, 255);
        coinTwoGrabbed = true;
    }

    public void GetCoinThree()
    {
        coinThree.color = new Color(255, 255, 255, 255);
        coinThreeGrabbed = true;
    }
}
