using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New food Object", menuName = "Inventory system/items/food")]

public class FoodObject : Itemobject
{
    public int restoreHealthValue;
    public void Awake()
    {
        type = Itemtype.Food;
    }
}
