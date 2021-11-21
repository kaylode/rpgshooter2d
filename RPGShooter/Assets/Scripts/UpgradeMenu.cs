using UnityEngine;
using UnityEngine.UI;
public class UpgradeMenu : MonoBehaviour
{
    private int upgradeFactor = 1;
    Transform healthTransform;
    Transform speedTransform;
    Text healthText;
    Text speedText;

    void OnEnable()
    {
        healthTransform = transform.Find("Attributes").Find("HealthAttribute").Find("HealthAmount");
        speedTransform = transform.Find("Attributes").Find("SpeedAttribute").Find("SpeedAmount");
        healthText = healthTransform.gameObject.GetComponent<Text>();
        speedText = speedTransform.gameObject.GetComponent<Text>();
        UpdateValues();
    }

    private void UpdateValues()
    {
        healthText.text = "HEALTH: " + ((int)GameManager.instance.player.GetMaxHealth()).ToString();
        speedText.text = "SPEED: " + ((int)GameManager.instance.player.speed).ToString();
    }
    public void UpgradeHealth()
    {
        Debug.Log("Test");
        GameManager.instance.player.maxHealth += upgradeFactor;
        UpdateValues();
    }
    public void UpgradeSpeed()
    {
        GameManager.instance.player.speed += upgradeFactor;
        Debug.Log("Test");

        UpdateValues();
    }

    public void Toggle()
    {
        if (transform.gameObject.activeSelf)
        {
            Cursor.visible = false;
            GameManager.instance.UnFreezeAllMovement();
        }
        else
        {
            Cursor.visible = true;
            GameManager.instance.FreezeAllMovement();
        }
        transform.gameObject.SetActive(!transform.gameObject.activeSelf);
    }

}
