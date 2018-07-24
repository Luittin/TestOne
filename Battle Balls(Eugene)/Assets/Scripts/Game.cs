using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*Отслеживание игры*/

public class Game : MonoBehaviour
{
    public GameObject respawn1, respawn2, player1, player2, RoundNow, canvas, BackPlate, ExitGround, ex, ret;

    private int PlayerOneScore, PlayerTwoScore, Rounds;

    public bool ActivePlayer, Pause;

    public Text ScoreOne, ScoreTwo, Round, NextRound, exi, retur, NamePlayer1, NamePlayer2;

    private void Start()
    {
        Pause = false;
        Rounds = 0;
        ControlRounds();
        RandomActivePlayer();
        PlayerOneScore = 0;
        PlayerTwoScore = 0;
        ShowRound();
    }

    public void Update() 
    {
        if (Input.GetKeyDown(KeyCode.Escape) && Pause==false && PlayerOneScore !=8 && PlayerTwoScore != 8)              //Запуск паузы
        {
            exi.text = "<color=green>EXIT</color>";
            retur.text = "<color=green>RETURN</color>";
            Instantiate(ex, new Vector3(0f, -3.5f, 0f), Quaternion.identity, canvas.GetComponent<Transform>());
            Instantiate(ret, new Vector3(0f, -2f, 0f), Quaternion.identity, canvas.GetComponent<Transform>());
            Instantiate(BackPlate, new Vector3(0f, 0f, 0f), Quaternion.identity);
            Instantiate(ExitGround, new Vector3(0f, 0f, 0f), Quaternion.identity);
            Pause = true;
            Time.timeScale = 0f;
        }
        else 
            if (Input.GetKeyDown(KeyCode.Escape) && Pause == true && PlayerOneScore != 8 && PlayerTwoScore != 8)        //Снятие паузы
            {
                Destroy(GameObject.FindGameObjectWithTag("EXIT"));
                Destroy(GameObject.FindGameObjectWithTag("RETURN"));
                Destroy(GameObject.FindGameObjectWithTag("BACK"));
                Destroy(GameObject.FindGameObjectWithTag("GROUND"));
                Pause = false;
                Time.timeScale = 1f;
            }
    }

    public void PlayerOne()                                //Слежение за первым игроком
    { 
        PlayerOneScore++;
        ScoreOne.text = "<color=red>" + PlayerOneScore.ToString() + "</color>";
        if (PlayerOneScore == 8)                           //Победа первого игрока
        {
            NextRound.text = "<color=red>VICTORY</color>";
            exi.text = "<color=red>EXIT</color>";
            retur.text = "<color=red>RETURN</color>";
            Instantiate(RoundNow, new Vector3(0f, 2f, 0f), Quaternion.identity, canvas.GetComponent<Transform>());
            Instantiate(NamePlayer1, new Vector3(0f, 0.5f, 0f), Quaternion.identity, canvas.GetComponent<Transform>());
            Instantiate(ex, new Vector3(0f, -3.5f, 0f), Quaternion.identity, canvas.GetComponent<Transform>());
            Instantiate(ret, new Vector3(0f, -2f, 0f), Quaternion.identity, canvas.GetComponent<Transform>());
            Instantiate(BackPlate, new Vector3(0f, 0f, 0f), Quaternion.identity);
            Instantiate(ExitGround, new Vector3(0f, 0f, 0f), Quaternion.identity);
            Time.timeScale = 0f;
        }
        else
        {
            Invoke("ControlRounds", 0.01f);
            Invoke("Respawn", 0.01f);
        }
    }

    public void PlayerTwo()                                //Слежение за первым игроком
    {
        PlayerTwoScore++;
        ScoreTwo.text = "<color=blue>" + PlayerTwoScore.ToString() + "</color>";
        if (PlayerTwoScore == 8)                           //Победа второго игрока
        {
            NextRound.text = "<color=blue>VICTORY</color>";
            exi.text = "<color=blue>EXIT</color>";
            retur.text = "<color=blue>RETURN</color>";
            Instantiate(RoundNow, new Vector3(0f, 2f, 0f), Quaternion.identity, canvas.GetComponent<Transform>());
            Instantiate(NamePlayer2, new Vector3(0f, 0.5f, 0f), Quaternion.identity, canvas.GetComponent<Transform>());
            Instantiate(ex, new Vector3(0f, -3.5f, 0f), Quaternion.identity, canvas.GetComponent<Transform>());
            Instantiate(ret, new Vector3(0f, -2f, 0f), Quaternion.identity, canvas.GetComponent<Transform>());
            Instantiate(BackPlate, new Vector3(0f, 0f, 0f), Quaternion.identity);
            Instantiate(ExitGround, new Vector3(0f, 0f, 0f), Quaternion.identity);
            Time.timeScale = 0f;
        }
        else
        {
            Invoke("ControlRounds", 0.1f);
            Invoke("Respawn", 0.1f);
        }
    }

    public void RespawnDeath(Collider2D other)                                //Отслеживание упавшего игрока
    {
        if (other.tag == "Player_1")
        {
            PlayerTwo();
        }
        else if (other.tag == "Player_2")
        {
            PlayerOne();
        }
    }

    public void Respawn()                               //Возвращение игроков на их начальные позиции
    {
        player1.GetComponent<Rigidbody2D>().velocity = new Vector2(0f,0f);
        player2.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 0f);
        player1.transform.position = respawn1.transform.position;
        player2.transform.position = respawn2.transform.position;
        ChangeActivePlayer();
    }

    private void RandomActivePlayer()                               //Определение ведущего игрока для первого раунда
    {
        int RandomPlayer = (int)Random.Range(0, 2);
        if (RandomPlayer == 1)
        {
            ActivePlayer = true;
        }
        else ActivePlayer = false;
    }

    private void ChangeActivePlayer()                               //Смена ведущего игрока
    {
        if (ActivePlayer == false)
        {
            ActivePlayer = true;
            player1.GetComponent<player_1>().Invoke("ActiveIndex", 0f);
        }
        else
        {
            ActivePlayer = false;
            player2.GetComponent<player_2>().Invoke("ActiveIndex", 0f);
        }
        ShowRound();
    }

    private void ControlRounds()                                //Отслеживание текущего раунда
    {
        Rounds++;
        Round.text = "<color=Black>ROUND : " + Rounds.ToString() + "/15</color>";
    }

    private void ShowRound()                                //Отображение текущего раунда
    {
        if (ActivePlayer == true)
        {
            NextRound.text = "<color=red>" + "ROUND " + Rounds + "</color>";
            Instantiate(RoundNow, new Vector3(0f, 0f, 0f), Quaternion.identity, canvas.GetComponent<Transform>());
            Destroy(GameObject.FindGameObjectWithTag("Rounds"), 1f);
        }
        else
        {
            NextRound.text = "<color=blue>" + "ROUND " + Rounds + "</color>";
            Instantiate(RoundNow, new Vector3(0f, 0f, 0f), Quaternion.identity, canvas.GetComponent<Transform>());
            Destroy(GameObject.FindGameObjectWithTag("Rounds"), 1f);
        }
        
    }
}
