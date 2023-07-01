using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 
/// The purpose of this script is to act as a controller for items using the scriptable objects
/// and depending on the item will attach different behaviours based on the item.
///     Then the script will be in charge of running through the correct behaviour.
/// 
/// </summary>

public class itemObject : MonoBehaviour
{
    //referebce to item scriptable object
    [SerializeField] public Item item;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        #region colliding with the player
        if (collision.transform.parent.gameObject.tag == "Player") 
        {
            //create reference to player and add item to the players inventory
            GameObject player;
            player = collision.transform.parent.gameObject;

            PlayerController pC = player.GetComponent<PlayerController>();
            inventoryOject pI = pC.Inventory;

            pI.addItem(item, 1);

            Debug.Log(item.name + " Picked up!");

            GameObject.Destroy(gameObject);
        }
        #endregion
    }
}
