using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{
    [HideInInspector]public GameObject eventSystem;

    void Start()
    {
        eventSystem = GameObject.Find("EventSystem");
    }

    public void NextScene(int sceneNumber)
    {
        SceneManager.LoadScene(sceneNumber);
    }

    public void OnClickAnswerGame1(int id)
    {
        if (eventSystem.GetComponent<Game1Ctrl>().sign == id)
            eventSystem.GetComponent<Game1Ctrl>().next = true;
        else
            eventSystem.GetComponent<Game1Ctrl>().lose = true;
    }

    public void OnClickAnswerGame2(int id)
    {
        if (eventSystem.GetComponent<Game2Ctrl>().CorrectAnswerID == id)
            eventSystem.GetComponent<Game2Ctrl>().next = true;
        else
            eventSystem.GetComponent<Game2Ctrl>().lose = true;
    }
}
