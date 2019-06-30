using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletChanger : MonoBehaviour {

  GameObject Player;
  PlayerScript playerScript;
  public int bulletNumber = 0;
  Animator animator;

  void Start() {
    Player = PlayerScript.playerScript.gameObject;
    playerScript = PlayerScript.playerScript;
    animator = GetComponent<Animator>();
  }

  void Update() {
  }

  private void OnTriggerEnter2D(Collider2D col) {
    if (col.gameObject.tag== "PlayerAttack") {
      playerScript.currentWepon = bulletNumber;
      playerScript.machinegunBullet += 100;
      animator.SetTrigger("Dead");
    }
  }

  void DestroyMe() {
    Destroy(gameObject);
  }
}
