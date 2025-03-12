using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{

    private Rigidbody2D rb;
    public float moveSpeed = 5f;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        rb = player.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(Input.GetKey(KeyCode.RightArrow)) {
            if(rb.position.x < 8) {
                rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
            }
        }
        else if(Input.GetKey(KeyCode.LeftArrow)) {
            if(rb.position.x > -8) {
                rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
            }
        }
        else {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
    }
}
