using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndingCredit : MonoBehaviour
{
    [SerializeField]
    AudioSource endingSource;
    // Start is called before the first frame update
    void Start()
    {
        endingSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        Invoke("MainScene", 13f);
    }

    void MainScene()
    {
        SceneManager.LoadScene(0);
    }
}
