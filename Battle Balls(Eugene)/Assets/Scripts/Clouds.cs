using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*Движение облаков на заднем плане*/

public class Clouds : MonoBehaviour
{
    private float scrollSpeed;

    private void Start()
    {
        scrollSpeed = Random.Range(0.1f, 0.5f);
    }

    private void Update()                               //движение облаков
    {
        transform.position = new Vector3((transform.position.x + scrollSpeed * Time.deltaTime), transform.position.y, transform.position.z);

        if (transform.position.x >= 15f)
            transform.position = new Vector3(-15f, transform.position.y, transform.position.z);
    }
}
