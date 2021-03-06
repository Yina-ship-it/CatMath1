using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{
    [Tooltip("??? ??? ??????: ??????, ???????, ???????")] public GameObject gameObjects;
    [HideInInspector] private GameObject eventSystem;
    [HideInInspector] private GameObject Prefab;
    [HideInInspector] private GameObject canvas;

    void Start()
    {
        eventSystem = GameObject.Find("EventSystem");
        canvas = GameObject.Find("Canvas");

    }

    public void NextScene(int sceneNumber)
    {
        PlayTap();
        SceneManager.LoadScene(sceneNumber);
    }

    public void OnClickAnswerGame1(int id)
    {
        if (eventSystem.GetComponent<Game1Ctrl>().sign == id)
        {
            PlayTap();
            eventSystem.GetComponent<Game1Ctrl>().next = true;
        }
        else
            eventSystem.GetComponent<Game1Ctrl>().lose = true;
    }

    public void OnClickPause(bool timer)
    {
        PlayTap();
        DataHolder.pauseTimer = timer;
        if(timer)
            GameObject.Find("Timer").GetComponent<Timer>().pause = true;
        Prefab = Instantiate(gameObjects);
        Prefab.transform.SetParent(canvas.transform);
        Prefab.transform.localScale = new Vector2(1f, 1f);
    }

    public void Select(int Game)
    {
        PlayTap();
        Prefab = Instantiate(gameObjects);
        Prefab.transform.SetParent(canvas.transform);
        Prefab.transform.localScale = new Vector2(1f, 1f);

        DataHolder.Game = Game;
    }

    public void PrefabDestroy(string prefab)
    {
        PlayTap();
        Prefab = GameObject.Find(prefab);
        Destroy(Prefab);
    }

    public void Explanations()
    {
        PlayTap();
        Prefab = Instantiate(gameObjects);
        Prefab.transform.SetParent(canvas.transform);
        Prefab.transform.localScale = new Vector2(1f, 1f);
        GameObject.Find("Text").GetComponent<Text>().text = DataHolder.languageText[PlayerPrefs.GetInt("Language"), DataHolder.Game - 1];

    }
    public void OnClickAnswerGame2(int id)
    {
        if (eventSystem.GetComponent<Game2Ctrl>().CorrectAnswerID == id)
        {
            PlayTap();
            eventSystem.GetComponent<Game2Ctrl>().next = true;
        }

        else
            eventSystem.GetComponent<Game2Ctrl>().lose = true;
    }
    public void Difficulty(int difficulty)
    {
        PlayTap();
        PlayerPrefs.SetInt("Difficulty", difficulty);
        switch (DataHolder.Game)
        {
            case 1:
                D1(difficulty);
                SceneManager.LoadScene(2);
                break;
            case 2:
                D2(difficulty);
                SceneManager.LoadScene(3);
                break;
        }
    }

    private void D1(int difficulty)
    {
        switch (difficulty)
        {
            case 1:
                DataHolder.N = 4;
                DataHolder.Max = 20;
                DataHolder.NumberSigns = 2;
                DataHolder.k = 1;
                break;
            case 2:
                DataHolder.N = 5;
                DataHolder.Max = 200;
                DataHolder.NumberSigns = 4;
                DataHolder.k = 1;
                break;
            case 3:
                DataHolder.N = 5;
                DataHolder.Max = 2000;
                DataHolder.NumberSigns = 4;
                DataHolder.k = 0.1;
                break;
        }
    }

    private void D2(int difficulty)
    {
        switch (difficulty)
        {
            case 1:
                DataHolder.timeRemember = 3;
                DataHolder.maxNumber = 10;
                DataHolder.numbers = 5;
                break;
            case 2:
                DataHolder.timeRemember = 2;
                DataHolder.maxNumber = 15;
                DataHolder.numbers = 7;
                break;
            case 3:
                DataHolder.timeRemember = 1;
                DataHolder.maxNumber = 20;
                DataHolder.numbers = 10;
                break;
        }
    }

    public void DeleteRwcord()
    {
        PlayerPrefs.DeleteAll();
    }

    private void PlayTap()
    {
        if(PlayerPrefs.GetInt("Sound") == 0)
            GameObject.Find("SoundManager").GetComponent<AudioSource>().Play();
    }
}
