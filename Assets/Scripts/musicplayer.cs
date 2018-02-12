using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class musicplayer : MonoBehaviour
{
    musicplayer instance;
    // Use this for initialization
    void Start()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
}
	
	
