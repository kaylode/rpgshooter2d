using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop: MonoBehaviour
{

    public GameObject[] sellingWeapons;
    public GameObject[] sellingSkins;
    public int[] sellingSkinsPrice;
    public int[] sellingWeaponsPrice;

    public List<Sprite> GetWeaponSprites()
    {
        List<Sprite> sprites = new List<Sprite>();

        foreach (GameObject obj in sellingWeapons)
        {
            sprites.Add(obj.transform.GetComponent<SpriteRenderer>().sprite);
        }
        return sprites;
    }

    public List<Sprite> GetHeroSprites()
    {
        List<Sprite> sprites = new List<Sprite>();

        foreach (GameObject obj in sellingSkins)
        {
            sprites.Add(obj.transform.GetComponent<SpriteRenderer>().sprite);
        }
        return sprites;
    }

    public List<int> GetWeaponPrices()
    {
        List<int> prices = new List<int>();

        foreach (int obj in sellingWeaponsPrice)
        {
            prices.Add(obj);
        }
        return prices;
    }

    public List<int> GetSkinPrices()
    {
        List<int> prices = new List<int>();

        foreach (int obj in sellingSkinsPrice)
        {
            prices.Add(obj);
        }
        return prices;
    }

    public void BuyItemAt(int index, string type)
    {
        bool success = false;
        if (type == "weapon")
        {
            if (GameManager.instance.coin < this.sellingWeaponsPrice[index])
                return;
            success = BuyWeapon(this.sellingWeapons[index].GetComponent<Weapon>());
            if (success)
            {
                GameManager.instance.coin -= this.sellingWeaponsPrice[index];
            }
        }
        else if (type == "skin")
        {
            if (GameManager.instance.coin < this.sellingSkinsPrice[index])
                return;
            success = BuySkin(this.sellingSkins[index].GetComponent<SpriteRenderer>().sprite);
            if (success)
            {
                GameManager.instance.coin -= this.sellingSkinsPrice[index];
            }
        }

        Debug.Log("Buy item: " + success.ToString());
    }

    public bool BuyWeapon(Collectible item)
    {
        List<Collectible> items = Player.inventory.GetItemList();

        bool aldreadyHaveFlag = false;
        foreach (Collectible itemInventory in items)
        {
            string itemName = itemInventory.gameObject.GetComponent<Weapon>().name;
            string curName = item.gameObject.GetComponent<Weapon>().name;
            if (itemName == curName)
            {
                aldreadyHaveFlag = true;
                break;
            }
        }

        if (!aldreadyHaveFlag)
        {
            Collectible obj = Instantiate(item, GameManager.instance.player.transform.parent);
            obj.transform.position = GameManager.instance.player.transform.position;

            return true;
        }
        return false;
    }

    public bool BuySkin(Sprite item)
    {
        GameManager.instance.SetPlayerSkin(item);
        return true;
    }


}
