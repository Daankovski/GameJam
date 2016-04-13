using UnityEngine;
using System.Collections;

public class PlayerBehaviour : MonoBehaviour {

    private Vector3 mousePosition;
    private Vector3 startPos;
    private TrailRenderer playerTrail;
    private float moveSpeed;
    private Vector2 spawnPosition;
    private LapTimer lapTimer;

    void Start() {
        spawnPosition = GameObject.FindWithTag("Spawnpoint").transform.position;
        moveSpeed = .1f;
        playerTrail = GameObject.Find("Player").GetComponent<TrailRenderer>();
        playerTrail.enabled = false;
        lapTimer = GameObject.Find("TimeText").GetComponent<LapTimer>();
    }

	void Update () {
        if (Input.GetMouseButton(0))
        {
            playerTrail.enabled = true;
            mousePosition = Input.mousePosition;
            mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
            transform.position = Vector2.Lerp(transform.position, mousePosition, moveSpeed);
        }
        else {
            transform.position = spawnPosition;
            playerTrail.enabled = false;
            mousePosition = spawnPosition;
        }
        
    }

    void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.name == "TimeStart" )
        {
            lapTimer.BeginTimer = true;
            GameObject.Find("TimeStart").GetComponent<BoxCollider2D>().enabled = false;
        }
        else if (col.gameObject.name == "TimeStop") {
            lapTimer.BeginTimer = false;
        }

        if (col.name == "Level_1")
        {
            this.transform.position = spawnPosition;
            playerTrail.enabled = false;
        }
    }
}
