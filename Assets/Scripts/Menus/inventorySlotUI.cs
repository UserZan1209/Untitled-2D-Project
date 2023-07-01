using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class inventorySlotUI : MonoBehaviour
{
    [SerializeField] public Image icon;
    [SerializeField] public TextMeshProUGUI itemName;

    public void setSprite(Sprite s)
    {
        icon.sprite = s;
    }

    public void setName(string t)
    {
        itemName.text = t;
    }
}
