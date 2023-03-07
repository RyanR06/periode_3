using System.Collections;
using System.Collections.Generic;
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
    public Image loadingScreen;

    public float loadingTransition;
    public float loadingDelay;
    public float loadscreenTime;
    public Color loadingColor;
    public bool beginLoading;
    public bool endLoading;

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
                loadingColor.a -= loadingTransition;
            }
        }
    }

    public IEnumerator LoadAndSceneCO()
    {
        beginLoading = true;

        yield return new WaitForSeconds(loadingDelay);
        SceneManager.LoadScene("Game");
        yield return new WaitForSeconds(transitionDelay);

        tempSave = GameObject.Find("TempSave");
        Destroy(tempSave);
        saveAndLoad.playerposition = GameObject.Find("Player").GetComponent<Playerposition>();
        uiNav = GameObject.Find("EventSystem").GetComponent<UiNav>();
        uiNav.saveAndLoad = GameObject.Find("DontDestroy Manager").GetComponent<SaveAndLoad>();
        saveAndLoad.LoadPlayerPos();
        endLoadScreen = GameObject.Find("EventSystem").GetComponent<EndLoadScreen>();
        endLoadScreen.sceneLoad = this;
        StartCoroutine (endLoadScreen.EndTheLoadScreen());
    }

    public IEnumerator ContinueAndSceneCO()
    {
        beginLoading = true;

        yield return new WaitForSeconds(loadingDelay);
        SceneManager.LoadScene("Game");
        yield return new WaitForSeconds(transitionDelay);

        tempSave = GameObject.Find("TempSave");
        Destroy(tempSave);
        saveAndLoad.playerposition = GameObject.Find("Player").GetComponent<Playerposition>();
        uiNav = GameObject.Find("EventSystem").GetComponent<UiNav>();
        uiNav.saveAndLoad = GameObject.Find("DontDestroy Manager").GetComponent<SaveAndLoad>();
        endLoadScreen = GameObject.Find("EventSystem").GetComponent<EndLoadScreen>();
        endLoadScreen.sceneLoad = this;
        StartCoroutine(endLoadScreen.EndTheLoadScreen());
    }


}
