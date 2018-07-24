using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*Пропасть*/

public class Death : MonoBehaviour
{
    public GameObject game;

    private void OnTriggerEnter2D(Collider2D other)                                //Вызов метода отслеживающего упавшего игрока
    {
        game.GetComponent<Game>().RespawnDeath(other); 
    }
}
