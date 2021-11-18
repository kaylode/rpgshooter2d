using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(Text))]
public class MoneyCounterUI : MonoBehaviour
{
    private Text moneyText;
    void Awake()
    {
        moneyText = GetComponent<Text>();
    }
    void Update()
    {
        moneyText.text = "MONEY: " + Player.Money.ToString();
    }

}
