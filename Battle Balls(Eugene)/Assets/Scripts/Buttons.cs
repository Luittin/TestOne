using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

/*Кнопки*/

public class Buttons : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        switch(gameObject.name)
        {
            case "EXIT(Clone)": SceneManager.LoadScene("mainmenu"); Time.timeScale = 1f; break;
            case "RETURN(Clone)": SceneManager.LoadScene("BattleBalls"); Time.timeScale = 1f; break;
            case "NEW GAME": SceneManager.LoadScene("BattleBalls"); break;
            case "QUIT THE GAME": Application.Quit(); break;
        }
    }
}
