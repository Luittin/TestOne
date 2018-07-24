using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*Генерация облаков на заднем плане*/

public class RespawnObjects : MonoBehaviour
{

    private int randomcloud;
    public GameObject cloud1, cloud2, cloud3, cloud4;

    private void Start()
    {
        RespawnClouds();
    }

    private void RespawnClouds()                                //Генерация случайных облаков на задем плане                               
    {
        for(int i=0; i<10; i++)
        {
            randomcloud = (int)Random.Range(1, 4);
            switch (randomcloud)
            {
                case 1:
                    Instantiate(cloud1, new Vector3(Random.Range(-14f,14f), Random.Range(1.5f, 6f), 0f), Quaternion.identity);
                    break;
                case 2:
                    Instantiate(cloud2, new Vector3(Random.Range(-14f, 14f), Random.Range(1.5f, 6f), 0f), Quaternion.identity);
                    break;
                case 3:
                    Instantiate(cloud3, new Vector3(Random.Range(-14f, 14f), Random.Range(1.5f, 6f), 0f), Quaternion.identity);
                    break;
                case 4:
                    Instantiate(cloud4, new Vector3(Random.Range(-14f, 14f), Random.Range(1.5f, 6f), 0f), Quaternion.identity);
                    break;
            }
        }
    }
}
