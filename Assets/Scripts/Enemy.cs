using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public GameObject bullet;
    public Transform shootingOffset;

    public delegate void EnemyDied(String type);
    public static event EnemyDied OnEnemyDied;
    public double lastShotTime;


    // Start is called before the first frame update
    void OnCollisionEnter2D(Collision2D collision)
    {
      Debug.Log("Ouch!");
      Destroy(collision.gameObject);
      Destroy(this.gameObject);

      if(this.name == "RedEnemy") {
        OnEnemyDied?.Invoke("red");
      }
      if(this.name == "BlueEnemy") {
        OnEnemyDied?.Invoke("blue");
      }
      if(this.name == "GreenEnemy") {
        OnEnemyDied?.Invoke("green");
      }
      if(this.name == "YellowEnemy") {
        OnEnemyDied?.Invoke("yellow");
      }
    }

    void Start() {
      lastShotTime = Math.Round(Time.time);
    }

    void Update() {
      if(this.name == "RedEnemy") {
        if(Time.time - lastShotTime > 3) {
          GameObject shot = Instantiate(bullet, shootingOffset.position, Quaternion.identity);
          Debug.Log("Bang!");
          Destroy(shot, 8f);
          lastShotTime = Math.Round(Time.time);
        }
      }
    }
}
