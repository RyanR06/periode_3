using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LoadLock : MonoBehaviour
{
    public Button loadButton;
    public TextMeshProUGUI saveText;

    public SaveAndLoad saveAndLoad;

    public Vector3 movementPrefs;

    public Vector3 vector0;

    public Color greyOutColor;

    // Start is called before the first frame update
    void Start()
    {
        movementPrefs.x = PlayerPrefs.GetFloat("PlayerPosX");
        movementPrefs.y = PlayerPrefs.GetFloat("PlayerPosY");
        movementPrefs.z = PlayerPrefs.GetFloat("PlayerPosZ");
    }

    // Update is called once per frame
    void Update()
    {
        if (movementPrefs == vector0)
        {
            loadButton.interactable = false;
            saveText.color = greyOutColor;   

        }
    }
}
