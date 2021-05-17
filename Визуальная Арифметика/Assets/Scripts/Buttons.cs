using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttons : MonoBehaviour
{
    public Sprite blue, red;
    private void OnMouseDown()
    {
        GetComponent<SpriteRenderer>().sprite = red;
    }

    private void OnMouseUp()
    {
        GetComponent<SpriteRenderer>().sprite = blue;
    }

    private void OnMouseUpAsButton()
    {
        switch (gameObject.name)
        {
            case "OnePlayer":
                Application.LoadLevel("SelectGame");
                break;
            case "TwoPlayer":
                Application.LoadLevel("SelectGame");
                break;
            case "BackHome":
                Application.LoadLevel("Main");
                break;
        }
    }
}
