using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombeColor : MonoBehaviour
{
    private SpriteRenderer spriteRend;
    [SerializeField] private GameObject PaintSpash = null;

    void Start()
    {
        spriteRend = GetComponent<SpriteRenderer>();
        spriteRend.color = Random.ColorHSV();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            GameManager.Instance.IdLayer--;
            GameObject paintSplash =  Instantiate(PaintSpash, new Vector3(transform.position.x, transform.position.y, GameManager.Instance.IdLayer), Quaternion.identity) as GameObject;
            paintSplash.GetComponent<SpriteRenderer>().color = spriteRend.color;
            collision.GetComponent<DrawLines>().liObjectColor.Add(paintSplash);

            DrawLines drawLine = collision.GetComponent<DrawLines>();
            drawLine.changeLineColor = true;
            GameManager.Instance.IdLayer--;
            drawLine.CreateLine();

            Destroy(gameObject);
        }
    }
}
