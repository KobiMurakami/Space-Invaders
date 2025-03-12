using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    private Rigidbody2D rb;
    public float moveSpeed = 2f;
    public GameObject EnemyBlock;
    public double moveTime;

    // Start is called before the first frame update
    void Start()
    {
        rb = EnemyBlock.GetComponent<Rigidbody2D>();
        moveTime = Math.Round(Time.time);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        while(true) {
            while(rb.position.x > -8) {
                rb.velocity = new Vector2(-moveSpeed, rb.velocity.x);
            }
            rb.velocity = new Vector2(0, rb.velocity.y);
            moveTime = Math.Round(Time.time);
            while(Math.Round(Time.time) - moveTime < 2) {
                rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
            }
            while(rb.position.x < 8) {
                rb.velocity = new Vector2(moveSpeed, rb.velocity.x);
            }
        }
    }
}
