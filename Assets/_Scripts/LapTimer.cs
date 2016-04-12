using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LapTimer : MonoBehaviour {


	float lap = 0;
	float startTime = 0;
	float lapTime = 0;
	float bestLap = 100;
	private bool begin = false;
    private Text timeText;


    public bool BeginTimer {
        get { return begin; }
        set{ begin = value; }
    }




	void startLap () {
		if (begin == true) {
			startTime = Time.time;
		}
	}

    void Start() {
        timeText = GameObject.Find("TimeText").GetComponent<Text>();
    }

	void Update () {

		//Debug.Log (startTime);
		if (begin == true) { 
			lapTime = Time.time - startTime;
            timeText.text = lapTime.ToString();
			Debug.Log (timeText);
		}
	}

	void OnTriggerExit(Collider other)
	{
		if (other.tag == "Begin") 
		{
			begin = true;
			startLap ();

		}

		if (other.tag == "Finish") {
			
			begin = false;

			if (lapTime < bestLap) 
			{
				bestLap = lapTime;
			}
			startTime = 0;
			lapTime = 0;
			lap ++;
			Debug.Log (bestLap);
			Debug.Log (lap);

		}


	}
}
