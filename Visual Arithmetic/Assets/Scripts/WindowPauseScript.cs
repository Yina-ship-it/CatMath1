using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WindowPauseScript : MonoBehaviour
{
    private GameObject Pause;
    public void Start()
    {
        Pause = GameObject.Find("Pause");
        Pause.SetActive(false);
    }
    public void OnClickResume()
    {
        if (DataHolder.pauseTimer)
            GameObject.Find("Timer").GetComponent<Timer>().pause = false;
        Destroy(gameObject);
        Pause.SetActive(true);
    }

    public void RestartScene()
    {
        if (PlayerPrefs.GetInt("Sound") == 0)
            GameObject.Find("SoundManager").GetComponent<AudioSource>().Play();
        Destroy(gameObject);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void NextScene(int sceneNumber)
    {
        if (PlayerPrefs.GetInt("Sound") == 0)
            GameObject.Find("SoundManager").GetComponent<AudioSource>().Play();
        Destroy(gameObject);
        SceneManager.LoadScene(sceneNumber);
    }
}
