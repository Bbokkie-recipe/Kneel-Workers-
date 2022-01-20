using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingP : MonoBehaviour
{
    public GameObject Player;
    public GameObject canvas;

    void Start()
    {

    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            Player.SetActive(true);
            canvas.SetActive(true);
            Player.GetComponent<PlayerMove>().isStoryState = false;
            gameObject.SetActive(false);
        }
    }
}
