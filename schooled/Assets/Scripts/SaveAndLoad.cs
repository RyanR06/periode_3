using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Xml.Serialization;
using System.IO;
using UnityEngine.LowLevel;

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
    public SceneLoad sceneLoad;
    public XML_SaveData xMLData;

    public Button GameLoadbutton;
    public TextMeshProUGUI LoadText;

    private XML_SaveData _SaveData;


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

        UpdateXMLData();
        SaveData();
        CreateNewSave();
        loadLock.SetMovements();
    }

    public void LoadPlayerPos()
    {
        playerposition.Player.position = playerLoc;
        
        SetPlayerLocation();
        LoadData();
        StartCoroutine(ResumePause());
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

        UpdateXMLData();
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

    public void SaveData()
    {
        StartCoroutine(ResumePause());
        XML_SaveData tempSave = new XML_SaveData();
        tempSave.slot = PlayerPrefs.GetInt("SaveSlot");
        tempSave.playerLoc = playerLoc;

        XmlSerializer serializer = new XmlSerializer(typeof(XML_SaveData));

        using (FileStream stream = new FileStream(Application.persistentDataPath + "/SaveData" +slot + ".xml", FileMode.Create))
        {
            serializer.Serialize(stream, tempSave);
        }
    }

    public void LoadData()
    {
        try
        {
            XmlSerializer serializer = new XmlSerializer(typeof(XML_SaveData));

            using (FileStream stream = new FileStream(Application.persistentDataPath + "/SaveData" + slot + ".xml", FileMode.Open))
            {
                _SaveData = serializer.Deserialize(stream) as XML_SaveData;
            }
        }
        catch
        {
            UpdateXMLData();
            SaveData();
        }
    }

    public XML_SaveData GetSaveData()
    {
        return _SaveData;
    }
    public void CreateNewSave()
    {
        XML_SaveData newsave = new XML_SaveData();
        newsave.playerLoc.x = PlayerPrefs.GetFloat("PlayerPosX" + slot);
        newsave.playerLoc.y = PlayerPrefs.GetFloat("PlayerPosY" + slot);
        newsave.playerLoc.z = PlayerPrefs.GetFloat("PlayerPosZ" + slot);
        newsave.slot = PlayerPrefs.GetInt("SaveSlot");
    }

    public void UpdateXMLData()
    {
        xMLData.slot = PlayerPrefs.GetInt("SaveSlot");
        xMLData.playerLoc.x = PlayerPrefs.GetFloat("PlayerPosX" + slot);
        xMLData.playerLoc.y = PlayerPrefs.GetFloat("PlayerPosY" + slot);
        xMLData.playerLoc.z = PlayerPrefs.GetFloat("PlayerPosZ" + slot);
    }

    public IEnumerator ResumePause()
    {
        if(sceneLoad.dontSetTime == true)
        {

        }
        else
        {
        yield return new WaitForSeconds(1);
        Time.timeScale = 0f;
        }
    }
}
    [System.Serializable]
    public class XML_SaveData
    {
        public int slot;

        public Vector3 playerLoc;
    }
