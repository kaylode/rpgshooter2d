using UnityEngine;
using UnityEngine.SceneManagement;
public class GameOverUI : MonoBehaviour
{
    public void Quit()
    {
        Debug.Log("APPLICATION QUIT!");
        Application.Quit();
    }
    public void Retry()
    {
        int sceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (sceneIndex == 1)
        {
            GameObject go = GameObject.Find("Manager");
            Destroy(go.gameObject);
        };

        SceneManager.LoadScene(sceneIndex);
    }

}
