using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public void FirstLevel()
    {
        SceneManager.LoadScene("FirstLevel");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
