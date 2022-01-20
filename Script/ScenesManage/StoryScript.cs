using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StoryScript : MonoBehaviour
{

    [SerializeField]
    AudioSource skipaudio;
    void Start()
    {
    }
    public void SkipButtonPressed()
    {
        skipaudio.Play();
        Invoke("GameScene", 1f);
        
    }
    void GameScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
