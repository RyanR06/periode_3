using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New equipment Object", menuName = "Inventory system/items/equipment")]

public class EquipmentObject : Itemobject
{
    public float atkBonus;
    public float defendStats;
    public void Awake()
    {
        type = Itemtype.Equipment;
    }
}
