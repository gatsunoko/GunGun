using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour {

  public bool alive = true;
  Animator animator;
  Rigidbody2D rigid2d;
  GameObject player;
  public float speed = 1.0f;
  public GameObject bodyCollider;

  void Start() {
    animator = GetComponent<Animator>();
    rigid2d = GetComponent<Rigidbody2D>();
    this.player = PlayerScript.playerScript.gameObject;
  }

  void FixedUpdate() {
    if (alive) {
      Vector3 velocity = gameObject.transform.rotation * new Vector3(speed, 0, 0);
      this.rigid2d.velocity = new Vector2(velocity.x, velocity.y);
    }
    else {
      this.rigid2d.velocity = new Vector2(0, 0);
    }
  }

  void Update() {
    Vector3 target = new Vector3(player.transform.position.x, player.transform.position.y, 0);
    var vec = (target - transform.position).normalized;
    var angle = (Mathf.Atan2(vec.y, vec.x) * Mathf.Rad2Deg);
    transform.rotation = Quaternion.Euler(0.0f, 0.0f, angle);
  }

  private void OnTriggerEnter2D(Collider2D col) {
    if (col.gameObject.tag == "PlayerAttack") {
      this.alive = false;
      this.bodyCollider.SetActive(false);
      animator.SetTrigger("Dead");
    }
  }

  void EnemyDestroy() {
    Destroy(gameObject);
  }
}
