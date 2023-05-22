using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSounds : MonoBehaviour
{
    // handle the sounds that plays in the main menu
    [SerializeField] AudioSource clickSound;
    [SerializeField] AudioSource testSound;

    public void ClickSound()
    {
        clickSound.Play();
    }

    public void TestSound()
    {
        testSound.Play();
    }
}
