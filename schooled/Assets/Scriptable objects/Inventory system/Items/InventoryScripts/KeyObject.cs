using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New key", menuName = "Inventory system/items/key")]
public class KeyObject : Itemobject
{
    public void Awake()
    {
        type = Itemtype.Key;
    }
}
