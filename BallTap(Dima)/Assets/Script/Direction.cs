using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Direction : MonoBehaviour
{
    private Vector3 PlatformPosition;
    public Vector2 Napravlenie;

    private SpriteRenderer sprite;
    private float a;
    private float b;
    private float rad, grad;

    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    //Вращение целеуказателя и получение направления в котором полетит шарик
    void MoveDirection()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Napravlenie = new Vector2(mousePos.x, mousePos.y);
        Vector3 difference = mousePos - transform.position;
        difference.Normalize();
        float rotation_z = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotation_z - 90);
    }

    void Rendererskin()
    {
        sprite.enabled = false;
    }
}
