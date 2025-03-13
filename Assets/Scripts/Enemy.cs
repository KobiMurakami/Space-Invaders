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
    public Animator enemyAnimator;
    public GameObject death;
    public AudioSource audioSource;


    // Start is called before the first frame update
    void OnCollisionEnter2D(Collision2D collision)
    {
      Debug.Log("Ouch!");
      GameObject dead = Instantiate(death, this.gameObject.GetComponent<Transform>().position, Quaternion.identity);
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
      enemyAnimator = GetComponent<Animator>();
      audioSource = GetComponent<AudioSource>();
    }

    void Update() {
      if(this.name == "RedEnemy") {
        if(Time.time - lastShotTime > 3) {
          GameObject shot = Instantiate(bullet, shootingOffset.position, Quaternion.identity);
          audioSource.Play();
          Debug.Log("Setting Enemy Shoot Trigger");
          enemyAnimator.SetTrigger("enemyShoot");
          Debug.Log("Bang!");
          Destroy(shot, 8f);
          lastShotTime = Math.Round(Time.time);
        }
      }
    }
}
