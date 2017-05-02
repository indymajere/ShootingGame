using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBomb : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		gameObject.transform.position -= new Vector3(0,0.1f,0);		
	}

	void OnTriggerEnter2D(Collider2D col) 
	{
		if (col.tag == "Fireball") {
			Destroy (gameObject); //destroy EnemyBomb
			Destroy(col.gameObject); 
		} else if (col.tag == "Ship") { 
			Destroy (gameObject); //destroy EnemyBomb
			if (GameFunction.Instance.BattleshipDamage (20) <= 0) {
				Destroy (col.gameObject); //destroy collided object
				GameFunction.Instance.GameOver (); 					
			}
		} else if (col.tag == "Bullet") {
			Destroy(col.gameObject); 
		}

	}
}
