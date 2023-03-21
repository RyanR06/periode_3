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
    public GameObject PauseMenu;

    public AudioSource buttonClick;
    public SaveAndLoad saveAndLoad;
    public SceneLoad sceneLoad;
    public PauseMenu pauseMenu;
    public LoadLock loadLock;

    public bool EnableDev;

    public float buttonDelay;
    public float transitionDelay;

    public KeyCode pauseKey;

    public void SaveGame()
    {
        buttonClick.Play();
        StartCoroutine(SaveCO());
    }

    public void LoadButtonInGame()
    {
        buttonClick.Play();
        StartCoroutine(LoadCO());
    }

    public void ToCredits()
    {
        buttonClick.Play();
        StartCoroutine (CreditsCO());
    }

    public void Topause()
    {
        buttonClick.Play();
        StartCoroutine(ToPauseCO());
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
        StartCoroutine(QuitGameCO());
    }

    public void ToLoadMenu()
    {
        buttonClick.Play();
        StartCoroutine(LoadMenuCO());
    }

    public void NextSceneG()
    {
        buttonClick.Play();
        StartCoroutine(sceneLoad.ContinueAndSceneCO());
    }

    public void Continue()
    {
        buttonClick.Play();
        StartCoroutine(ContinueCO());
        pauseMenu.uiDisabled = true;
    }
    public void ClearPlayerPrefs()
    {
        buttonClick.Play();
        StartCoroutine(ClearPrefs());
    }
    public IEnumerator ClearPrefs()
    {
        yield return new WaitForSeconds(buttonDelay);
        PlayerPrefs.DeleteAll();
        loadLock.SetMovements();

        loadLock.SaveCheck();

        saveAndLoad.slot = 1;
        yield return new WaitForSeconds(0.5f);
        PlayerPrefs.SetInt("SaveSlot", saveAndLoad.slot);

        if (EnableDev)
        {
            Debug.Log("ClearedPrefs");
        }
    }
    public IEnumerator ContinueCO()
    {
        yield return new WaitForSeconds(buttonDelay);
        PauseMenu.SetActive(false);
    }

    public IEnumerator ToPauseCO()
    {
        yield return new WaitForSeconds(buttonDelay);
        PauseMenu.SetActive(true);
        creditsMenu.SetActive(false);
        settingsMenu.SetActive(false);
    }
    public IEnumerator LeavePause()
    {
        yield return new WaitForSeconds(buttonDelay);
        PauseMenu.SetActive(false);
        creditsMenu.SetActive(false);
        settingsMenu.SetActive(false);
    }

    public IEnumerator QuitGameCO()
    {
        yield return new WaitForSeconds(buttonDelay);
        Application.Quit();
        Debug.Log("Quit the application");
    }

    public IEnumerator SceneG()
    {
        yield return new WaitForSeconds(buttonDelay);
        SceneManager.LoadScene("Game");
    }

    public IEnumerator SaveCO()
    {
        yield return new WaitForSeconds(buttonDelay);
        saveAndLoad.SavePlayerPos();
    }
   
    public IEnumerator LoadCO()
    {
        yield return new WaitForSeconds(buttonDelay);
        saveAndLoad.LoadPlayerPos();
    }

    public IEnumerator CreditsCO()
    {
        yield return new WaitForSeconds(buttonDelay);
        mainMenu.SetActive(false);
        creditsMenu.SetActive(true);
        settingsMenu.SetActive(false);
        loadMenu.SetActive(false);
        PauseMenu.SetActive(false);
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
        PauseMenu.SetActive(false);
    }
    public IEnumerator LoadMenuCO()
    {
        yield return new WaitForSeconds(buttonDelay);
        mainMenu.SetActive(false);
        creditsMenu.SetActive(false);
        settingsMenu.SetActive(false);
        loadMenu.SetActive(true);
    }
}
