using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ItemSetting : MonoBehaviour
{
    public GameObject cameraState;
    public GameManager gameManager;
    public List<GameObject> items;
    public Camera skyCam;
    public RaycastHit itemSettingRay;
    Vector3 mousePos, transPos;

    public float temp = 1; // 레이 시작지점 Y횁E기준으로 이동시킬 수치

    private void Start()
    {
        items = new List<GameObject>();
       
        for (int i = 0; i < (gameManager.sceneIndexAtZero + 1); i++)
        {
            items.Add(gameObject.transform.GetChild(i).gameObject);
        }
    }

    void Update()
    {
        //화면에 혖E갋마퓖E?위치
        mousePos = Input.mousePosition;

        //skyCam 기준 마퓖E?위치
        transPos = skyCam.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, (skyCam.transform.position.y - 1)));

        Debug.DrawRay(new Vector3(transPos.x, transPos.y + temp, transPos.z), gameObject.transform.forward * 100f, Color.red);

        // 좌 클릭시 실?E
        if (Input.GetMouseButtonDown(0))
        {
            // 퉩E?무한의 레이를 forward(Z)로 퐗E
            if (Physics.Raycast(new Vector3(transPos.x, transPos.y + temp, transPos.z), transform.forward, out itemSettingRay, Mathf.Infinity))
            {

                Debug.Log("Tagged item: " + itemSettingRay.transform.tag);
                // skyCam ture && collision "tile"
                if (cameraState.gameObject.activeSelf == true && itemSettingRay.transform.tag == "tile")
                {
                    // 레이 충돌지점으로 이동
                    transform.position = new Vector3(transPos.x, transPos.y + temp, transPos.z);

                }
            }
        }

        foreach (ItemManage item in gameManager.itemListString)
        {
            if (items.Count == 1)
            {
                if (Input.GetKeyDown(KeyCode.Alpha1))
                {
                    if(item.name == items[0].name && !item.CheckForMaxItem())
                    {
                        items[0].SetActive(!items[0].activeSelf);
                    }

                }

            }
            if (items.Count == 2)
            {
                if (Input.GetKeyDown(KeyCode.Alpha1))
                {
                    if(item.name == items[0].name && !item.CheckForMaxItem())
                    {
                        items[0].SetActive(!items[0].activeSelf);
                        items[1].SetActive(false);
                    }

                }
                if (Input.GetKeyDown(KeyCode.Alpha2))
                {
                    if (item.name == items[1].name && !item.CheckForMaxItem())
                    {
                        items[0].SetActive(false);
                        items[1].SetActive(!items[1].activeSelf);
                    }
                }

            }
            if (items.Count == 3)
            {
                if (Input.GetKeyDown(KeyCode.Alpha1))
                {
                    if (item.name == items[0].name && !item.CheckForMaxItem())
                    {
                        items[0].SetActive(!items[0].activeSelf);
                        items[1].SetActive(false);
                        items[2].SetActive(false);
                    }
                }
                if (Input.GetKeyDown(KeyCode.Alpha2))
                {
                    if (item.name == items[1].name && !item.CheckForMaxItem())
                    {
                        items[0].SetActive(false);
                        items[1].SetActive(!items[1].activeSelf);
                        items[2].SetActive(false);
                    }
                }
                if (Input.GetKeyDown(KeyCode.Alpha3))
                {
                    if (item.name == items[2].name && !item.CheckForMaxItem())
                    {
                        items[0].SetActive(false);
                        items[1].SetActive(false);
                        items[2].SetActive(!items[2].activeSelf);
                    }

                }

            }
        }

        //스페이스바 누르툈E
        if (Input.GetKeyDown(KeyCode.Space))
        {
            foreach (ItemManage itemT in gameManager.itemListString)
            {
                
                if (itemSettingRay.transform.tag == "dieItem" || itemSettingRay.transform.tag == "tieItem" || itemSettingRay.transform.tag == "slowItem")
                {
                    if (itemSettingRay.transform.tag == itemT.name)
                    {
                        if (itemT.CheckForItemDestroy())
                        {
                            Destroy(itemSettingRay.transform.gameObject);
                            itemT.currentAmt--;

                        }
                    }

                }
                else
                {
                    for (int i = 0; i < items.Count; i++)
                    {
                        if (items[i].activeSelf && items[i].name == itemT.name)
                        {
                           
                            if (itemSettingRay.transform.tag == "tile")
                            {

                                if (itemT.CheckForItemGenerate())
                                {
                                    Instantiate(items[i], itemSettingRay.transform.position + Vector3.up * 0.7f, Quaternion.identity);
                                    if (items.Count == 1)
                                    {
                                        items[0].SetActive(false);
                                    }
                                    if (items.Count == 2)
                                    {
                                        items[0].SetActive(false);
                                        items[1].SetActive(false);
                                    }
                                    if (items.Count == 3)
                                    {
                                        items[0].SetActive(false);
                                        items[1].SetActive(false);
                                        items[2].SetActive(false);
                                    }
                                    itemT.currentAmt++;

                                }
                            }

                        }
                    }
                }
            }
        }
        //skyCam 비활성화 되툈Esetting도 비활성화
        if (!cameraState.gameObject.activeSelf)
        {
            transform.gameObject.SetActive(false);
        }
    }
}

