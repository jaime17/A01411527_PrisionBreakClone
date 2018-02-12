using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {
    public bool autoplay = false;
    public float minX;
    public float maxX;
    private Ball ball;
    public float speed;
    public Rigidbody2D pd;

	// Use this for initialization
	void Start () {
        ball = GameObject.FindObjectOfType<Ball>();
        
		
	}
	
	// Update is called once per frame
	void Update () {
        if (!autoplay)
        {
            MoveWithkey ();
        }
        else
        {
            Autoplay ();
        }
	}

    void Autoplay()
    {
        Vector3 paddlePos = this.transform.position;
        Vector3 ballPos = ball.transform.position;
        paddlePos.x = Mathf.Clamp(ballPos.x - 0.0f, minX, maxX);
        this.transform.position = paddlePos;
    }

    void MoveWithkey()  //necesitamos obtener la posicion del mouse
    {
        //Vector3 paddleePoss = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);

        //float mousePosInBlock = Input.mousePosition.x / Screen.width *16;
       
        float x = Input.GetAxis("Horizontal");
        if (x < 0){
            left();
        }
        if (x > 0)
        {
            right();
        }
        if (x == 0)
        {
            Stop();
        }
        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, minX, maxX);
        transform.position = pos;
         

       // paddleePoss.x = Mathf.Clamp(hAxis, minX, maxX);
       // this.transform.position = paddleePoss;
    }

     void left()
    {
        pd.velocity = new Vector2(-speed, 0);
    }

    void right()
    {
        pd.velocity = new Vector2(speed, 0);

    }

    void Stop()
    {
        pd.velocity = new Vector2(speed * 0,0);
    }
}
