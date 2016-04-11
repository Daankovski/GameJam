using UnityEngine;
using System.Collections;
using System.Windows.Forms;
using System.Drawing;

public class HideMouse : MonoBehaviour {

	void Update () {
        if (UnityEngine.Application.isPlaying)
        {
            System.Windows.Forms.Cursor.Hide();
        }
        else
        {
            System.Windows.Forms.Cursor.Show();
        }
	}
}
