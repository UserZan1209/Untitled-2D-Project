using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new item", menuName = "Items/Default Healing Item")]
public class healingItem : Item
{
    public int val;

    private void Awake()
    {
        itemType = itemTypes.Healing;    
    }
}



