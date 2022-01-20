using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootEnd : MonoBehaviour
{
 int bulletcount = 0;
    public GameObject player;

    [SerializeField]
    AudioSource triggeraudio;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale == 1f)
        {
            if (bulletcount < 1)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    Invoke("EndingCredit", 0.8f);
                }
            }
        }
    }
    void EndingCredit()
    {
        triggeraudio.Stop();
        player.SetActive(false);
    }
}
