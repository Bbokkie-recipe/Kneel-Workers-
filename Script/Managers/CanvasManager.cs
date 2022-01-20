using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class CanvasManager : MonoBehaviour
{
    public GameManager gameManage;
    public GameObject player;
    public GameObject playerUI;
    public GameObject topDownViewCamera;
    public GameObject topDownUI;
    public GameObject pauseUI;
    public GameObject gameOverUI;
    public GameObject itemSetting;

    public List<GameObject> itemObjectList;
    public GameObject ItemBox;

    private TextMeshProUGUI timerTxt;
    private TextMeshProUGUI doorTxt;
    private TextMeshProUGUI warningTxt;
    private TextMeshProUGUI ammoAmtTxt;

    void Start()
    {
        itemObjectList = new List<GameObject>();
        for(int i = 0; i < 3; i++) 
        {
            itemObjectList.Add(ItemBox.transform.GetChild(i).gameObject);
        }
        for(int i = itemObjectList.Count - 1; i > gameManage.sceneIndexAtZero; i--)
        {
            itemObjectList[i].SetActive(false);
        }

        timerTxt = topDownUI.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>();    
        doorTxt = topDownUI.transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>();    
        warningTxt = topDownUI.transform.GetChild(3).gameObject.GetComponent<TextMeshProUGUI>();
        ammoAmtTxt = playerUI.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>();

    }

    void Update()
    {
        timerTxt.text = gameManage.DisplayTimeString(); 
        doorTxt.text = gameManage.DisplayNumDoorOpenedString();
        warningTxt.text = gameManage.DisplayDoorLimitWarning();
        ammoAmtTxt.text = string.Format("{0:0}/1", player.GetComponent<PlayerMove>().Shootcount);
        for(int i = 0; i < (gameManage.sceneIndexAtZero + 1); i++)
        {
            itemObjectList[i].transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = gameManage.itemListString[i].GetItemAmountString();
        }


        if (Input.GetKeyDown(KeyCode.Return))
        {
            pauseUI.transform.GetChild(1).gameObject.SetActive(false);
            pauseUI.transform.GetChild(0).gameObject.SetActive(true);
            pauseUI.SetActive(!pauseUI.activeSelf);
            if (pauseUI.activeSelf)
            {
                Time.timeScale = 0f;
            }
            else
            {
                Time.timeScale = 1f;
            }
        }

        if (gameManage.tempTime == 0) 
        {
            if (gameOverUI.activeSelf)
            {
                player.SetActive(false);
            }
            else
            {
                player.SetActive(true);
                playerUI.SetActive(true);
                topDownUI.SetActive(false);
                topDownViewCamera.SetActive(false);
                itemSetting.SetActive(false);
            }
        }
        else
        {
            player.SetActive(false);
            playerUI.SetActive(false);
            topDownUI.SetActive(true);
            topDownViewCamera.SetActive(true);
            itemSetting.SetActive(true);
        }

    }


}
