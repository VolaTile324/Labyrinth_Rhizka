using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CDText : MonoBehaviour
{
    [SerializeField] TMP_Text text;

    public void UpdateText(int value)
    {
        text.text = value.ToString();
    }
}
