using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveAndLoad : MonoBehaviour
{
    public Playerposition playerposition;

    public float playerPrefX;
    public float playerPrefY;
    public float playerPrefZ;

    public Vector3 playerLoc;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        playerLoc.x = PlayerPrefs.GetFloat("PlayerPosX");
        playerLoc.y = PlayerPrefs.GetFloat("PlayerPosY");
        playerLoc.z = PlayerPrefs.GetFloat("PlayerPosZ");
    }

    public void SavePlayerPos()
    {
        PlayerPrefs.SetFloat("PlayerPosX", playerposition.playerPosx);
        PlayerPrefs.SetFloat("PlayerPosY", playerposition.playerPosy);
        PlayerPrefs.SetFloat("PlayerPosZ", playerposition.playerPosz);
    }

    public void LoadPlayerPos()
    {
        playerposition.Player.position = playerLoc;
    }
}
