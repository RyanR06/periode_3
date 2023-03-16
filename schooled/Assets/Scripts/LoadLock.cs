using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LoadLock : MonoBehaviour
{
    public Button loadButton1, loadButton2, loadButton3, loadButton4, newGameButton;
    public TextMeshProUGUI saveText1, saveText2, saveText3, saveText4, newGameText;

    public SaveAndLoad saveAndLoad;

    public Vector3 movementPrefs1, movementPrefs2, movementPrefs3, movementPrefs4;

    public Vector3 vector0;

    public Color greyOutColor, normalLoadButtonColor;

    // Start is called before the first frame update
    void Start()
    {
        SetMovements();
        SaveCheck();
        ToSaves();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void SetMovements()
    {
        movementPrefs1.x = PlayerPrefs.GetFloat("PlayerPosX" + 1);
        movementPrefs1.y = PlayerPrefs.GetFloat("PlayerPosY" + 1);
        movementPrefs1.z = PlayerPrefs.GetFloat("PlayerPosZ" + 1);

        movementPrefs2.x = PlayerPrefs.GetFloat("PlayerPosX" + 2);
        movementPrefs2.y = PlayerPrefs.GetFloat("PlayerPosY" + 2);
        movementPrefs2.z = PlayerPrefs.GetFloat("PlayerPosZ" + 2);

        movementPrefs3.x = PlayerPrefs.GetFloat("PlayerPosX" + 3);
        movementPrefs3.y = PlayerPrefs.GetFloat("PlayerPosY" + 3);
        movementPrefs3.z = PlayerPrefs.GetFloat("PlayerPosZ" + 3);

        movementPrefs4.x = PlayerPrefs.GetFloat("PlayerPosX" + 4);
        movementPrefs4.y = PlayerPrefs.GetFloat("PlayerPosY" + 4);
        movementPrefs4.z = PlayerPrefs.GetFloat("PlayerPosZ" + 4);
    }

    public void ToSaves()
    {
        SetMovements();

        if (movementPrefs1 != vector0)
        {
            loadButton1.interactable = true;
            saveText1.color = normalLoadButtonColor;
        }

        if (movementPrefs2 != vector0)
        {
            loadButton2.interactable = true;
            saveText2.color = normalLoadButtonColor;
        }

        if (movementPrefs3 != vector0)
        {
            loadButton3.interactable = true;
            saveText3.color = normalLoadButtonColor;
        }

        if (movementPrefs4 != vector0)
        {
            loadButton4.interactable = true;
            saveText4.color = normalLoadButtonColor;
            newGameButton.interactable = false;
            newGameText.color = greyOutColor;
        }
    }
    public void SaveCheck()
    {
        SetMovements();

        if (movementPrefs1 == vector0)
        {
            loadButton1.interactable = false;
            saveText1.color = greyOutColor;
        }

        if (movementPrefs2 == vector0)
        {
            loadButton2.interactable = false;
            saveText2.color = greyOutColor;
        }

        if (movementPrefs3 == vector0)
        {
            loadButton3.interactable = false;
            saveText3.color = greyOutColor;
        }

        if (movementPrefs4 == vector0)
        {
            loadButton4.interactable = false;
            saveText4.color = greyOutColor;
            newGameButton.interactable = true;
            newGameText.color = normalLoadButtonColor;
        }
    }

    public void NewGameSlotSwapping()
    {
        if (movementPrefs1 != vector0)
        {
            saveAndLoad.slot = 2;
        
            if (movementPrefs2 != vector0)
            {
                saveAndLoad.slot = 3;

                if (movementPrefs3 != vector0)
                {
                    saveAndLoad.slot = 4;
                }

            }
        }
    }
}
