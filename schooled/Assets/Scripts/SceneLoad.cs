using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoad : MonoBehaviour
{
    public float buttonDelay;
    public float transitionDelay;

    public AudioSource buttonClick;
    public SaveAndLoad saveAndLoad;
    public EndLoadScreen endLoadScreen;
    public UiNav uiNav;

    public Canvas loadCanvas;
    public Image loadingScreen;

    public float loadingTransition;
    public float endLoadingTransition;
    public float loadingDelay;
    public float loadscreenTime;
    public Color loadingColor;
    public bool beginLoading;
    public bool endLoading;
    public bool dontSetTime;

    public GameObject loadingGameObjects;
    public Slider progressSlider;
    public TextMeshProUGUI loadingText;
    public string levelLoad;

    public GameObject tempSave;

    public void Start()
    {
        DontDestroyOnLoad(this);
        loadingDelay = 50 * Time.deltaTime * loadscreenTime;
    }
    public void LoadButton()
    {
        buttonClick.Play();
        StartCoroutine(LoadAndSceneCO());
    }

    public void NewGame()
    {
        buttonClick.Play();
        StartCoroutine(ContinueAndSceneCO());
    }

    public void Update()
    {
        loadingScreen.color = loadingColor;

        if (loadingScreen.color.a < 1 && beginLoading)
        {
            loadingColor.a += loadingTransition;
        }
        else
        {
            if (endLoading == true)
            {
                loadingColor.a -= endLoadingTransition;

            }
        }
    }

    public IEnumerator LoadAndSceneCO()
    {
        beginLoading = true;

        StartCoroutine(LoadSceneAsync());
        yield return new WaitForSeconds(transitionDelay);

        tempSave = GameObject.Find("TempSave");
        Destroy(tempSave);
        saveAndLoad.SetPlayerLocation();
        yield return new WaitForSeconds(2);
        saveAndLoad.playerposition = GameObject.Find("Player").GetComponent<Playerposition>();
        uiNav = GameObject.Find("EventSystem").GetComponent<UiNav>();
        uiNav.saveAndLoad = GameObject.Find("DontDestroy Manager").GetComponent<SaveAndLoad>();
        saveAndLoad.LoadPlayerPos();
        endLoadScreen = GameObject.Find("EventSystem").GetComponent<EndLoadScreen>();
        endLoadScreen.sceneLoad = this;
        endLoadScreen.saveAndLoad = GameObject.Find("DontDestroy Manager").GetComponent<SaveAndLoad>();
        saveAndLoad.loadLock = GameObject.Find("EventSystem").GetComponent<LoadLock>();
        StartCoroutine (endLoadScreen.EndTheLoadScreen());
    }

    IEnumerator LoadSceneAsync()
    {
        loadingGameObjects.SetActive(true);
        AsyncOperation op = SceneManager.LoadSceneAsync(levelLoad);
        
        op.allowSceneActivation = false;
        yield return new WaitForSeconds(2);
        op.allowSceneActivation = true;

        while (!op.isDone)
        {
            float progress = Mathf.Clamp01(op.progress / .9f);
            progressSlider.value = progress;
            loadingText.text = progress * 100f + "%";

            yield return null;
        }
        loadingGameObjects.SetActive(false);
    }
    public IEnumerator ContinueAndSceneCO()
    {
        beginLoading = true;

        yield return new WaitForSeconds(loadingDelay);
        StartCoroutine(LoadSceneAsync());
        yield return new WaitForSeconds(transitionDelay);

        tempSave = GameObject.Find("TempSave");
        Destroy(tempSave);
        saveAndLoad.SetPlayerLocation();
        yield return new WaitForSeconds(2);
        saveAndLoad.playerposition = GameObject.Find("Player").GetComponent<Playerposition>();
        uiNav = GameObject.Find("EventSystem").GetComponent<UiNav>();
        uiNav.saveAndLoad = GameObject.Find("DontDestroy Manager").GetComponent<SaveAndLoad>();
        endLoadScreen = GameObject.Find("EventSystem").GetComponent<EndLoadScreen>();
        endLoadScreen.sceneLoad = this;
        endLoadScreen.saveAndLoad = GameObject.Find("DontDestroy Manager").GetComponent<SaveAndLoad>();
        saveAndLoad.loadLock = GameObject.Find("EventSystem").GetComponent<LoadLock>();
        StartCoroutine(endLoadScreen.EndTheLoadScreen());
    }

    
    public IEnumerator ToMainMenuCO()
    {
        beginLoading = true;

        yield return new WaitForSeconds(loadingDelay);
        StartCoroutine(LoadSceneAsync());

        Time.timeScale = 1f;

        yield return new WaitForSeconds(2);
        Destroy(loadCanvas.gameObject);
        Destroy(this.gameObject);
    }
     
}

