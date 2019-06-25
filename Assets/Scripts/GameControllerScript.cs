using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControllerScript : MonoBehaviour {

  GameObject Player;
  PlayerScript playerScript;
  public GameObject gameOverTextObject;

  void Start() {
    Player = PlayerScript.playerScript.gameObject;
    playerScript = PlayerScript.playerScript;
    gameOverTextObject.SetActive(false);
  }

  void Update() {
    if (!playerScript.alive) {
      Player.SetActive(false);
      gameOverTextObject.SetActive(true);
    }
  }
}
