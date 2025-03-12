using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    private Rigidbody2D rb;
    public float moveSpeed = 30f;
    public GameObject EnemyBlock;
    public float moveDistance = 5f;
    public float downDistance = 3f;
    public float moveInterval = 1f;

    private bool movingRight = true;
    private Vector3 moveDirection;
    private float moveTime;

    // Start is called before the first frame update
    void Start()
    {
        moveTime = Time.time;
    }

    // Update is called once per frame
    private void Update()
    {
        if (Time.time - moveTime >= moveInterval)
        {
            moveTime = Time.time;

            // Move the grid in the current direction
            EnemyBlock.transform.Translate(moveDirection * moveSpeed * Time.deltaTime);

            // If we have reached the end of the allowed movement, change direction
            if (EnemyBlock.transform.position.x >= moveDistance && movingRight)
            {
                movingRight = false;
                moveDirection = Vector3.left;
                // Move down after reaching the end
                EnemyBlock.transform.Translate(Vector3.down * downDistance);
            }
            else if (EnemyBlock.transform.position.x <= -moveDistance && !movingRight)
            {
                movingRight = true;
                moveDirection = Vector3.right;
                // Move down after reaching the end
                EnemyBlock.transform.Translate(Vector3.down * downDistance);
            }
        }
    }

    // void MovementUpdates() {
    //     rb.velocity = new Vector2(-moveSpeed, rb.velocity.x);
    //     // while(rb.position.x > -8) {
            
    //     // }
    //     rb.velocity = new Vector2(0, rb.velocity.y);

    //     // moveTime = Math.Round(Time.time);
    //     // rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
    //     // while(Math.Round(Time.time) - moveTime < 2) {
            
    //     // }
    //     // rb.velocity = new Vector2(0, rb.velocity.y);

    //     rb.velocity = new Vector2(moveSpeed, rb.velocity.x);
    //     // while(rb.position.x < 8) {
            
    //     // }
    //     rb.velocity = new Vector2(0, rb.velocity.y);

    //     // moveTime = Math.Round(Time.time);
    //     // rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
    //     // while(Math.Round(Time.time) - moveTime < 2) {
            
    //     // }
    //     // rb.velocity = new Vector2(0, rb.velocity.y);
    //     // MovementUpdates();
    // }
}
