using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onlymusic : MonoBehaviour {
    onlymusic instance;
    // Use this for initialization
    void Start()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
    }
	

}
