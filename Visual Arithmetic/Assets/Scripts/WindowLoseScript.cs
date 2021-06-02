using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WindowLoseScript : MonoBehaviour
{
    public Text Score;
    public Text Record;

    private void Start()
    {
        GameObject.Find("Pause").SetActive(false);
        int score = DataHolder.Score;
        string key = "Game" + (DataHolder.Game * 3 + PlayerPrefs.GetInt("Difficulty")).ToString();
        if (!PlayerPrefs.HasKey(key))
            PlayerPrefs.SetInt(key, 0);
        int record = PlayerPrefs.GetInt(key);

        if (score > record)
        {

            PlayerPrefs.SetInt(key, score);
            Record.text = DataHolder.languageText[PlayerPrefs.GetInt("Language"), 4];
            Score.text = score.ToString();
        }
        else
        {
            Score.text = score.ToString();
            Record.text = DataHolder.languageText[PlayerPrefs.GetInt("Language"), 5] + PlayerPrefs.GetInt(key).ToString();
        }
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
