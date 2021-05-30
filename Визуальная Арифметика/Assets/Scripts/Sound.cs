using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sound : MonoBehaviour
{
    public Sprite[] SoundSprite;
    public Sprite[] CatSprite;
    void Start()
    {
        GameObject.Find("Sound").GetComponent<Image>().sprite = CatSprite[PlayerPrefs.GetInt("Sound")];
        GameObject.Find("ÑatMusic").GetComponent<Image>().sprite = SoundSprite[PlayerPrefs.GetInt("Sound")];    
    }

    // Update is called once per frame
    public void Click()
    {
        if (PlayerPrefs.GetInt("Sound") == 0)
        {
            PlayerPrefs.SetInt("Sound", (PlayerPrefs.GetInt("Sound") + 1));
            GameObject.Find("Sound").GetComponent<Image>().sprite = SoundSprite[1];
            GameObject.Find("ÑatMusic").GetComponent<Image>().sprite = CatSprite[1];
        }
        else
        {
            PlayerPrefs.SetInt("Sound", (PlayerPrefs.GetInt("Sound") - 1));
            GameObject.Find("Sound").GetComponent<Image>().sprite = SoundSprite[0];
            GameObject.Find("ÑatMusic").GetComponent<Image>().sprite = CatSprite[0];
        }
    }
}
