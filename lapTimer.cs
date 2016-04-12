using UnityEngine;
using System.Collections;

public class lapTimer : MonoBehaviour {


	float lap = 0;
	float startTime = 0;
	float lapTime = 0;
	float bestLap = 100;
	public bool begin = false;





	void startLap () {
		if (begin == true) {
			startTime = Time.time;
		}
	}



	void Update () {

		//Debug.Log (startTime);
		if (begin == true) { 
			lapTime = Time.time - startTime;

			//Debug.Log (lapTime);
		}
		}

	void OnTriggerEnter(Collider other)
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
