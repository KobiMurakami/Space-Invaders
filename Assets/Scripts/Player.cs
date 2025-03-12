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

  void Start() {

  }

  // Update is called once per frame
  void Update()
  {
    if (Input.GetKeyDown(KeyCode.Space)) {
      GameObject shot = Instantiate(bullet, shootingOffset.position, Quaternion.identity);
      Debug.Log("Bang!");

      Destroy(shot, 8f);

    }
  }

  void OnCollisionEnter2D(Collision2D collision) {
    Debug.Log("Player Hit Detected");
    Destroy(collision.gameObject);
    Destroy(this.gameObject);
    OnPlayerDied?.Invoke();
  }
}
