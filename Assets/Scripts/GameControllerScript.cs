using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameControllerScript : MonoBehaviour {

  GameObject Player;
  PlayerScript playerScript;
  public GameObject gameOverTextObject;
  float masterTime = 0;
  public GameObject timeView;
  Text timeText;

  void Start() {
    Player = PlayerScript.playerScript.gameObject;
    playerScript = PlayerScript.playerScript;
    gameOverTextObject.SetActive(false);
    timeText = timeView.GetComponent<Text>();
  }

  void Update() {
    if (playerScript.alive) {
      masterTime += Time.deltaTime;
      timeText.text = masterTime.ToString();
    }
    else {
      Player.SetActive(false);
      gameOverTextObject.SetActive(true);
    }
  }
}
