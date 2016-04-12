using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TestScript : MonoBehaviour {
	public InputField user;
	public InputField time;
	public Highscore hscore;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void UploadScore() {
		Highscore.SaveHighscore (user.text, float.Parse (time.text), hscore);
		Highscore.GetHighscore (hscore);
		Debug.Log (Highscore.returnValue);
	//	Debug.Log (Highscore.UserinfoToBlock(Highscore.StringToUserinfo (Highscore.returnValue)));
	}
}
