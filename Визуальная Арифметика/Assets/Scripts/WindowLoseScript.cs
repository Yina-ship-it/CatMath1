using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WindowLoseScript : MonoBehaviour
{
    public Text Score;

    void Start()
    {
        Score.text = DataHolder.Score.ToString();
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
