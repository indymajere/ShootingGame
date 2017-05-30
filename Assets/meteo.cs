using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meteo : MonoBehaviour {

	private int meteo_life;
	public GameObject explo; 

	// Use this for initialization
	void Start () {
		meteo_life = 15;
	}
	
	// Update is called once per frame
	void Update () {
		gameObject.transform.position += new Vector3(0,-0.01f,0);
	}

	void OnTriggerEnter2D(Collider2D col) 
	{

		if (col.tag == "Fireball") {
			meteo_life -= Bomb.Instance.bomb_damage;
//			meteo_life -= 30;
			Destroy (col.gameObject); //destroy collided object
		} else if (col.tag == "Ship") {
			if (GameFunction.Instance.BattleshipDamage(meteo_life)  <= 0) {
				Destroy (col.gameObject); //destroy collided object
				GameFunction.Instance.GameOver (); 					
			}
		} else if (col.tag == "Bullet") {
			meteo_life -= Laser.Instance.Laser_damage; 
//			meteo_life -= 10;
			Destroy(col.gameObject); //destroy collided object
		}


		if (meteo_life <= 0) 
		{
			Destroy(gameObject); // destroy self
			Instantiate(explo,transform.position,transform.rotation); // show explosion
			GameFunction.Instance.AddScore(); // add score
		}
	}

}


