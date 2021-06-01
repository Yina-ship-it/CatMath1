using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sound : MonoBehaviour
{
    public Sprite[] Notes;
    public Sprite[] MusicCat;
    private string key = "Sound";

    void Start()
    {
        GameObject.Find("Sound").GetComponent<Image>().sprite = Notes[PlayerPrefs.GetInt(key)];
        GameObject.Find("ÑatMusic").GetComponent<Image>().sprite = MusicCat[PlayerPrefs.GetInt(key)];
    }

    public void OnClickSound()
    {
        if(PlayerPrefs.GetInt(key) == 0)
        {
            PlayerPrefs.SetInt(key, 1);
            GameObject.Find("Sound").GetComponent<Image>().sprite = Notes[1];
            GameObject.Find("ÑatMusic").GetComponent<Image>().sprite = MusicCat[1];
        }
        else
        {
            PlayerPrefs.SetInt(key, 0);
            GameObject.Find("Sound").GetComponent<Image>().sprite = Notes[0];
            GameObject.Find("ÑatMusic").GetComponent<Image>().sprite = MusicCat[0];
        }
    }
}
