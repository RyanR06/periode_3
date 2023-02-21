using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoad : MonoBehaviour
{
    public float buttonDelay;
    public float transitionDelay;

    public AudioSource buttonClick;
    public SaveAndLoad saveAndLoad;
    public UiNav uiNav;

    public void Start()
    {
        DontDestroyOnLoad(this);
    }
    public void LoadButton()
    {
        buttonClick.Play();
        StartCoroutine(LoadAndSceneCO());
    }

    public IEnumerator LoadAndSceneCO()
    {
        yield return new WaitForSeconds(buttonDelay);
        SceneManager.LoadScene("Game");
        yield return new WaitForSeconds(transitionDelay);
        saveAndLoad.playerposition = GameObject.Find("Player").GetComponent<Playerposition>();
        uiNav = GameObject.Find("EventSystem").GetComponent<UiNav>();
        yield return new WaitForSeconds(transitionDelay);
        uiNav.saveAndLoad = GameObject.Find("DontDestroy Manager").GetComponent<SaveAndLoad>();
        yield return new WaitForSeconds(transitionDelay);
        saveAndLoad.LoadPlayerPos();
    }


}
