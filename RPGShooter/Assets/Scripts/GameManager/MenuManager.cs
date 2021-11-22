using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuManager : MonoBehaviour
{
    [SerializeField]
    private GameObject instructionMenu;
    public delegate void UpgradeMenuCallback(bool active);
    public UpgradeMenuCallback onToggleUpgradeMenu;

    void Start()
    {
        this.onToggleUpgradeMenu += OnUpgradeMenuToggle;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            ToggleUpgradeMenu();
        }
    }
    void OnUpgradeMenuToggle(bool active)
    {
        return;
    }
    private void ToggleUpgradeMenu()
    {
        instructionMenu.SetActive(!instructionMenu.activeSelf);
        onToggleUpgradeMenu.Invoke(instructionMenu.activeSelf);
    }
    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Debug.Log("WE QUIT THE GAME!");
        Application.Quit();
    }
}
