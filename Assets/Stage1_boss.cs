using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage1_boss : MonoBehaviour {
	//	public static Invader Instance; 
	public GameObject explo; 
	private int shoot_random = 0; 
	public GameObject EnemyBullet;
	public GameObject Fireball;
	private int boss1_life = 100;
	private int i = 0;
	private int boss_move_time = 50;
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {


		shoot_random = Random.Range (1, 999);
		if (shoot_random > 995) {
			Vector3 posb = gameObject.transform.position - new Vector3 (0, 1.0f, 0);
			Instantiate (Fireball, posb, gameObject.transform.rotation);
		} else if (shoot_random > 950) {
			Vector3 posb = gameObject.transform.position - new Vector3 (Random.Range (-0.5f, 0.5f), 0.8f, 0);
			Instantiate (EnemyBullet, posb , gameObject.transform.rotation);
		}
		i += 1;
		if (i >= boss_move_time) {
			gameObject.transform.position = new Vector3(Random.Range (-1.1f, 1.1f),3.3f,0);
			boss_move_time = Random.Range (25, 150);
			i = 0;
		}

	}

	void OnTriggerEnter2D(Collider2D col) 
	{
		GameFunction.Instance.AddScore(); // add score
		Destroy(col.gameObject); 
		if (col.tag == "Fireball")
		{
			Boss1_Life_Count (Bomb.Instance.bomb_damage);
		}
		if (col.tag == "Ship" || col.tag == "Bullet" ) // if collided with battleship or battleship laser
		{
			Boss1_Life_Count (10);
			if (col.tag == "Ship") // collided with battleship
			{
				Instantiate(explo,col.gameObject.transform.position,col.gameObject.transform.rotation); // battleship explosion
				GameFunction.Instance.GameOver(); // game over
			}
		}
	}

	void Boss1_Life_Count(int damage)
	{
		boss1_life -= damage;
		if (boss1_life <= 0) 
		{
			Destroy(gameObject); // destroy boss
			Instantiate(explo,transform.position,transform.rotation); // boss explosion
//			GameFunction.Instance.enemyship_number = 0;

		}
	}

}
