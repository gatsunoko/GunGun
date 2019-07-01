using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGeneraterScirpt : MonoBehaviour {

  float time = 0;
  float span = 0.5f;
  float generateTime = 0;
  public GameObject[] Enemies;
  int[] instancePosition = { 1, 2, 3, 4 }; //敵生成位置、１上、２右、３下、４左

  void Start() {
  
  }

  void Update() {
    time += Time.deltaTime;
    if (time > span) {
      time = 0;
      //敵生成位置ランダムで決める
      int i = Random.Range(1, 5);
      float x = 0; ;
      float y = 0; ;
      if (i == 1) {
        x = Random.Range(-8.29f, 8.27f);
        y = -14.09f;
      }
      else if (i == 2) {
        x = 9.63f;
        y = Random.Range(-14.09f, -25.96f);
      }
      else if (i == 3) {
        x = Random.Range(-8.29f, 8.27f);
        y = -26.27f;
      }
      else if (i == 4) {
        x = -9.66f;
        y = Random.Range(-14.09f, -25.96f);
      }
      //生成する敵をランダムで選ぶ
      int enemyI;
      GameObject Enemy;
      //時間によって生成される敵をかえていく
      if (generateTime > 120.0f) {
        enemyI = Random.Range(2, Enemies.Length);
        Enemy = Enemies[enemyI];
      }
      else if (generateTime > 90.0f) {
        enemyI = Random.Range(1, Enemies.Length);
        Enemy = Enemies[enemyI];
      }
      else if (generateTime > 30.0f) {
        enemyI = Random.Range(0, Enemies.Length);
        Enemy = Enemies[enemyI];
      }
      else {
        enemyI = Random.Range(0, 2);
        Enemy = Enemies[enemyI];
      }

      //敵生成
      var parent = this.transform;
      if (this.transform.childCount < 60) {
        GameObject instanceEnemy = Instantiate(Enemy, parent) as GameObject;
        instanceEnemy.transform.position = new Vector2(x, y);
      }
    }

    //時間経過で敵の生成スピードあげていく
    generateTime += Time.deltaTime;
    if (generateTime > 75.0f) {
      span = 0.05f;
    }
    else if (generateTime > 100.0f) {
      span = 0.08f;
    }
    else if (generateTime > 75.0f) {
      span = 0.10f;
    }
    else if (generateTime > 70.0f) {
      span = 0.13f;
    }
    else if (generateTime > 65.0f) {
      span = 0.15f;
    }
    else if (generateTime > 60.0f) {
      span = 0.18f;
    }
    else if (generateTime > 50.0f) {
      span = 0.21f;
    }
    else if (generateTime > 45.0f) {
      span = 0.23f;
    }
    else if (generateTime > 40.0f) {
      span = 0.25f;
    }
    else if (generateTime > 35.0f) {
      span = 0.3f;
    }
    else if (generateTime > 25.0f) {
      span = 0.5f;
    }
    else if (generateTime > 20.0f) {
      span = 0.6f;
    }
    else if (generateTime > 15.0f) {
      span = 0.8f;
    }
    else if (generateTime > 10.0f) {
      span = 1.0f;
    }
    else if (generateTime > 5.0f) {
      span = 1.2f;
    }
    else if (generateTime > 1.0f) {
      span = 1.5f;
    }
  }
}
