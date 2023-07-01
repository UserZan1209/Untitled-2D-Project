using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Inventory", menuName = "Inventory")]
public class inventoryOject : ScriptableObject
{
    public List<inventorySlot> itemContainer = new List<inventorySlot>();

    public void addItem(Item item, int amount)
    {
        bool hasItem = false;
        for (int i = 0; i < itemContainer.Count; i++)
        {
            if(itemContainer[i].item == item)
            {
                itemContainer[i].inceaseItem(amount);
                hasItem = true;
                break;
            }
        }
        if (!hasItem)
        {
            itemContainer.Add(new inventorySlot(item, amount));
        }
    }

    public void clearInventory()
    {
       itemContainer.Clear();
    }
}

[System.Serializable]
public class inventorySlot 
{
    public Item item;
    public int amount;

    public inventorySlot(Item _i, int v)
    {
        item = _i;
        amount = v;
    }

    public void inceaseItem(int v)
    {
        amount += v;
    }
}

