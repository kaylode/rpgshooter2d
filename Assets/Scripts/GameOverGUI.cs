using UnityEngine;
using System.Collections;

public class GameOverGUI : MonoBehaviour {

	void OnGUI() {
		GUI.Box (new Rect(Screen.width / 2 - 150 / 2, Screen.height / 2 - 25 / 2, 150, 25), "Game Over :(");

		if (GUI.Button (new Rect(Screen.width / 2 - 150 / 2, Screen.height / 2 + 50, 150, 25), "Restart")) {
			GameScore.scene = 0;
			GameScore.resetScore();
			Application.LoadLevel("GameScene");
		}
	}

}
