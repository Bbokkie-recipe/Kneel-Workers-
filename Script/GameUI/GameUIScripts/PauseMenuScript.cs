using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuScript : MonoBehaviour
{

    public void RestartButtonPressed()
    {
        GameManager.ResetGame();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    
    public void ReturnToGameButtonPressed()
    {
        Time.timeScale = 1f;
    }

    public void ReturnMenuButtonPressed()
    {
        GameManager.ResetGame();
        SceneManager.LoadScene(0);
    }


}
