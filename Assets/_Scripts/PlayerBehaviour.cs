using UnityEngine;
using System.Collections;

public class PlayerBehaviour : MonoBehaviour {

	RectTransform rectTransform;

	void Start () {
		rectTransform = transform.GetComponent<RectTransform> ();
	}

	void Update () {
		rectTransform.sizeDelta  = new Vector2(rectTransform.sizeDelta.x, transform.childCount * 100);
	}
}
