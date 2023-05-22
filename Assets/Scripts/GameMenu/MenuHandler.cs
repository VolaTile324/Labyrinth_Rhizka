using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuHandler : MonoBehaviour
{
    public void LoadLevel(string levelName)
    {
        // load the level
        SceneManager.LoadScene(levelName);
    }
}
