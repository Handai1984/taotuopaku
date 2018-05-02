using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PilotLamp : MonoBehaviour
{

	public Vector3 offset;
	public float speed;
	public Vector2 randSpeed = new Vector2 (0.1f, 2f);
	public float angle = 60f;

	void Start ()
	{
		StartCoroutine (MoveLight ());
	}

	void Update ()
	{
		if (GM.instance.isover) {
			return;
		}
		transform.rotation = Quaternion.Lerp (transform.rotation, Quaternion.Euler (offset), speed * Time.deltaTime);
	}



	IEnumerator MoveLight ()//固定旋转角度
	{
		RandSpeed ();
		offset = new Vector3 (0, 0, angle);
		yield return new WaitForSeconds (3f);
		offset = new Vector3 (0, 0, -angle);
		yield return new WaitForSeconds (3f);
		StartCoroutine (MoveLight ());
	}

	void RandSpeed ()//随机速度
	{
		speed = Random.Range (randSpeed.x, randSpeed.y);
	}
}
