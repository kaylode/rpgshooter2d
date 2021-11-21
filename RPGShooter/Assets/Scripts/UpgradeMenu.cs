using UnityEngine;
using UnityEngine.UI;
public class UpgradeMenu : MonoBehaviour
{
    [SerializeField]
    private Text healthText;
    [SerializeField]
    private Text speedText;
    [SerializeField]
    private Text shieldText;
    [SerializeField]
    private Text damageText;
    [SerializeField]
    private int upgradeFactor = 10;
    [SerializeField]
    private Player stats;

    void OnEnable()
    {
        stats = (Player)FindObjectOfType(typeof(Player));
        UpdateValues();
    }
    void UpdateValues()
    {
        healthText.text = "HEALTH: " + ((int)stats.maxHealth).ToString();
        speedText.text = "SPEED: " + ((int)stats.speed).ToString();
        shieldText.text = "SHIELD: " + ((int)stats.shield).ToString();
        damageText.text = "DAMAGE: " + ((int)stats.damage).ToString();
    }
    public void UpgradeHealth()
    {
        stats.maxHealth += upgradeFactor;
        UpdateValues();
    }
    public void UpgradeSpeed()
    {
        stats.speed += upgradeFactor;
        UpdateValues();
    }
    public void UpgradeShield()
    {
        stats.shield += upgradeFactor;
        UpdateValues();
    }
    public void UpgradeDamage()
    {
        stats.damage += upgradeFactor;
        UpdateValues();
    }
}
