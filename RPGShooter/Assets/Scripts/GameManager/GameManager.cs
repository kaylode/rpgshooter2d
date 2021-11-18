using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
/*
 * Singleton Design Pattern
 */
{
    public static GameManager instance;

    private void Awake()
    {
        if (GameManager.instance != null)
        {
            Destroy(gameObject);
        }
        instance = this;
    }

    public FloatingTextManager floatingTextManager;

    public Player player;
    public float playerHealth;
    public int playerSkin;
    public int coin;
    public int playerWeapon;


    // Save game state
    public void SaveState()
    {
        Debug.Log("Save state");
        string s = "";

        s += "0" + "|";
        s += coin.ToString();

        PlayerPrefs.SetString("SaveState", s);
    }

    // Load game state
    public void LoadState()
    {
        Debug.Log("Load state");
    }

    // Floating text
    public void ShowText(string msg, int fontSize, Color color, Vector3 position, Vector3 motion, float duration)
    {
        floatingTextManager.Show(msg, fontSize, color, position, motion, duration);
    }
}
