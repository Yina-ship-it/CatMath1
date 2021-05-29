using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WindowLoseScript : MonoBehaviour
{
    public Text Score;
    public Text Record;

    void Start()
    {
        int score = DataHolder.Score;
        int record = PlayerPrefs.GetInt(DataHolder.Game.ToString());
        if (score > record)
        {
            PlayerPrefs.SetInt(DataHolder.Game.ToString(), score);
            Score.text = "Новый Рекорд\n" + score.ToString();
        }
        else
        {
            Score.text = score.ToString();
            Record.text = "Рекорд: " + PlayerPrefs.GetInt(DataHolder.Game.ToString()).ToString();
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
