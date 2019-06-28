using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineGunScript : MonoBehaviour {

  Rigidbody2D rigid2d;

  void Start() {
    rigid2d = GetComponent<Rigidbody2D>();
  }

  void FixedUpdate() {
    Vector3 velocity = gameObject.transform.rotation * new Vector3(10, 0, 0);
    this.rigid2d.velocity = new Vector2(velocity.x, velocity.y);
  }

  void Update() {
    //画面の外にでたら消す
    if (!GetComponent<Renderer>().isVisible) {
      Destroy(this.gameObject);
    }
  }
}
