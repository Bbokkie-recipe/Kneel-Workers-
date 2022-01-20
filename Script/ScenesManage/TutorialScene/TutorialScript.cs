using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialScript : MonoBehaviour
{
    public List<GameObject> images;
    private int counter = 0;

    [SerializeField]
    AudioSource Nextaudio;
    private void Start()
    {
        images = new List<GameObject>();
        for (int i = 0; i < 3; i++)
        {
            Debug.Log("i: " + i);
            images.Add(gameObject.transform.GetChild(i).gameObject);
        }
    }

    public void NextPressed()
    {
        counter++;
        if (counter >= 3)
        {
            Nextaudio.Play();
            Invoke("LoadSceneGame", 1f);
        }
        else
        {
            images[counter].SetActive(false);
            images[counter].SetActive(true);
        }
    }
    public void PreviousPressed()
    {
        images[counter].SetActive(false);
        counter--;
        images[counter].SetActive(true);
    }

    void LoadSceneGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
