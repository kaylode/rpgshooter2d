using UnityEngine;
using UnityEngine.SceneManagement;
public class MapMenu : MonoBehaviour
{
    private bool isActive;
    private Transform mapMenu;

    public void Awake()
    {
        mapMenu = transform.GetChild(0).transform;
        mapMenu.gameObject.SetActive(false);
        isActive = false;
    }

    public void Update()
    {
        if (Input.GetKeyDown("m"))
        {
            ToggleMapMenu();
        }
    }

    public void ToggleMapMenu()
    {
        mapMenu.gameObject.SetActive(!isActive);
        isActive = !isActive;
    }
}
