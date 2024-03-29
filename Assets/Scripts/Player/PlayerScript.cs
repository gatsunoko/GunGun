﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {
  public static PlayerScript playerScript;

  Rigidbody2D rigid2d;
  public GameObject[] bullet;
  private Vector3 position;// 位置座標
  private Vector3 screenToWorldPointPosition;// スクリーン座標をワールド座標に変換した位置座標
  public bool alive = true;
  float machinegunTime = 0;
  public int machinegunBullet = 0;
  public int currentWepon = 0;

  void Awake() {
    playerScript = this;
  }

  void Start() {
  }

  void Update() {
    if (alive) {
      position = Input.mousePosition;// Vector3でマウス位置座標を取得する
      position.z = 10f;// Z軸修正
      screenToWorldPointPosition = Camera.main.ScreenToWorldPoint(position);// マウス位置座標をスクリーン座標からワールド座標に変換する

      Vector3 target = new Vector3(screenToWorldPointPosition.x, screenToWorldPointPosition.y, 0);
      var vec = (target - transform.position).normalized;
      var angle = (Mathf.Atan2(vec.y, vec.x) * Mathf.Rad2Deg);
      transform.rotation = Quaternion.Euler(0.0f, 0.0f, angle);

      //マシンガンの残り弾があればマシンガンにする
      if (machinegunBullet > 0) {
        currentWepon = 1;
      }
      else {
        currentWepon = 0;
      }

      if (currentWepon == 0) {
        if (Input.GetMouseButtonDown(0)) {
          Attack();
        }
      }
      else if (currentWepon == 1) {
        if (Input.GetMouseButton(0)) {
          machinegunTime += Time.deltaTime;
          if (machinegunTime >= 0.1f) {
            machinegunTime = 0;
            Machinegun();
          }
        }
        else {
          machinegunTime = 1.0f;
        }
      }
    }
  }

  void Attack() {
    var parent = this.transform;
    GameObject shot = Instantiate(bullet[0], parent) as GameObject;
    if (transform.localScale.x > 0) {
      shot.transform.localPosition = new Vector2(1.014f, 0);
      shot.transform.SetParent(null);//親子関係解消
      shot.transform.rotation = transform.rotation;
    }
  }

  void Machinegun() {
    machinegunBullet -= 1;
    var parent = this.transform;
    GameObject shot = Instantiate(bullet[1], parent) as GameObject;
    if (transform.localScale.x > 0) {
      shot.transform.localPosition = new Vector2(1.014f, 0);
      shot.transform.SetParent(null);//親子関係解消
      shot.transform.rotation = transform.rotation;
    }
  }

  private void OnTriggerEnter2D(Collider2D col) {
    if (col.gameObject.tag == "Enemy") {
      this.alive = false;
    }
  }
}
