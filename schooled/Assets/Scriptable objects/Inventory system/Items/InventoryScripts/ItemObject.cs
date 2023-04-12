using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Itemtype
{
    Key,
}
public abstract class Itemobject : ScriptableObject
{
    public GameObject prefab;
    public Itemtype type;
    [TextArea(15, 20)]
    public string description;
}
