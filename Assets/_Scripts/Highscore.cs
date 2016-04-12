using UnityEngine;
using System.Collections;

public class Highscore : MonoBehaviour {
	static string websiteUrlSave = "www.dyregames.com/uploadScore.php";
	static string websiteUrlGet = "dyregames.com/returnScore.php";
	public static string returnValue = "";

	/// <summary>
	/// Upload score to server.
	/// </summary>
	/// <param name="username">Parameter value for the username.</param>
	/// <param name="time">Parameter value for the time the user got.</param>
	public static void SaveHighscore(string username, float time, Highscore highScore) 
	{
		highScore.StartCoroutine (UploadScore (username, time));
	}

	static IEnumerator UploadScore(string username, float time) 
	{
		yield return new WaitForEndOfFrame ();

		WWWForm form = new WWWForm();
		form.AddField("username", username);
		form.AddField ("time", time.ToString());

		// Upload to a cgi script
		WWW www = new WWW(websiteUrlSave, form);
		yield return www;

		if (!string.IsNullOrEmpty(www.error)) {
			Debug.Log(www.error + "error");
		}
		else {
			Debug.Log("Finished Uploading Score!");
		}
	}

	/// <summary>
	/// Returns score from server.
	/// </summary>
	/// <param name="username">Parameter value for the username.</param>
	/// <param name="time">Parameter value for the time the user got.</param>
	public static void GetHighscore(Highscore highScore) {
		highScore.StartCoroutine (GetScore ());
	}

	public static string FloatToTime(float time) {
		float seconds = Mathf.Floor(time % 60);
		float minutes = Mathf.Floor((time / 60) % 60);
		string result = (seconds > 9) ? minutes + ":" + seconds : minutes + ":0" + seconds;
		return result;
	}

	public static string[] StringToUserinfo(string r) {
		string[] all = (string[])r.Split('/');
		Debug.Log (all);
		return all;
	} 

	public static string[] UserinfoToBlock(string r) {
		string[] info = r.Split ('/');
		info [0].Replace ((string)"/username:", "");
		info [1].Replace ((string)"time:", "");
		Debug.Log (info);
		return info;
	}

	static IEnumerator GetScore() 
	{
		yield return new WaitForEndOfFrame ();

		// Upload to a cgi script
		WWW www = new WWW(websiteUrlGet);
		yield return www;

		if (!string.IsNullOrEmpty(www.error)) {
			Debug.Log(www.error);
		}
		else {
			returnValue = www.text;
			Debug.Log (returnValue);
		}
	}
}
