using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WindowPauseScript : MonoBehaviour
{
    public void Start()
    {
        GameObject.Find("Pause").SetActive(false);
    }
    public void OnClickResume()
    {
        if (DataHolder.pauseTimer)
            GameObject.Find("Timer").GetComponent<Timer>().pause = false;
        GameObject.Find("Pause").SetActive(true);
        Destroy(gameObject);
    }

    public void RestartScene()
    {
        Destroy(gameObject);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void NextScene(int sceneNumber)
    {
        Destroy(gameObject);
        SceneManager.LoadScene(sceneNumber);
    }
}
