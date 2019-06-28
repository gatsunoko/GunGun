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
  public GameObject againButton;
  AudioSource dead_sound;
  bool deadAfter = false;//死亡した後一回だけ実行する部分を実行したかどうか

  void Start() {
    Player = PlayerScript.playerScript.gameObject;
    playerScript = PlayerScript.playerScript;
    gameOverTextObject.SetActive(false);
    againButton.SetActive(false);
    timeText = timeView.GetComponent<Text>();
    AudioSource[] audioSources = GetComponents<AudioSource>();
    dead_sound = audioSources[0];
  }

  void Update() {
    if (playerScript.alive) {
      masterTime += Time.deltaTime;
      timeText.text = masterTime.ToString();
    }
    else {
      if (!deadAfter) {
        deadAfter = true;
        Player.SetActive(false);
        gameOverTextObject.SetActive(true);
        againButton.SetActive(true);
        dead_sound.PlayOneShot(dead_sound.clip);
      }
    }
  }
}
