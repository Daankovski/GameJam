using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MeshScript : MonoBehaviour
{

// public MeshCollider meshCollider;
public PolygonCollider2D meshCollider;
 
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    // replace UpdateCollider function with
    void UpdateCollider(List points, int[] tris)
    {
        if (meshCollider != null)
        {
            Vector2[] points2D = new Vector2[points.Count];

            for (int i = 0; i & lt; points.Count; i++)
        {
                points2D[i] = new Vector2(points[i].x, points[i].y);
            }

            meshCollider.points = points2D;
        }
    }
}
