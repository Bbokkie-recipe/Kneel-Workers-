using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverUIScript : MonoBehaviour
{
    public void RestartButtonPressed()
    {
        GameManager.ResetGame();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void ReturnMainMenuPressed()
    {
        GameManager.ResetGame();
        SceneManager.LoadScene(0);
    }
}

