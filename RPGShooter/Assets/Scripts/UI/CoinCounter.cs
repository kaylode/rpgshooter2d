using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinCounter : MonoBehaviour
{
    Text text;
    
    private void Start()
    {
        text = transform.Find("Counter").GetComponent<Text>();
    }

    private void Update()
    {
        int coinAmount = GameManager.instance.GetCoin();
        text.text = "x" + coinAmount.ToString();
    }
}
