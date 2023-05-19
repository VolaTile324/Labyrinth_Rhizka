using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "Custom Event", menuName = "Custom Assets/Events/Custom Event Invoke")]

public class CustomEvent : MonoBehaviour
{
    public UnityEvent OnInvoked = new UnityEvent();
}
