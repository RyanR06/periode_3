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
            }
        }
    }
}
