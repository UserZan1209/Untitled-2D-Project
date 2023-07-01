using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new item", menuName = "Items/Default Magic Item")]
public class magicItem : Item
{
    [SerializeField] public int val;

    private void Awake()
    {
        itemType = itemTypes.MagicRestoring;
    }
}

