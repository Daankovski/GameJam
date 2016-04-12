using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HighscorePanel : MonoBehaviour {

	public GameObject panelPrefab;
	public Transform content;

	void Start () {
		StartCoroutine (spawnPanel ());
	}

	void Update () {
	
	}

	IEnumerator spawnPanel() {
		Highscore.GetHighscore (GetComponent<Highscore> ());

		yield return new WaitUntil (() => Highscore.returnValue != "");

		string[] scores = Highscore.returnValue.Split('/');

		for (int i = 1; i < scores.Length; i++) {
			GameObject panel = Instantiate (panelPrefab);
			panel.transform.SetParent(content);

			string[] userInfo = scores [i].Split ('+');

			Text text = panel.transform.FindChild ("NAME_SCORE").GetComponent<Text> ();
			text.text = userInfo[0].Replace("username:", "") + " " + Highscore.FloatToTime(float.Parse(userInfo[1].Replace("time:", "")));
		}
	}
}
