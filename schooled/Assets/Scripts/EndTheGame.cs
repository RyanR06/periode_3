using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTheGame : MonoBehaviour
{
    public GameObject EndScreens;

    public UiNav uiNav;

    public void OnTriggerEnter(Collider other)
    {
        EndScreens.SetActive(true);
        StartCoroutine(WaitASecond());
    }

    public IEnumerator WaitASecond()
    {
        yield return new WaitForSeconds(5);
        StartCoroutine(uiNav.MainMenuCO());
    }
}
