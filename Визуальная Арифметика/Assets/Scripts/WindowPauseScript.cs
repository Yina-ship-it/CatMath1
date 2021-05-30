using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WindowPauseScript : MonoBehaviour
{
    public Text Score;
    public Text Record;
    void Start()
    {
        Score.text = DataHolder.Score.ToString();
        Record.text = "Рекорд: " + PlayerPrefs.GetInt(DataHolder.Game.ToString()).ToString();
    }

    public void OnClickResume()
    {
        if (DataHolder.pauseTimer)
            GameObject.Find("Timer").GetComponent<Timer>().pause = false;
        Destroy(gameObject);
    }

    public void RestartScene()
    {
        if (PlayerPrefs.GetInt("Sound") == 0)
            GameObject.Find("Click Audio").GetComponent<AudioSource>().Play();
        Destroy(gameObject);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void NextScene(int sceneNumber)
    {
        if (PlayerPrefs.GetInt("Sound") == 0)
            GameObject.Find("Click Audio").GetComponent<AudioSource>().Play();
        Destroy(gameObject);
        SceneManager.LoadScene(sceneNumber);
    }
}
