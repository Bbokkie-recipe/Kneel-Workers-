using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CpuTrigger : MonoBehaviour
{

    //public GameObject BigExplosion;
    private BoxCollider trigger;
    public GameObject player;
    public GameObject story;
    private bool hasEntered = false; 

    [SerializeField]
    AudioSource triggeraudio;
    void Start()
    {
        trigger = GetComponent<BoxCollider>();
    }
    void Update()
    {
        if (!hasEntered)
        {
            player.GetComponent<PlayerMove>().isStoryState = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        trigger.isTrigger = true;
        Debug.Log("Entered Collision");

        if (!hasEntered)
        {
            triggeraudio.Play();
            player.SetActive(false);
            story.SetActive(true);
            hasEntered = true;
        }
        Debug.Log("Other tag: " + other.gameObject.tag);
        if (other.gameObject.tag == "Bullet")
        {
            Debug.Log("Bullet entered");
            Invoke("NextScene", 0.8f);
        }
    }
    void NextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
