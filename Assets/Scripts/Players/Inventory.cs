using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class InventoryEmplacement
{
    public Item item;
    public int LastValue;
    public bool AlreadyShow = false;
    public bool CanBeShow = false;
}

public class Inventory : MonoBehaviour
{

    #region Unity Public
    public GameObject InventoryContent;
    public GameObject ItemInventoryButton;
    public GameObject InventoryPanel;

    public InventoryEmplacement[] inventoryEmplacement;
    public GameObject PausePanel;
    #endregion

    void Start()
    {
        InventoryPanel.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (InventoryPanel.activeInHierarchy) InventoryPanel.SetActive(false);
            else InventoryPanel.SetActive(true);
            ResetInventory();
        }

        if (Input.GetKeyDown(KeyCode.Escape) && !PausePanel.activeInHierarchy)
        {
            InventoryPanel.SetActive(false);
            ResetInventory();
        }

        for (int index = 0; index < inventoryEmplacement.Length; index++)
        {
            if (inventoryEmplacement[index].LastValue != inventoryEmplacement[index].item.NumberOfObject)
            {
                ResetInventory();
                inventoryEmplacement[index].LastValue = inventoryEmplacement[index].item.NumberOfObject;
            }

            if (inventoryEmplacement[index].item.NumberOfObject >= 1)
            {
                inventoryEmplacement[index].CanBeShow = true;
            }

            if (inventoryEmplacement[index].CanBeShow && !inventoryEmplacement[index].AlreadyShow)
            {
                GameObject button = Instantiate(ItemInventoryButton, InventoryContent.transform);
                button.transform.Find("ItemNameText").GetComponent<Text>().text = inventoryEmplacement[index].item.ItemName;
                button.transform.Find("ItemCostText").GetComponent<Text>().text = inventoryEmplacement[index].item.NumberOfObject.ToString();
                int a = index;
                button.GetComponent<Button>().onClick.AddListener(() => UseItem(a));
                inventoryEmplacement[index].AlreadyShow = true;
            }
        }

        if (GameObject.FindGameObjectsWithTag("InventoryButtonItem").Length > inventoryEmplacement.Length)
        {
            ResetInventory();
        }
    }

    public void UseItem(int index)
    {
        inventoryEmplacement[index].item.NumberOfObject -= 1;
        ResetInventory();
    }

    public void ResetInventory()
    {
        GameObject[] ItemButton = GameObject.FindGameObjectsWithTag("InventoryButtonItem");

        foreach(GameObject button in ItemButton)
        {
            Destroy(button);
        }

        for (int index = 0; index < inventoryEmplacement.Length; index++)
        {
            inventoryEmplacement[index].CanBeShow = false;
            inventoryEmplacement[index].AlreadyShow = false;
        }
    }
}
