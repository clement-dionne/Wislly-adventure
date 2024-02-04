using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class ShopEmplacement
{
    public Item item;
    public Item Coins;
    public int Cost;
    public bool AlreadyShow = false;
    public bool CanBeBuy = false;
}

public class ShopItem : MonoBehaviour
{
    #region Unity Public
    public ShopEmplacement[] shopEmplacements;
    public GameObject ShopContent;
    public GameObject ItemButtonPrefab;
    public Item Coin;
    #endregion

    private int LastCoinValue = 0;

    private void Start()
    {
        ResetShop();
    }

    public void Update()
    {
        if (LastCoinValue != Coin.NumberOfObject)
        {
            LastCoinValue = Coin.NumberOfObject;
            ResetShop();
        }

        for (int index = 0; index < shopEmplacements.Length; index ++)
        {
            if (shopEmplacements[index].Coins.NumberOfObject >= shopEmplacements[index].Cost)
            {
                shopEmplacements[index].CanBeBuy = true;
            }

            if (shopEmplacements[index].CanBeBuy && !shopEmplacements[index].AlreadyShow)
            {
                GameObject button = Instantiate(ItemButtonPrefab, ShopContent.transform);
                button.transform.Find("ItemNameText").GetComponent<Text>().text = shopEmplacements[index].item.ItemName;
                button.transform.Find("ItemCostText").GetComponent<Text>().text = shopEmplacements[index].Cost.ToString();
                int a = index;
                button.GetComponent<Button>().onClick.AddListener(() => Buy(a));
                shopEmplacements[index].AlreadyShow = true;
            }
        }

        if (GameObject.FindGameObjectsWithTag("ShopButtonItem").Length > shopEmplacements.Length)
        {
            ResetShop();
        }
    }

    public void Buy(int index)
    {
        shopEmplacements[index].Coins.NumberOfObject -= shopEmplacements[index].Cost;
        shopEmplacements[index].item.NumberOfObject += 1;
        ResetShop();
    }

    public void ResetShop()
    {

        GameObject[] buttons = GameObject.FindGameObjectsWithTag("ShopButtonItem");
        foreach (GameObject but in buttons)
        {
            Destroy(but);
        }

        for (int index = 0; index < shopEmplacements.Length; index++)
        {
            shopEmplacements[index].CanBeBuy = false;
            shopEmplacements[index].AlreadyShow = false;
        }
    }
}