using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ItemManage
{
    public string name;
    public int currentAmt = 0;
    public int totalAllowed = 2;

    public ItemManage(string _in)
    {
        name = _in;
    }
    public string GetItemAmountString()
    {
        return string.Format("{0:0}/{1:0}", currentAmt, totalAllowed);
    }
    public bool CheckForItemDestroy()
    {
        return currentAmt > 0 && currentAmt <= totalAllowed;
    }
    public bool CheckForItemGenerate()
    {
        return currentAmt >= 0 && currentAmt < totalAllowed;
    }

    public bool CheckForMaxItem()
    {
        return currentAmt == totalAllowed;
    }
}



public class GameManager : MonoBehaviour
{

    public GameObject player;
    public GameObject pauseUI;
    public List<DoorInteract> doorScripts;

    public int sceneIndexAtZero;
    //For CanvasManager item display 
    private int[] topDownTimes = { 20, 30, 40 };
    private int[] doorCloseLimitAmount = { 3, 4, 5};

    public List<ItemManage> itemListString;
    private string warningText;
    private string[] stringArr = { "dieItem", "tieItem", "slowItem" };


    public float tempTime;
    public GameObject oldDoor;
    

    private void OnEnable()
    {
        sceneIndexAtZero = SceneManager.GetActiveScene().buildIndex - 3;
    }

    void Start()
    {
            
        itemListString = new List<ItemManage>();
        for (int i = 0; i < sceneIndexAtZero + 1; i++)
        {
            itemListString.Add(new ItemManage(stringArr[i]));
        }

        //DoorInteract Script Runs as many times as there are doors in the scene, 
        //thus must have odd number of doors so isOpen bool variable does not cancel itself out 
        doorScripts.AddRange(FindObjectsOfType<DoorInteract>());
        if(doorScripts.Count % 2 == 0)
        {
            Instantiate(oldDoor, Vector3.up * 1000f, Quaternion.identity);
        }

        warningText = "Limit reached: cannot close more doors";

        //controls the time of game
        tempTime = topDownTimes[sceneIndexAtZero];
    }

    void CursorControl()
    {
        if(player.activeSelf)
        {
            if(pauseUI.activeSelf)
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
        else
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    void Update()
    {
        CursorControl();

        if (player.activeSelf)
        {
            foreach (DoorInteract door in doorScripts)
            {
                door.SetDoorForFirstPerson();
            }
        }
        else if (IsDoorMaxReached())
        {
            foreach (DoorInteract door in doorScripts)
            {
                door.Pause();
            }
        }
        else
        {
            foreach (DoorInteract door in doorScripts)
            {
                door.Restart();
            }
        }


        if (tempTime > 0)
            tempTime -= Time.deltaTime;
        else
            tempTime = 0;
    }

    public string DisplayDoorLimitWarning()
    {
        if (IsDoorMaxReached())
            return warningText;
        else
            return "";
    }

    public string DisplayTimeString()
    {
        if (tempTime < 0)
        {
            tempTime = 0;
        }

        float minute = Mathf.FloorToInt(tempTime / 60);
        float second = Mathf.FloorToInt(tempTime % 60);
        float milisecond = tempTime % 1 * 1000;
        return string.Format("{0:00}:{1:00}:{2:00}", minute, second, milisecond);
    }
    public string DisplayNumDoorOpenedString()
    {
        int totalClose = GetTotalDoorClosed();
        return string.Format("{0:0}/{1:0}", totalClose, doorCloseLimitAmount[sceneIndexAtZero]);
    }

    public bool IsDoorMaxReached()
    {
        return GetTotalDoorClosed() == doorCloseLimitAmount[sceneIndexAtZero];
    }

    int GetTotalDoorClosed()
    {
        int totalClose = 0;
        foreach (DoorInteract door in doorScripts)
        {
            if (!door.isOpen && totalClose < doorCloseLimitAmount[sceneIndexAtZero])
            {
                totalClose++;
            }
        }
        return totalClose;
    }
    public static void ResetGame()
    {
        Cursor.visible = true;
        Time.timeScale = 1f;
    }

}
