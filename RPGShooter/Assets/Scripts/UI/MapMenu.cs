using UnityEngine;
using UnityEngine.SceneManagement;
public class MapMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject mapMenu;

    public void ToggleMapMenu()
    {
        mapMenu.SetActive(!mapMenu.activeSelf);
    }
}
