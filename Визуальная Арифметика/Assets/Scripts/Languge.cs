using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Languge : MonoBehaviour
{
    public Sprite[] languagesSprite;
    void Start()
    {
        GameObject.Find("Language").GetComponent<Image>().sprite = languagesSprite[PlayerPrefs.GetInt("Language")];
    }

    public void OnClickLanguage()
    {
        if(PlayerPrefs.GetInt("Language") == languagesSprite.Length - 1)
        {
            PlayerPrefs.SetInt("Language", 0);
            GameObject.Find("Language").GetComponent<Image>().sprite = languagesSprite[0];
        }
        else
        {
            PlayerPrefs.SetInt("Language", PlayerPrefs.GetInt("Language") + 1);
            GameObject.Find("Language").GetComponent<Image>().sprite = languagesSprite[PlayerPrefs.GetInt("Language")];
        }

    }
}
