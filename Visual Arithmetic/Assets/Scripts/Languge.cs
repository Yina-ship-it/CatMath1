using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Languge : MonoBehaviour
{
    public Sprite[] languagesSprite;
    private string key = "Language";
    void Start()
    {
        GameObject.Find("Language").GetComponent<Image>().sprite = languagesSprite[PlayerPrefs.GetInt(key)];
    }

    public void OnClickLanguage()
    {
        if(PlayerPrefs.GetInt(key) == 0)
        {
            PlayerPrefs.SetInt(key, 1);
            GameObject.Find("Language").GetComponent<Image>().sprite = languagesSprite[1];
        }
        else
        {
            PlayerPrefs.SetInt(key,0);
            GameObject.Find("Language").GetComponent<Image>().sprite = languagesSprite[0];
        }
        if (PlayerPrefs.GetInt("Sound") == 0)
            GameObject.Find("SoundManager").GetComponent<AudioSource>().Play();
    }
}
