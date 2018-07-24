using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour {

    private int ballCollision;

    public int BallCollision
    {
        get
        {
            return ballCollision;
        }

        set
        {
            ballCollision = value;
        }
    }

    private void Start()
    {
        ballCollision = 0;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ball")
        {
            ballCollision++;
        }
    }

}
