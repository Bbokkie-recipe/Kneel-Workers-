using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTabOn : MonoBehaviour
{
    public GameObject SubCamera;
    int Cameracount = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (Cameracount < 3)
            {
                gameObject.SetActive(false);
                SubCamera.SetActive(true);
                Cameracount++;
            }
        }
        if (Cameracount > 3)
        {
            Destroy(SubCamera);
        }
    }
}
