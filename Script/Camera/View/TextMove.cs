using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextMove : MonoBehaviour
{
    public float speed;
    void Update()
    {
        transform.Translate(Vector2.up * speed);
      //  Destroy(gameObject,25f);
    }
}
