using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightmove : MonoBehaviour {
	public float speed=0.5f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (GM.instance.istouch) {
			return;
		}
		transform.Translate (Vector2.down*speed*Time.deltaTime);

	}
}
