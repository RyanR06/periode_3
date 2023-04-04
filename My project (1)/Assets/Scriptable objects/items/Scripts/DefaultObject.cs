using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Default Object", menuName = "Inventory system/items/default")]
public class DefaultObject : Itemobject
{
    public void Awake()
    {
        type = Itemtype.Default;
    }
}
