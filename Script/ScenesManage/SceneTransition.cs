using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneTransition : MonoBehaviour
{
    [SerializeField]
    public AudioSource NextSceneTrigger;
    [SerializeField]
    public AudioSource BGM;
    int sceneNum = 0;
    void OnEnable()
    {
        sceneNum = SceneManager.GetActiveScene().buildIndex;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            NextSceneTrigger.Play();
            BGM.Stop();
            Debug.Log("SceneNumber: " + sceneNum);
            if(sceneNum == 5)
            {
                if (other.gameObject.GetComponent<PlayerMove>().Shootcount == 1)
                {
                    Invoke("NextScene", .5f);
                }
                else
                {
                    Invoke("EndingScene", .5f);
                }
            }
            else
            {
                Invoke("NextScene", .5f);
            }

        }
    }

    void EndingScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }
    void NextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
