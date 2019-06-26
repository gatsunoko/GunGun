using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGeneraterScirpt : MonoBehaviour {

  float time = 0;
  float span = 0.5f;
  public GameObject Enemy;
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
      //敵生成
      GameObject instanceEnemy = Instantiate(Enemy) as GameObject;
      instanceEnemy.transform.position = new Vector2(x, y);
    }
  }
}
