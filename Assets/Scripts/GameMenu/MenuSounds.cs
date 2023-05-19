using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSounds : MonoBehaviour
{
    // handle the sounds that plays in the main menu
    [SerializeField] AudioManager audioManager;
    [SerializeField] AudioClip bgmMenu;
    [SerializeField] AudioClip clickSound;
    [SerializeField] AudioClip testSound;
    
    // Start is called before the first frame update
    void Start()
    {
        // handle the background music
        audioManager.PlayBGM(bgmMenu);
    }

    public void ClickSound()
    {
        audioManager.PlaySFX(clickSound);
    }

    public void TestSound()
    {
        audioManager.PlaySFX(testSound);
    }
}
