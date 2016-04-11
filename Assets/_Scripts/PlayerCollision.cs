using UnityEngine;
using System.Collections;

public class PlayerCollision : MonoBehaviour {

    private Vector2 spawnPosition;

    void Start()
    {
        Cursor.visible = false;
        spawnPosition = GameObject.FindWithTag("Spawnpoint").transform.position;
    }

    void OnTriggerEnter2D()
    {
        this.transform.position = spawnPosition;
    }
}
