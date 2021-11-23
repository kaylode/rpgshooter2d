using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
/*
 * Singleton Design Pattern
 */
{
    public GameObject gameOverUI;
    public GameObject gameWinUI;

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

    [HideInInspector]
    public Player player = Player.instance;
    public FloatingTextManager floatingTextManager;
    [HideInInspector]
    public float playerHealth;
    [HideInInspector]
    public int playerSkin;
    [HideInInspector]
    public int playerWeapon;
    [HideInInspector]
    public int coin = 0;
    [HideInInspector]
    public int speed;

    public void SetPlayerSkin(Sprite sprite)
    {
        player.spriteRenderer.sprite = sprite;
    }

    public void FreezeAllMovement()
    {
        player.FreezeMovement();
    }

    public void UnFreezeAllMovement()
    {
        player.UnFreezeMovement();
    }

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
    public FloatingText ShowText(string msg, int fontSize, Color color, Vector3 position, Vector3 motion, float duration)
    {
        return floatingTextManager.Show(msg, fontSize, color, position, motion, duration);
    }

    public void RetryScene()
    {
        player.GetComponent<Collider2D>().enabled = false;
        this.FreezeAllMovement();
        gameOverUI.SetActive(true);
    }
    public void WinScene()
    {
        player.GetComponent<Collider2D>().enabled = false;
        this.FreezeAllMovement();
        gameWinUI.SetActive(true);
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
