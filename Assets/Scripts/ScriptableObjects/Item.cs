using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#region item types declarations
public enum itemTypes 
{
    Default,
    Healing, 
    MagicRestoring,
    Equipment,
}
#endregion

#region Basic item class

/// <summary>
/// 
/// A basic item script that contains all shared infomation and behaviour amoung items
/// 
/// </summary>

[CreateAssetMenu(fileName = "new item", menuName = "Items/Default Item Object")]
public class Item : ScriptableObject
{
    #region Basic item infomation
    public new string name;
    public itemTypes itemType;
    public GameObject prefabGameObject;
    public string description;
    public Sprite sprite;
    #endregion

    #region interaction based infomation
    //used for modifying stats if useable
    [SerializeField] public bool isheld = false;
    [SerializeField] public int itemValue;
    #endregion

    private void Awake()
    {
        initItem();
    }

    private void initItem()
    {
        itemType = itemTypes.Default;
    }
}
#endregion
