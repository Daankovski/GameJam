using UnityEngine;
using System.Collections;
using System.Windows.Forms;
using System.Drawing;

public class PlayerCollision : MonoBehaviour {

    private Vector2 spawnPosition;

    void Start()
    {
        spawnPosition = GameObject.FindWithTag("Spawnpoint").transform.position;
    }

    void OnTriggerEnter2D()
    {
        ResetMouse();
        this.transform.position = spawnPosition;
    }

    void ResetMouse()
    {
        System.Windows.Forms.Cursor.Position = new System.Drawing.Point(1100, 200);
    }
}
