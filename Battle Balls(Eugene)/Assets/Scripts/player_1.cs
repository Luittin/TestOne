using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*Игрок 1*/

public class player_1 : MonoBehaviour
{
    public GameObject game, active;

    private float speed = 20f;

    private Rigidbody2D ballRB;

    private float moveX;

    public Transform groundcheck;
    private float groundradius = 0.25f;
    public LayerMask WhatIsGround;
    private bool grounded;

    void Start()
    {
        Invoke("ActiveIndex", 0.1f);
        ballRB = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()                              //Отслеживание управления первого игрока
    {
        moveX = Input.GetAxis("HorizontalPlayer1");

        grounded = Physics2D.OverlapCircle(groundcheck.position, groundradius, WhatIsGround);
    }

    void Update()                               //Управление первым игроком
    {
            ballRB.velocity = new Vector2(moveX * speed, ballRB.velocity.y);

        if (Input.GetKeyDown(KeyCode.W) && grounded)
        {
            ballRB.AddForce(new Vector2(0f, 1000f));
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)                              //Отслеживание соприкосновения двух игроков
    {
        if (collision.gameObject.tag == "Player_2" && game.GetComponent<Game>().ActivePlayer == true)
            game.GetComponent<Game>().PlayerOne();
    }

    public void ActiveIndex()                               //Индекс активного игрока
    {
        if (game.GetComponent<Game>().ActivePlayer == true)
        {
            Instantiate(active, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 1.1f, gameObject.transform.position.z), Quaternion.identity, gameObject.GetComponent<Transform>());
            Invoke("DestroyActiveIndex", 1f);
        }
    }

    private void DestroyActiveIndex()                               //Удаление индекса активного игрока
    {
        Destroy(GameObject.FindGameObjectWithTag("ActivePlayerIndex"));
    }
}
