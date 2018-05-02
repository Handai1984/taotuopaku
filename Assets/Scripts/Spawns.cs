using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawns : MonoBehaviour {

	public GameObject armlight;



	void Start()
	{
		StartCoroutine (TurnSpawns ());
	}

	IEnumerator TurnSpawns()
	{
		if (!GM.instance.isover) {
			
			int index = Random.Range (1, 5);
			yield return new WaitForSeconds (index);
			if (!GM.instance.istouch) {
				
				Instantiate (armlight,transform.position,Quaternion.identity);
			}
			print ("hello");
			yield return new WaitForSeconds (10f);
		}
		yield return new WaitForSeconds (1f);

		StartCoroutine (TurnSpawns ());

	}

}
