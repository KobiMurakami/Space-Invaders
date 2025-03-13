using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
  public GameObject bullet;
  public Transform shootingOffset;
  public delegate void PlayerDied();
  public static event PlayerDied OnPlayerDied;
  public Animator playerAnimator;
  public GameObject death;
  public AudioSource audioSource;

  void Start() {
    playerAnimator = GetComponent<Animator>();
    audioSource = GetComponent<AudioSource>();
  }

  // Update is called once per frame
  void Update()
  {
    if (Input.GetKeyDown(KeyCode.Space)) {
      playerAnimator.SetTrigger("playerShoot");
      audioSource.Play();
      GameObject shot = Instantiate(bullet, shootingOffset.position, Quaternion.identity);
      Debug.Log("Bang!");

      Destroy(shot, 8f);

    }
  }

  void OnCollisionEnter2D(Collision2D collision) {
    Debug.Log("Player Hit Detected");
    GameObject dead = Instantiate(death, this.gameObject.GetComponent<Transform>().position, Quaternion.identity);
    Destroy(collision.gameObject);
    Destroy(this.gameObject);
    OnPlayerDied?.Invoke();
  }
}
