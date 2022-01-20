using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SkyCamMove : MonoBehaviour
{
    private float speed;
    private float mousespeed;

    void OnEnable()
    {
        speed = 5;
        mousespeed = 20;
    }

    void Update()
    {
        CameraScroll();
        Move();

    }

    void Move()
    {
        if (transform.localPosition.y < 80 && transform.localPosition.y >= 90)
        {
            speed = 0.1f;
        }
        else if (transform.localPosition.y < 90 && transform.localPosition.y >= 100)
        {
            speed = 2f;
        }
        else if (transform.localPosition.y < 100 && transform.localPosition.y >= 110)
        {
            speed = 5f;
        }
        else if (transform.localPosition.y < 110 && transform.localPosition.y >= 120)
        {
            speed = 50;
        }

        //  Move() øÅEE
        if (Input.GetKey(KeyCode.W))
        {
            transform.localPosition += new Vector3(0.2f, 0, 0.0f) * speed;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.localPosition -= new Vector3(0.2f, 0, 0.0f) * speed;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.localPosition += new Vector3(0.0f, 0, 0.2f) * speed;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.localPosition -= new Vector3(0.0f, 0, 0.2f) * speed;
        }

    }
    void CameraScroll()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel") * mousespeed;

        if (transform.localPosition.y < 77.0f)
        {
            transform.localPosition = new Vector3(transform.localPosition.x, 77f, transform.localPosition.z);
        }
        if (transform.localPosition.y > 120.0f)
        {
            transform.localPosition = new Vector3(transform.localPosition.x, 120.0f, transform.localPosition.z);
        }
        else
        {
            transform.localPosition -= new Vector3(0, scroll, 0);
        }

    }

}