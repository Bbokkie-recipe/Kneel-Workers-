using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkerManage : MonoBehaviour
{
    List<GameObject> enemyChild = new List<GameObject>();
    void Start()
    {
        for (int i = 0; i < 10; i++)
        {
            enemyChild.Add(transform.GetChild(i).gameObject);
        }
        Invoke("WorkerCreate", 1f);//디버그시, 뒤의 숫자를 원하는 n초로 바꾸세요.
    }

    void WorkerCreate()
    {
        for (int i = 0; i < enemyChild.Count; i++)
        {
            transform.GetChild(i).gameObject.SetActive(true);
        }
    }
}