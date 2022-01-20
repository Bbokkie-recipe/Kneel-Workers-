using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletShot : MonoBehaviour
{
    public GameObject Bullet;
    int Bulletcount = 0;

    [SerializeField]
    AudioSource shootaudio;

    void Update()
    {
        if (Time.timeScale == 1f)
        {
            if (Bulletcount < 1)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    Instantiate(Bullet, transform.position, transform.rotation);
                    shootaudio.Play();
                    Bulletcount++;
                }
            }
        }
    }
}
