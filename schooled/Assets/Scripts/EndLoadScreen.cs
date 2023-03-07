using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndLoadScreen : MonoBehaviour
{
    public SceneLoad sceneLoad;

    public IEnumerator EndTheLoadScreen()
    {
        yield return new WaitForSeconds(sceneLoad.loadingDelay);
        sceneLoad.endLoading = true;
        sceneLoad.beginLoading = false;
    }
}
