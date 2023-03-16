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

    public void Start()
    {
        loadLock.saveAndLoad = GameObject.Find("DontDestroy Manager").GetComponent<SaveAndLoad>();
    }
    public IEnumerator EndTheLoadScreen()
    {
        yield return new WaitForSeconds(sceneLoad.loadingDelay);
        sceneLoad.endLoading = true;
        sceneLoad.beginLoading = false;
        StartCoroutine(SetButtons());
    }

    public IEnumerator SetButtons()
    {
        yield return new WaitForSeconds(3);
        //saveAndLoad.GameLoadbutton = GameObject.Find("LoadButton").GetComponent<Button>();
        //saveAndLoad.LoadText = GameObject.Find("LoadText1").GetComponent<TextMeshProUGUI>();
    }
}
