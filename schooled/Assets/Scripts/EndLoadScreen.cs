using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EndLoadScreen : MonoBehaviour
{
    public SceneLoad sceneLoad;
    public LoadLock loadLock;
    public SaveAndLoad saveAndLoad;

    public bool sceneTesting;

    public void Start()
    {
        if (!sceneTesting)
        {
            loadLock.saveAndLoad = GameObject.Find("DontDestroy Manager").GetComponent<SaveAndLoad>();
        }
    }
    public IEnumerator EndTheLoadScreen()
    {
        yield return new WaitForSeconds(sceneLoad.loadingDelay);
        sceneLoad.endLoading = true;
        sceneLoad.beginLoading = false;
        Time.timeScale = 1f;
    }
}
