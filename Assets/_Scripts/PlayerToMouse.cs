using UnityEngine;
using System.Collections;

public class PlayerToMouse : MonoBehaviour {

    private Vector3 mousePosition;

	void Update () {
        mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        transform.position = new Vector2(mousePosition.x, mousePosition.y);
    }
}
