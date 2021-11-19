using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        DontDestroyOnLoad(gameObject);
    }

    public FloatingTextManager floatingTextManager;

    public float playerHealth;
    public int playerSkin;
    public int playerWeapon;
    public int coin = 0;
    public int speed;


    public int GetCoin()
    {
        return this.coin;
    }

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

    public void LoadScene(int level)
    {
        switch (level)
        {
            case 0:
                SceneManager.LoadScene("Menu");
                break;
            case 1:
                SceneManager.LoadScene("Map1");
                break;
            case 2:
                SceneManager.LoadScene("Map2");
                break;
            default:
                SceneManager.LoadScene("Menu");
                break;
        }
    }
}
