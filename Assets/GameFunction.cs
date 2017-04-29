using UnityEngine;
using System.Collections;
using UnityEngine.UI; 

public class GameFunction : MonoBehaviour {
	public GameObject Enemy; // invader
	public float time; 

	public Text ScoreText; // Score board

	public int Score = 0; 
	public int BattleshipLife = 30;

	public static GameFunction Instance; 

	public GameObject GameTitle; // Game Title

	public GameObject GameOverTitle; // GameOver Title

	public GameObject PlayButton; // Play Button

	public bool IsPlaying = false; 

	public GameObject RestartButton; // Restart Button

	public GameObject QuitButton; // Quit Button

	public GameObject ShootButton; 
	public GameObject LeftButton; 
	public GameObject RightButton; 
	//public GameObject Bullet;

	// Use this for initialization
	void Start () {
		Instance = this; 
		GameOverTitle.SetActive(false); 
		RestartButton.SetActive(false); 
		ShootButton.SetActive(false);
		LeftButton.SetActive(false);
		RightButton.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		time += Time.deltaTime; // time increaing
		if(time>0.5f && IsPlaying == true)
		{
			Vector3 pos = new Vector3(Random.Range(-2f,2f),4.5f,0); // random X pos from -2 to 2 
			Instantiate(Enemy,pos,transform.rotation); // create invader
			time = 0f; // time reset to 0
		}
	}

	public void AddScore()
	{

		Score += 10; // score increases 10 points

		ScoreText.text = "Score: " + Score; // modify the score board

	}

	// Battleship be hit
	public int BattleshipDamage(int damage)
	{
		
		BattleshipLife -= damage;
		return BattleshipLife;
//		if (BattleshipLife <= 0) // Battleship be destoyed
//		{
//			GameFunction.Instance.GameOver();
//		}
	}	


	public int ShootBomb()
	{
		if (Score >= 100) {
			Score -= 100; // socre minus 100 points
			ScoreText.text = "Score: " + Score; // modify the score board
			return 1;
		} else {
			return 0;
		}
	}



	public void GameStart() 

	{

		IsPlaying = true; 

		GameTitle.SetActive (false); 

		PlayButton.SetActive (false); 

		QuitButton.SetActive (false); 

		//ShootButton.SetActive(true);
		//LeftButton.SetActive(true);
		//RightButton.SetActive(true);
	}

	public void GameOver() //GameOver的Function

	{

		IsPlaying = false; // not playing, stop create invader

		GameOverTitle.SetActive(true); // show GameOverTitle

		RestartButton.SetActive(true); // show Restart Button

		QuitButton.SetActive(true); // show Quit Button

		ShootButton.SetActive(false);
		LeftButton.SetActive(false);
		RightButton.SetActive(false);
	}

	public void ResetGame() // Function of Restart Button

	{

		Application.LoadLevel (Application.loadedLevel); 

	}

	public void QuitGame() // Function of Quit Button

	{

		Application.Quit(); // Quit the game

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
