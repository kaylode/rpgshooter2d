using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Shop : MonoBehaviour
{
  
    private Transform heroItemTemplate;
    private Transform weaponItemTemplate;
    private Transform heroItemContainer;
    private Transform weaponItemContainer;
    private Shop shop;

    private void Awake()
    {
        heroItemContainer = transform.Find("RightPanel");
        heroItemTemplate = heroItemContainer.Find("HeroTemplate");
        weaponItemContainer = transform.Find("LeftPanel");
        weaponItemTemplate = weaponItemContainer.Find("WeaponTemplate");
        heroItemTemplate.gameObject.SetActive(false);
        weaponItemTemplate.gameObject.SetActive(false);
    }

    private void Start()
    {
        shop = this.transform.gameObject.GetComponent<Shop>();

        List<Sprite> weaponList = shop.GetWeaponSprites();
        List<Sprite> skinList = shop.GetHeroSprites();
        List<int> weaponPriceList = shop.GetWeaponPrices();
        List<int> skinPriceList = shop.GetSkinPrices();

        for (int i =0; i< weaponList.Count; i++)
        {
            CreateWeaponButton(weaponList[i], weaponPriceList[i], i);
        }

        for (int i = 0; i < skinList.Count; i++)
        {
            CreateHeroButton(skinList[i], skinPriceList[i], i);
        }
    }

    private void CreateWeaponButton(Sprite itemSprite, int itemCost, int positionIndex)
    {
        Transform shopItemTransform = Instantiate(weaponItemTemplate, weaponItemContainer);
        shopItemTransform.gameObject.SetActive(true);
        RectTransform shopItemRectTransform = shopItemTransform.GetComponent<RectTransform>();

        float shopItemHeight = 150f;
        shopItemRectTransform.anchoredPosition = new Vector2(0, -shopItemHeight * positionIndex);

        shopItemTransform.Find("ItemImage").GetComponent<Image>().sprite = itemSprite;
        shopItemTransform.Find("Price").Find("Text").GetComponent<Text>().text = itemCost.ToString();

        Button button = shopItemTransform.GetComponent<Button>();
        button.onClick.AddListener(delegate { BuyItem(positionIndex, "weapon", button); });
    }

    private void CreateHeroButton(Sprite itemSprite, int itemCost, int positionIndex)
    {
        Transform shopItemTransform = Instantiate(heroItemTemplate, heroItemContainer);
        shopItemTransform.gameObject.SetActive(true);

        RectTransform shopItemRectTransform = shopItemTransform.GetComponent<RectTransform>();

        float shopItemWidth = 450f;
        shopItemRectTransform.anchoredPosition = new Vector2(shopItemWidth * positionIndex, 0);

        shopItemTransform.Find("ItemImage").GetComponent<Image>().sprite = itemSprite;
        shopItemTransform.Find("Price").Find("Text").GetComponent<Text>().text = itemCost.ToString();

        Button button = shopItemTransform.GetComponent<Button>();
        button.onClick.AddListener(delegate { BuyItem(positionIndex, "skin", button); });
    }

    private void BuyItem(int index, string type, Button button)
    {
        shop.BuyItemAt(index, type);
        button.interactable = false;
    }
}
