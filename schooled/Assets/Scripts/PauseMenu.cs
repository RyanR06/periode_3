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
        ContinueOrStop();
    }

    public void ContinueOrStop()
    {
        if (Input.GetKeyDown(uiNav.pauseKey))
        {
            if (uiDisabled)
            {
                uiNav.Topause();
                uiDisabled = false;
                StartCoroutine(StopTime());
                Cursor.lockState = CursorLockMode.None;
            }
            else
            {
                ResumeTheTime();
                uiDisabled = true;
                uiNav.LeavePause();
                Cursor.lockState = CursorLockMode.Locked;
            }
        }
    }
    public void ResumeTheTime()
    {
        Time.timeScale = 1f;
        uiNav.LeavePause();
        Cursor.lockState = CursorLockMode.Locked;
    }

    public IEnumerator StopTime()
    {
        yield return new WaitForSeconds(0.3f);
        if (!uiDisabled)
        {

            Time.timeScale = 0f;
        }
    }
}
