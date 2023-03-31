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
    public GameObject pauseMenu1;
    public GameObject controlsMenu;

    public AudioSource buttonClick;
    public SaveAndLoad saveAndLoad;
    public SceneLoad sceneLoad;
    public PauseMenu pauseMenu;
    public LoadLock loadLock;

    public bool EnableDev;

    public float buttonDelay;
    public float transitionDelay;

    public TextMeshProUGUI pressESCText;
    private bool hasPressedESC;

    public KeyCode pauseKey;

    public void Update()
    {
     if(Input.GetKeyDown(KeyCode.Escape) && hasPressedESC == false)
        {
            hasPressedESC = true;
            pressESCText.gameObject.SetActive(false);
        }   
    }

    public void SaveGame()
    {
        buttonClick.Play();
        SaveCO();
    }

    public void LoadButtonInGame()
    {
        Time.timeScale = 1f;
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
    public void ToControls()
    {
        buttonClick.Play();
        StartCoroutine(ControlsCO());
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
 
    public void ToMainMenu()
    {
        buttonClick.Play();
        StartCoroutine(MainMenuCO());
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
        pauseMenu1.SetActive(false);
        pauseMenu.ContinueOrStop();
    }

    public IEnumerator ToPauseCO()
    {
        Time.timeScale = 1f;
        yield return new WaitForSeconds(buttonDelay);
        pauseMenu1.SetActive(true);
        creditsMenu.SetActive(false);
        settingsMenu.SetActive(false);
        Time.timeScale = 0f;
    }
    public IEnumerator LeavePause()
    {
        yield return new WaitForSeconds(buttonDelay);
        pauseMenu1.SetActive(false);
        creditsMenu.SetActive(false);
        settingsMenu.SetActive(false);
    }

    public IEnumerator QuitGameCO()
    {
        Time.timeScale = 1f;
        yield return new WaitForSeconds(buttonDelay);
        Application.Quit();
        Debug.Log("Quit the application");
    }

    public IEnumerator SceneG()
    {
        yield return new WaitForSeconds(buttonDelay);
        SceneManager.LoadScene("Game");
    }

    public void SaveCO()
    {
        Time.timeScale = 1f;
        //yield return new WaitForSeconds(buttonDelay);
        saveAndLoad.SavePlayerPos();
    }
   
    public IEnumerator LoadCO()
    {
        Time.timeScale = 1f;
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
        pauseMenu1.SetActive(false);
    }


    public IEnumerator MenuCO()
    {
        Time.timeScale = 1f;
        yield return new WaitForSeconds(buttonDelay);
        mainMenu.SetActive(true);
        creditsMenu.SetActive(false);
        settingsMenu.SetActive(false);
        loadMenu.SetActive(false);
        Time.timeScale = 0f;
    }
    public IEnumerator SettingsCO()
    {
        Time.timeScale = 1f;
        yield return new WaitForSeconds(buttonDelay);
        settingsMenu.SetActive(true);
        creditsMenu.SetActive(false);
        mainMenu.SetActive(false);
        loadMenu.SetActive(false);
        pauseMenu1.SetActive(false);
        controlsMenu.SetActive(false);
        Time.timeScale = 0f;
    }
    public IEnumerator ControlsCO()
    {
        Time.timeScale = 1f;
        yield return new WaitForSeconds(buttonDelay);
        settingsMenu.SetActive(false);
        controlsMenu.SetActive(true);
        Time.timeScale = 0f;
    }
    public IEnumerator LoadMenuCO()
    {
        yield return new WaitForSeconds(buttonDelay);
        mainMenu.SetActive(false);
        creditsMenu.SetActive(false);
        settingsMenu.SetActive(false);
        loadMenu.SetActive(true);
    }

    public IEnumerator MainMenuCO()
    {
        Time.timeScale = 1f;
        sceneLoad = GameObject.Find("DontDestroy Manager").GetComponent<SceneLoad>();
        yield return new WaitForSeconds(buttonDelay);
        sceneLoad.levelLoad = "main";
        StartCoroutine(sceneLoad.ToMainMenuCO());


    }
}
