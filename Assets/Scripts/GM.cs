using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GM : MonoBehaviour
{

	public static GM instance;
	public AudioSource startAudio, dieAudio;
	public GameObject startUI, soundOnUI, soundOffUI, reStartUI,bannerUI;
	public Text scoreText,currentText,HighText;
	public bool istouch = true;
//手指是否按下
	public bool isover = true;
//游戏是否结束
	private bool ispause = false;
	private int score,highscore;
//得分

//广告
	public ad admob;

	void Awake ()
	{
		
		instance = this;
		score = 0;
	highscore=	PlayerPrefs.GetInt ("score",0);
		print ("上次最高分是"+highscore);
	}

	void Update()
	{
		ShowScore ();
	}


	public void StartGame ()//开始游戏
	{
		isover = false;
//		istouch = false;
		startUI.SetActive (false);
	
	}

	public void ReStart ()//重新开始游戏
	{
		SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
	}

	public void PauseGame ()//游戏暂停
	{
		ispause = !ispause;
		if (ispause) {
			
			Time.timeScale = 0;
		} else {
			Time.timeScale = 1;
		}
	}

	public void MusicOn ()//音乐开启
	{
		startAudio.Play ();
		soundOnUI.SetActive (true);
		soundOffUI.SetActive (false);
	}

	public void MusicOff ()//音乐关闭
	{
		startAudio.Stop ();
		soundOffUI.SetActive (true);
		soundOnUI.SetActive (false);
	}

	public void GetScore ()//获得分数
	{
		score++;
		if (score>highscore) {
			highscore = score;
			PlayerPrefs.SetInt ("score",highscore);
//			print (highscore);
		}
	}

	public void ShowScore ()//展示分数
	{
		scoreText.text = score/100 + "M";
	}

	public void ShowCurrentScore()
	{
		currentText.text = score/100 + "M";
	}

	public  void ShowHighScore()
	{
		
		HighText.text = highscore/100 + "M";
	}

	public void Showad() {
	
		admob.ShowInter ();
	}
		

}
