using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerInventroyController : MonoBehaviour
{
    [SerializeField] private GameObject inventoryUI;
    [SerializeField] private inventoryOject pInventory;

    [SerializeField] private GameObject slotContainer;
    [SerializeField] private GameObject[] inventorySlots;
    // Start is called before the first frame update
    void Start()
    {
        pInventory = getInventory();
        Debug.Log(pInventory.itemContainer.Count);

        getUISlots();

        inventoryUI.SetActive(false);
    }

    public void toggleInventory()
    {
        inventoryUI.SetActive(!inventoryUI.activeInHierarchy);
        if (inventoryUI.activeInHierarchy) 
        {
            updateInventoryUI();
        }
    }

    private void getUISlots()
    {
        inventorySlots = new GameObject[slotContainer.transform.childCount];
        for(int i = 0; i < slotContainer.transform.childCount; i++)
        {

            inventorySlots[i] = slotContainer.transform.GetChild(i).gameObject;
        }

        updateInventoryUI();

    }

    private void updateInventoryUI()
    {
        pInventory = getInventory();

        for (int i = 0; i < slotContainer.transform.childCount; i++)
        {
            if (i >= pInventory.itemContainer.Count)
            {
                inventorySlots[i].gameObject.SetActive(false);
            }
            else
            {
                inventorySlots[i].gameObject.SetActive(true);
                inventorySlots[i].GetComponent<inventorySlotUI>().setSprite(pInventory.itemContainer[i].item.sprite);
                inventorySlots[i].GetComponent<inventorySlotUI>().setName(pInventory.itemContainer[i].item.name);
            }
        }
    }

    private inventoryOject getInventory()
    {
        inventoryOject p;
        p = GameObject.FindGameObjectWithTag("Player").gameObject.GetComponent<PlayerController>().Inventory;
        return p;
    }
}
