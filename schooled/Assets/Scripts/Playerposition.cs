using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playerposition : MonoBehaviour
{
    public float playerPosx;
    public float playerPosy;
    public float playerPosz;

    public Transform Player;

    void Update()
    {
        playerPosx = transform.position.x;
        playerPosy = transform.position.y;
        playerPosz = transform.position.z;
    }
}
