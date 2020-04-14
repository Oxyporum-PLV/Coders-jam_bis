using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    private Rigidbody2D rb;


    public float speed = 2.0f;
    private int jumpCount = 1;
    private int currentJumps;
    private int dashCount = 0;

    public bool canWallJump = false;



    // Start is called beore the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        currentJumps = jumpCount;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Q)) {
            Debug.Log("Je vais à droite");
            
        }

        else if (Input.GetKey(KeyCode.D)) {
            Debug.Log("Je vais à Gauche");
            
        }

        if (Input.GetKeyDown(KeyCode.Space && currentJumps > 0)) {
            Debug.Log("Je vais sauter");
            Jumping();
        }

    }

    void Jumping() {

    }

    void onTriggerEnter2D(collider other) {

    }
}
