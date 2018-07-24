using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ball : MonoBehaviour {

    public GameObject score;

    private bool flag;

    public float speed;

    private GameObject direction;
    private IEnumerator coroutine;

    private void Start()
    {
        flag = false;
        direction = GameObject.FindGameObjectWithTag("Direction");
    }

    public IEnumerator Direction(float waitSecond)
    {
        while (true)
        {
            direction.SendMessage("MoveDirection");
            yield return new WaitForSeconds(waitSecond);
        }
    }

    private void OnMouseDown()
    {
        if (!flag)
        {
            coroutine = Direction(Time.deltaTime);
            StartCoroutine(coroutine);
        }
    }

    private void OnMouseUp()
    {
        if (!flag)
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(direction.GetComponent<Direction>().Napravlenie.normalized * speed,ForceMode2D.Force);
            direction.SendMessage("Rendererskin");
            StopAllCoroutines();
            flag = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Platform")
        {
            int scoreText = int.Parse(score.GetComponent<Text>().text) + 1;
            score.GetComponent<Text>().text = scoreText.ToString();
        }
    }
}
