using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GyroSupportCheck : MonoBehaviour
{
    [SerializeField] GameObject warningPanel;
    // Start is called before the first frame update
    void Start()
    {
        if (SystemInfo.supportsGyroscope)
        {
            return;
        }
        else
        {
            warningPanel.SetActive(true);
        }
    }
}
