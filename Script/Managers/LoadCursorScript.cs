using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadCursorScript : MonoBehaviour
{
    public GameObject player;

    void Update()
    {
        if (player == null || !player.activeSelf) 
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }
}
