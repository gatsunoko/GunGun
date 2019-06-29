using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BomButtonScript : MonoBehaviour {

  public GameObject bom;
  public GameObject bomTextObject;
  Text bomText;
  float time = 0;
  bool bomAttack = false;
  GameObject gameController;
  GameControllerScript gameControllerScirpt;

  void Start() {
    gameController = GameObject.FindWithTag("GameController");
    gameControllerScirpt = gameController.GetComponent<GameControllerScript>();
    bomText = bomTextObject.GetComponent<Text>();
    bomText.text = gameControllerScirpt.bomCount.ToString();
  }
  
  void Update() {
    bomText.text = gameControllerScirpt.bomCount.ToString();
    //ボタンが押された時に爆発させる
    if (bomAttack) {
      //一定時間でボム消す
      time += Time.deltaTime;
      if (time >= 1.0f) {
        time = 0;
        bom.SetActive(false);
        bomAttack = false;
      }
    }
  }

  public void Bom() {
    if (!bomAttack && gameControllerScirpt.bomCount > 0) {
      gameControllerScirpt.bomCount -= 1;
      bom.SetActive(true);
      bomAttack = true;
    }
  }
}
