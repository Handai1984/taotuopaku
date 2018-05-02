using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOffScreen : MonoBehaviour {

	public float offset=5f;//屏幕差值

	private float offScreenY;


	void Start()
	{
		offScreenY = Screen.height / 2/100+ offset;
		print (offScreenY);
	}

	void Update()
	{
		var posY = transform.position.y;
		if (Mathf.Abs(posY)>offScreenY) {
			Destroy (gameObject);
		}
	}

}
