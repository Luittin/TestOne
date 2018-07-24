using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RotationPlatform : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public FrostEffect frostEffect;
    private IEnumerator coroutine;

    public float speed;

	void FixedUpdate () {

        transform.Rotate(0.0f, 0.0f, speed);

	}

    public IEnumerator GlaciationScreen(float waitSecond)
    {
        while (true)
        {
            frostEffect.FrostAmount += Time.deltaTime;
            yield return new WaitForSeconds(waitSecond);
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        coroutine = GlaciationScreen(0.05f);
        StartCoroutine(coroutine);
        speed = -0.5f;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        speed = -2.0f;
        StopAllCoroutines();
        frostEffect.FrostAmount = 0.2f;
    }
}
