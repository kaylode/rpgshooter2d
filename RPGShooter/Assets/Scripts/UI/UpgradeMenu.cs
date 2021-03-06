using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UpgradeMenu : MonoBehaviour
{
    private int upgradeFactor = 1;
    Transform healthTransform;
    Transform speedTransform;
    Text healthText;
    Text speedText;
    Player player;

    public int HEALTH_UPGRADE_PRICE = 100;
    public int SPEED_UPGRADE_PRICE = 100;

    private void Awake()
    {
        transform.gameObject.SetActive(false);
        gameObject.SetActive(false);
    }

    protected void Start()
    {
        Transform frameTransform = transform.Find("HeroAttributes");
        healthTransform = frameTransform.Find("Attributes").Find("HealthAttribute").Find("HealthAmount");
        speedTransform = frameTransform.Find("Attributes").Find("SpeedAttribute").Find("SpeedAmount");
        healthText = healthTransform.gameObject.GetComponent<Text>();
        speedText = speedTransform.gameObject.GetComponent<Text>();
        player = GameManager.instance.player;
        UpdateValues();
    }

    private void UpdateValues()
    {
        healthText.text = "HEALTH: " + ((int)player.GetMaxHealth()).ToString();
        speedText.text = "SPEED: " + ((int)player.speed).ToString();
    }
    public void UpgradeHealth()
    {

        int coin = GameManager.instance.GetCoin();
        if (coin >= HEALTH_UPGRADE_PRICE)
        {
            player.maxHealth += upgradeFactor;
            GameManager.instance.coin -= HEALTH_UPGRADE_PRICE;
            UpdateValues();
        }
    }
    public void UpgradeSpeed()
    {
        int coin = GameManager.instance.GetCoin();
        if (coin >= SPEED_UPGRADE_PRICE)
        {
            player.speed += upgradeFactor;
            GameManager.instance.coin -= SPEED_UPGRADE_PRICE;
            UpdateValues();
        }
    }

    public void Toggle()
    {
        if (transform.gameObject.activeSelf)
        {
            Cursor.visible = false;
            this.transform.gameObject.SetActive(false);
            this.gameObject.SetActive(false);
            GameManager.instance.UnFreezeAllMovement();
        }
        else
        {
            Cursor.visible = true;
            this.gameObject.SetActive(true);
            this.transform.gameObject.SetActive(true);
            GameManager.instance.FreezeAllMovement();
        }
    }
}
