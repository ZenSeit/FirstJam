using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public void FirstLevel()
    {
        SceneManager.LoadScene("StartLevel");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Winner()
    {
        SceneManager.LoadScene("Winner");
    }
}
