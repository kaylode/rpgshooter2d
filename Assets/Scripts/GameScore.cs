using UnityEngine;
using System.Collections;

public class GameScore : MonoBehaviour {

	public static int scene;
	private static int score;

	public static void adjustScoreBy(int amount) {
		score += amount;
	}

	public static void resetScore() {
		score = 0;
	}

	void Start() {
		DontDestroyOnLoad(this.gameObject);
	}

	void OnGUI() {
		if (scene == 0) {
			GUI.Box(new Rect(10, 10, 100, 25), "Score: " + score);
		} else if (scene == 1) {
			GUI.Box(new Rect(Screen.width / 2 - 150 / 2, Screen.height / 2 + 100, 150, 25), "Score: " + score);
		}
	}

}
