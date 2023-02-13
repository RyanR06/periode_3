using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UiNav : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject creditsMenu;

    public void ToCredits()
    {
        mainMenu.SetActive(false);
        creditsMenu.SetActive(true);
    }

    public void ToMenu()
    {
        mainMenu.SetActive(true);
        creditsMenu.SetActive(false);
    }
}
