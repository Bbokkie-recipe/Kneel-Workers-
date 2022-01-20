using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    float lifetime = 2f;
    void Update()
    {
        transform.Translate(Vector3.forward * 0.5f);
        Debug.Log("ITS FLYING!!!");
        Destroy(gameObject, lifetime);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
            Destroy(other.gameObject);
    }
}
