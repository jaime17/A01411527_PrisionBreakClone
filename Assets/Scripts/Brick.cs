using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Brick : MonoBehaviour {

    public AudioClip crack;
    public Sprite[] hitSprites;
    public static int breakableCount = 0;
    public GameObject smoke;
    //Pripiedades privadas
    private int timesHit;
    private LevelManager levelManager;
    private bool isBreakable;
    private object main;

    // Use this for initialization
    void Start () {
        
        isBreakable = (this.tag == "breakable");
      

        if (isBreakable)
        {
            breakableCount++;
        }

        timesHit = 0;
        levelManager = GameObject.FindObjectOfType<LevelManager>();
        

    }
	
	void OnCollisionEnter2D (Collision2D collision)
    {
        AudioSource.PlayClipAtPoint(crack,transform.position, 0.8f);

        if (isBreakable)
        {
            HandleHits();

        }

    }

     void HandleHits()
    {

        timesHit++;

        int maxHits = hitSprites.Length + 1;

        if(timesHit>= maxHits)
        {
            breakableCount--;
            levelManager.BrickDestroyed();
            PuffSmoke();
            Destroy(gameObject);
            


        }
        else
        {
            LoadSprites();
        }
    }

    
    void PuffSmoke()
    {
        GameObject smokePuff = Instantiate(smoke, transform.position, Quaternion.identity);
        //how would we do this in the newest version of unity?

        ParticleSystem Ps = smokePuff.GetComponent<ParticleSystem>();
        var main = Ps.main;
        main.startColor = gameObject.GetComponent<SpriteRenderer>().color;


    }

    void LoadSprites()
    {
        int SpriteIndex = timesHit - 1;
        if (hitSprites[SpriteIndex] != null)
        {
            this.GetComponent<SpriteRenderer>().sprite = hitSprites[SpriteIndex];
        }
        else
        {
            Debug.LogError("Brick sprite missing");
        }
    }

}
