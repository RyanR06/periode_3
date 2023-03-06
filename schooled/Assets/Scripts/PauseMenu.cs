using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public UiNav uiNav;

    public bool uiDisabled;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(uiNav.pauseKey))
        {
            if (uiDisabled)
            {
                uiNav.Topause();
                uiDisabled = false;
            }
        }
    }
}
