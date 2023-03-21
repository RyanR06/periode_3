using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public UiNav uiNav;
    public LoadLock loadLock;

    public bool uiDisabled;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(uiNav.pauseKey))
        {
            if (uiDisabled)
            {
                uiNav.Topause();
                uiDisabled = false;
                StartCoroutine(ChangeTime());
            }
            else
            {
                uiNav.LeavePause();
                uiDisabled = true;
                StartCoroutine(ChangeTime());
            }
        }
    }

    public IEnumerator ChangeTime()
    {
        yield return new WaitForSeconds(1);
        if (!uiDisabled)
        {
            Time.timeScale = 0f;
        }
        else if (uiDisabled)
        {
            Time.timeScale = 1f;
        }
    }
}
