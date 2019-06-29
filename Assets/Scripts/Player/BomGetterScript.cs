using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BomGetterScript : MonoBehaviour {

  GameObject gameController;
  GameControllerScript gameControllerScirpt;

  void Start() {
    gameController = GameObject.FindWithTag("GameController");
    gameControllerScirpt = gameController.GetComponent<GameControllerScript>();
  }
  
  void Update() {
    
  }

  private void OnTriggerEnter2D(Collider2D col) {
    if (col.gameObject.tag == "PlayerAttack") {
      gameControllerScirpt.bomCount += 1;
      Destroy(gameObject);
    }
  }
}
