using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class UiNav : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject creditsMenu;
    public GameObject settingsMenu;
    public GameObject loadMenu;

    public AudioSource buttonClick;

    public float buttonDelay;

    public void ToCredits()
    {
        buttonClick.Play();
        StartCoroutine (CreditsCO());
    }

    public void ToMenu()
    {
        buttonClick.Play();
        StartCoroutine(MenuCO());
    }

    public void ToSettings()
    {
        buttonClick.Play();
        StartCoroutine(SettingsCO());
    }

    public void QuitGame()
    {
        buttonClick.Play();
        Application.Quit();
    }

    public void ToLoadMenu()
    {
        buttonClick.Play();
        StartCoroutine(LoadCO());
    }

    public void NextSceneG()
    {
        buttonClick.Play();
        StartCoroutine(SceneG());
    }

    public IEnumerator SceneG()
    {
        yield return new WaitForSeconds(buttonDelay);
        SceneManager.LoadScene("Game");
    }


    public IEnumerator CreditsCO()
    {
        yield return new WaitForSeconds(buttonDelay);
        mainMenu.SetActive(false);
        creditsMenu.SetActive(true);
        settingsMenu.SetActive(false);
        loadMenu.SetActive(false);
    }

    public IEnumerator MenuCO()
    {
        yield return new WaitForSeconds(buttonDelay);
        mainMenu.SetActive(true);
        creditsMenu.SetActive(false);
        settingsMenu.SetActive(false);
        loadMenu.SetActive(false);
    }
    public IEnumerator SettingsCO()
    {
        yield return new WaitForSeconds(buttonDelay);
        settingsMenu.SetActive(true);
        creditsMenu.SetActive(false);
        mainMenu.SetActive(false);
        loadMenu.SetActive(false);
    }
    public IEnumerator LoadCO()
    {
        yield return new WaitForSeconds(buttonDelay);
        mainMenu.SetActive(false);
        creditsMenu.SetActive(false);
        settingsMenu.SetActive(false);
        loadMenu.SetActive(true);
    }
}
