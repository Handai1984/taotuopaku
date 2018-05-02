using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backgroundmove : MonoBehaviour
{

	private Material mat;
	public  Vector2 moveSpeed;
	private float offset;

	void Start ()
	{
		mat = GetComponent<Renderer> ().material;

	}

	void LateUpdate ()
	{
		if (GM.instance.istouch) {
			return;
		}
		
		offset += moveSpeed.y * Time.deltaTime;
		mat.SetTextureOffset ("_MainTex", new Vector2(0,offset));
		GM.instance.GetScore ();
	}
}
