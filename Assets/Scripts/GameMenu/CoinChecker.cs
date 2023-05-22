using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CoinChecker : MonoBehaviour
{
    public UnityEvent OnBegin = new UnityEvent();

    public void CheckStart()
    {
        OnBegin.Invoke();
    }
}
