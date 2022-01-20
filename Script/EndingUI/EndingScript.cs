using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndingScript : MonoBehaviour
{
    public void MainMenuPressed()
    {
        SceneManager.LoadScene(0);
    }
}
