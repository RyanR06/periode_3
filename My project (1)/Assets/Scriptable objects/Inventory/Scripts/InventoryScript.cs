using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryScript : ScriptableObject
{
    public List<Itemobject> Container = new List<Itemobject>();
}
[System.Serializable]
public class Inventoryslot
{
    public Itemobject item;
    public int amount;
    public Inventoryslot(Itemobject item, int amount)
    {
        item = 
    }

}