using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameplaySetting : MonoBehaviour
{
    [SerializeField] Toggle timeSetting;
    [SerializeField] TMP_Text dayLabel;
    [SerializeField] TMP_Text nightLabel;
    [SerializeField] Image dayExample;
    [SerializeField] Image nightExample;
    [SerializeField] TMP_Text bestScoreLabel;

    // called when the panel opened up for the first time
    public void InitialSetting()
    {
        if (PlayerPrefs.HasKey("TimeValue"))
        {
            if (PlayerPrefs.GetInt("TimeValue") == 1)
            {
                timeSetting.isOn = true;
                dayLabel.color = Color.gray;
                nightLabel.color = Color.green;
                nightExample.gameObject.SetActive(true);
                dayExample.gameObject.SetActive(false);
                if (PlayerPrefs.HasKey("BestScoreNight"))
                {
                    bestScoreLabel.text = "Best: " + PlayerPrefs.GetInt("BestScoreNight").ToString();
                }
                else
                {
                    bestScoreLabel.text = "Best: N/A";
                }

                if (PlayerPrefs.GetInt("BestScoreNight") == 0)
                {
                    bestScoreLabel.text = "Best: N/A";
                }
            }
            else
            {
                timeSetting.isOn = false;
                dayLabel.color = Color.green;
                nightLabel.color = Color.gray;
                nightExample.gameObject.SetActive(false);
                dayExample.gameObject.SetActive(true);
                if (PlayerPrefs.HasKey("BestScoreDay"))
                {
                    bestScoreLabel.text = "Best: " + PlayerPrefs.GetInt("BestScoreDay").ToString();
                }
                else
                {
                    bestScoreLabel.text = "Best: N/A";
                }

                if (PlayerPrefs.GetInt("BestScoreDay") == 0)
                {
                    bestScoreLabel.text = "Best: N/A";
                }
            }
        }
        else
        {
            timeSetting.isOn = false;
            dayLabel.color = Color.green;
            nightLabel.color = Color.gray;
            nightExample.gameObject.SetActive(false);
            dayExample.gameObject.SetActive(true);
            bestScoreLabel.text = "Best: N/A";
        }
    }
    
    // on value change, a function to read isOn
    public void SetTime(bool value)
    {
        if (value == true)
        {
            PlayerPrefs.SetInt("TimeValue", 1);
            dayLabel.color = Color.gray;
            nightLabel.color = Color.green;
            nightExample.gameObject.SetActive(true);
            dayExample.gameObject.SetActive(false);
            if (PlayerPrefs.HasKey("BestScoreNight"))
            {
                bestScoreLabel.text = "Best: " + PlayerPrefs.GetInt("BestScoreNight").ToString();
            }
            else
            {
                bestScoreLabel.text = "Best: N/A";
            }

            if (PlayerPrefs.GetInt("BestScoreNight") == 0)
            {
                bestScoreLabel.text = "Best: N/A";
            }
        }
        else
        {
            PlayerPrefs.SetInt("TimeValue", 0);
            dayLabel.color = Color.green;
            nightLabel.color = Color.gray;
            nightExample.gameObject.SetActive(false);
            dayExample.gameObject.SetActive(true);
            if (PlayerPrefs.HasKey("BestScoreDay"))
            {
                bestScoreLabel.text = "Best: " + PlayerPrefs.GetInt("BestScoreDay").ToString();
            }
            else
            {
                bestScoreLabel.text = "Best: N/A";
            }

            if (PlayerPrefs.GetInt("BestScoreDay") == 0)
            {
                bestScoreLabel.text = "Best: N/A";
            }
        }
    }
}
