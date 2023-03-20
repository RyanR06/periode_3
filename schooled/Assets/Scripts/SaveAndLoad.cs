using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SaveAndLoad : MonoBehaviour
{
    public Playerposition playerposition;

    public float playerPrefX;
    public float playerPrefY;
    public float playerPrefZ;

    public Vector3 Adminpos;
    public Vector3 playerLoc;

    public int slot;

    public LoadLock loadLock;

    public Button GameLoadbutton;
    public TextMeshProUGUI LoadText;

    public void Start()
    {
        slot = PlayerPrefs.GetInt("SaveSlot");

        if (slot == 0)
        {
            slot++;
        }
    }

    public void Slot1()
    {
        slot = 1;
    }

    public void Slot2()
    {
        slot = 2;
    }

    public void Slot3()
    {
        slot = 3;
    }

    public void Slot4()
    {
        slot = 4;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F2))
        {
            SetSavePrefs();
        }
    }

    public void SavePlayerPos()
    {
        playerposition.PlayerPosXYZ();

        playerLoc.x = PlayerPrefs.GetFloat("PlayerPosX" + slot);
        playerLoc.y = PlayerPrefs.GetFloat("PlayerPosY" + slot);
        playerLoc.z = PlayerPrefs.GetFloat("PlayerPosZ" + slot);

        PlayerPrefs.SetFloat("PlayerPosX" + slot, playerposition.playerPosx);
        PlayerPrefs.SetFloat("PlayerPosY" + slot, playerposition.playerPosy);
        PlayerPrefs.SetFloat("PlayerPosZ" + slot, playerposition.playerPosz);
        PlayerPrefs.SetInt("SaveSlot", slot);
        
        loadLock.SetMovements();
    }

    public void LoadPlayerPos()
    {
        SetPlayerLocation();

        playerposition.Player.position = playerLoc;
    }

    public void SetSavePrefs()
    {
        PlayerPrefs.SetFloat("PlayerPosX" + 1, Adminpos.x);
        PlayerPrefs.SetFloat("PlayerPosY" + 1, Adminpos.y);
        PlayerPrefs.SetFloat("PlayerPosZ" + 1, Adminpos.z);

        PlayerPrefs.SetFloat("PlayerPosX" + 2, Adminpos.x);
        PlayerPrefs.SetFloat("PlayerPosY" + 2, Adminpos.y);
        PlayerPrefs.SetFloat("PlayerPosZ" + 2, Adminpos.z);

        PlayerPrefs.SetFloat("PlayerPosX" + 3, Adminpos.x);
        PlayerPrefs.SetFloat("PlayerPosY" + 3, Adminpos.y);
        PlayerPrefs.SetFloat("PlayerPosZ" + 3, Adminpos.z);

        PlayerPrefs.SetFloat("PlayerPosX" + 4, Adminpos.x);
        PlayerPrefs.SetFloat("PlayerPosY" + 4, Adminpos.y);
        PlayerPrefs.SetFloat("PlayerPosZ" + 4, Adminpos.z);

        loadLock.SetMovements();
        loadLock.SaveCheck();
        loadLock.ToSaves();
        Debug.Log("SetAdminprefs");
    }

    public void SetPlayerLocation()
    {
        playerLoc.x = PlayerPrefs.GetFloat("PlayerPosX" + slot);
        playerLoc.y = PlayerPrefs.GetFloat("PlayerPosY" + slot);
        playerLoc.z = PlayerPrefs.GetFloat("PlayerPosZ" + slot);
    }

    public void SetButtonAndText()
    {
        GameLoadbutton = GameObject.Find("LoadButton").GetComponent<Button>();
        LoadText = GameObject.Find("LoadText1").GetComponent<TextMeshProUGUI>();
    }
}
