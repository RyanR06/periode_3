using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
[CreateAssetMenu(fileName = "New Inventory Script", menuName = "Inventory system/Inventory")]
public class InventoryScript : ScriptableObject
{
    public List<Inventoryslot> Container = new List<Inventoryslot>();
    public void AddItem(Itemobject _item, int _amount)
    {
        bool hasitem = false;
        for (int i = 0; i < Container.Count; i++) 
        {
            if (Container[i].item == _item)
            {
                hasitem = true;
                break;
            }
        }
    }

}
[System.Serializable]
public class Inventoryslot
{
    public Itemobject item;
    public int amount;
    public Inventoryslot(Itemobject _item, int _amount)
    {
        item = _item;
        amount = _amount;
    }
    public void AddAmount(int value)
    {
        amount += value;
    }
}
