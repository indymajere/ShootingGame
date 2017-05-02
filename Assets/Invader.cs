using UnityEngine;
using System.Collections;

public class Invader : MonoBehaviour {
//	public static Invader Instance; 
	public GameObject explo; 
	public int shoot_random = 0; 
	public GameObject EnemyBullet;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		gameObject.transform.position += new Vector3(0,-0.01f,0);
		shoot_random = Random.Range (1, 999);
		if (shoot_random > 993) {
			Vector3 posb = gameObject.transform.position - new Vector3 (0, 0.6f, 0);
			Instantiate (EnemyBullet, posb, gameObject.transform.rotation);
		}
	}

	void OnTriggerEnter2D(Collider2D col) 
	{
		if (col.tag == "Fireball")
		{
			Destroy(gameObject); // destroy invader
			Instantiate(explo,transform.position,transform.rotation); // invader explosion
			GameFunction.Instance.AddScore(); // add score
		}
		if (col.tag == "Ship" || col.tag == "Bullet" ) // if collided with battleship or battleship laser
		{
			Destroy(col.gameObject); // destroy battleship laser
			Destroy(gameObject); //destroy invader
			Instantiate(explo,transform.position,transform.rotation); // invader explosion

			if (col.tag == "Ship") // collided with battleship
			{
				Instantiate(explo,col.gameObject.transform.position,col.gameObject.transform.rotation); // battleship explosion
				GameFunction.Instance.GameOver(); // game over

			}
			GameFunction.Instance.AddScore(); // add score
		}
	}

}
