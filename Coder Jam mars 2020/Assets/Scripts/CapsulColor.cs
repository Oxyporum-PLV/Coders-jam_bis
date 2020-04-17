using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapsulColor : MonoBehaviour
{
    private SpriteRenderer spriteRend;
    void Start()
    {
        spriteRend = GetComponent<SpriteRenderer>();
        spriteRend.color = Random.ColorHSV();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            DrawLines drawLine = collision.GetComponent<DrawLines>();
            drawLine.changeLineColor = true;
            drawLine.lineRendColor = spriteRend.color;
            drawLine.CreateLine();
            Destroy(gameObject);
        }
    }

}
