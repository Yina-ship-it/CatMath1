using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WindowPauseScript : MonoBehaviour
{
    public Text Score;
    void Start()
    {
        Score.text = DataHolder.Score.ToString();
    }

    public void OnClickResume()
    {
        if (DataHolder.pauseTimer)
            GameObject.Find("Timer").GetComponent<Timer>().pause = false;
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
