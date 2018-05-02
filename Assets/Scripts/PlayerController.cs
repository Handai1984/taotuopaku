using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float speed;//movespeeed;


	public Sprite hideSprite;//被子图片
	public Sprite[] sprites;//角色移动动画帧
	private SpriteRenderer spriteRendeer;//渲染器
	private BoxCollider2D boxcd;//碰撞器



	void Start()
	{
		
		spriteRendeer = GetComponent<SpriteRenderer> ();
		boxcd = GetComponent<BoxCollider2D> ();
	}
	void Update()
	{
		if (GM.instance.isover) {
			return;
		}
		Move ();
	}


	void Move()
	{
		int index = (int)(Time.time * speed) % sprites.Length;
		if (Input.GetMouseButton (0)) {
			boxcd.enabled = false;
			GM.instance.istouch = true;
			spriteRendeer.sprite = hideSprite;
			return;
		}
//
//		anim.SetBool ("isMove",true);
//		transform.Translate (Vector2.up *speed*Time.deltaTime);
		boxcd.enabled = true;
		GM.instance.istouch= false;

		spriteRendeer.sprite = sprites [index];

	}

	public void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.CompareTag ("enemy")) {
			GM.instance.dieAudio.Play ();
			GM.instance.istouch = true;
			GM.instance.reStartUI.SetActive (true);
			GM.instance.bannerUI.SetActive (true);
			GM.instance.ShowCurrentScore ();
			GM.instance.ShowHighScore ();
			GoogleGM.googlegm.GADInterstitalShow ();
			gameObject.SetActive (false);
		}
	}

}
