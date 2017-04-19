﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI; //使用UI

public class GameFunction : MonoBehaviour {
	public GameObject Enemy; //宣告物件，名稱Enemy
	public float time; //宣告浮點數，名稱time

	public Text ScoreText; //宣告一個ScoreText的text

	public int Score = 0; // 宣告一整數 Score

	public static GameFunction Instance; // 設定Instance，讓其他程式能讀取GameFunction裡的東西

	public GameObject GameTitle; //宣告GameTitle物件

	public GameObject GameOverTitle; //宣告GameOverTitle物件

	public GameObject PlayButton; //宣告PlayButton物件

	public bool IsPlaying = false; // 宣告IsPlaying 的布林資料，並設定初始值false

	public GameObject RestartButton; //宣告RestartButto的物件

	public GameObject QuitButton; //宣告QuitButton的物件

	public GameObject ShootButton; //20160204
	public GameObject LeftButton; //20160204
	public GameObject RightButton; //20160204
	//public GameObject Bullet;

	// Use this for initialization
	void Start () {
		Instance = this; //指定Instance這個程式
		GameOverTitle.SetActive(false); //設定GameOverTitle不顯示(打勾取消)
		RestartButton.SetActive(false); //RestartButton設定成不顯示
		ShootButton.SetActive(false);
		LeftButton.SetActive(false);
		RightButton.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		time += Time.deltaTime; //時間增加
		if(time>0.5f && IsPlaying == true)
		{
			Vector3 pos = new Vector3(Random.Range(-2f,2f),4.5f,0); //宣告位置pos，Random.Range(-2.5f,2.5f)代表X是2.5到-2.5之間隨機
			Instantiate(Enemy,pos,transform.rotation); //產生敵人
			time = 0f; //時間歸零
		}
	}

	public void AddScore()

	{

		Score += 10; //分數+10

		ScoreText.text = "Score: " + Score; // 更改ScoreText的內容

	}

	public void GameStart() 

	{

		IsPlaying = true; //設定IsPlaying為true，代表遊戲正在進行中

		GameTitle.SetActive (false); //不顯示GameTitle

		PlayButton.SetActive (false); //不顯示PlayButton

		QuitButton.SetActive (false); //QuitButton設定成不顯示

		//ShootButton.SetActive(true);
		//LeftButton.SetActive(true);
		//RightButton.SetActive(true);
	}

	public void GameOver() //GameOver的Function

	{

		IsPlaying = false; //IsPlaying設定成false，停止產生外星人

		GameOverTitle.SetActive(true); //GameOverTitle設定為ture

		RestartButton.SetActive(true); //RestartButton設定成不顯示

		QuitButton.SetActive(true); //QuitButton設定成不顯示

		ShootButton.SetActive(false);
		LeftButton.SetActive(false);
		RightButton.SetActive(false);
	}

	public void ResetGame() //RestartButton的功能

	{

		Application.LoadLevel (Application.loadedLevel); //讀取關卡(已讀取的關卡)

	}

	public void QuitGame() //QuitButton的功能

	{

		Application.Quit(); //離開應用程式

	}

	//public void ShootBullet() 
	//{
	//	Vector3 pos = gameObject.transform.position + new Vector3 (0, 0.6f, 0);
	//	Instantiate (Bullet, pos, gameObject.transform.rotation);
	//}

	//public void LeftShip()
	//{
	//	gameObject.transform.position += new Vector3(-0.1f,0,0);
	//}

	//public void RightShip()
	//{
	//	gameObject.transform.position += new Vector3(0.1f,0,0);
	//}

}
