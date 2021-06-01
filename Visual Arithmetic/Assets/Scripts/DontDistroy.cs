using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDistroy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (GameObject.FindGameObjectsWithTag("Sound").Length == 1)
            DontDestroyOnLoad(gameObject);
        else
            Destroy(gameObject);
    }
}
