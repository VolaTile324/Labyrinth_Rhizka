using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class LevelOneStat : MonoBehaviour
{
    [SerializeField] Image coinOne;
    [SerializeField] Image coinTwo;
    [SerializeField] Image coinThree;

    public void CoinCheck()
    {
        if (PlayerPrefs.GetInt("lv1coin1", 0) == 1)
        {
            GetCoinOne();
        }
        if (PlayerPrefs.GetInt("lv1coin2", 0) == 1)
        {
            GetCoinTwo();
        }
        if (PlayerPrefs.GetInt("lv1coin3", 0) == 1)
        {
            GetCoinThree();
        }
    }

    public void GetCoinOne()
    {
        coinOne.color = new Color(255, 255, 255, 255);
    }

    public void GetCoinTwo()
    {
        coinTwo.color = new Color(255, 255, 255, 255);
    }

    public void GetCoinThree()
    {
        coinThree.color = new Color(255, 255, 255, 255);
    }
}
