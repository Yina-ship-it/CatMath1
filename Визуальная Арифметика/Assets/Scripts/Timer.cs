using UnityEngine;
using UnityEngine.UI;
public class Timer : MonoBehaviour
{
    public float time;
    [HideInInspector]public bool pause;
    private float dtime;
    void Start()
    {
        float width = GameObject.Find("Canvas").GetComponent<RectTransform>().rect.width;
        GetComponent<RectTransform>().sizeDelta = new Vector2(width, 10f);
    }

    void Update()
    {
        if (!pause)
        {
            dtime = Time.deltaTime / time;
            GetComponent<Image>().fillAmount -= dtime;
            GetComponent<Image>().color += new Color(dtime / 2, -dtime / 2, -dtime / 2);
            if (GetComponent<Image>().fillAmount == 0f)
                GameObject.Find("EventSystem").GetComponent<Game1Ctrl>().lose = true;
        }
    }
}
