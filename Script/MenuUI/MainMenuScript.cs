using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    [SerializeField]
    AudioSource buttonaudio;
    public void StartButtonPressed()
    {
        buttonaudio.Play();
        Invoke("LoadSceneStart", 2.3f);
    }

    public void QuitButtonPressed()
    {
        Application.Quit();
    }

    void LoadSceneStart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
