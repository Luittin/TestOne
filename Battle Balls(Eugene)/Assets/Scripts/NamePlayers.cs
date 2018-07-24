using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*Ввод имени игроков*/

public class NamePlayers : MonoBehaviour
{
    public InputField Name1, Name2;

    public Text NamePlayer1, NamePlayer2;

    public void NameOne()                               //Имя первого игрока
    {
        if (!string.IsNullOrEmpty(Name1.text))
            NamePlayer1.text = "<color=red>" + Name1.text + "</color>";
        else NamePlayer1.text = "<color=red>One</color>";
    }

    public void NameTwo()                               //Имя второго игрока
    {
        if (!string.IsNullOrEmpty(Name2.text))
        NamePlayer2.text = "<color=blue>" + Name2.text + "</color>";
        else NamePlayer2.text = "<color=blue>Two</color>";
    }
}
