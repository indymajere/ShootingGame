using UnityEngine;
using System.Collections;

public class EnemyLaser : MonoBehaviour {
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		gameObject.transform.position -= new Vector3(0,0.1f,0);
	}

	void OnTriggerEnter2D(Collider2D col) 
	{
		if (col.tag == "Fireball")
		{
			Destroy(gameObject); //destroy EnemyLaser
		}
		if (col.tag == "Ship" || col.tag == "Bullet" ) // if invader's laser collided with battleship or battleship's laser
		{
			
			Destroy(gameObject); //destroy invader's laser

			if (col.tag == "Ship") { //if collided with battleship
				
//				Instantiate(Invader.Instance.explo,col.gameObject.transform.position,col.gameObject.transform.rotation);   //battleship explosion				

				if (GameFunction.Instance.BattleshipDamage(10)  <= 0) {
					Destroy (col.gameObject); //destroy collided object
					GameFunction.Instance.GameOver (); 					
				}

			} else {
				Destroy(col.gameObject); //destroy collided object
			}

		}
	}

}
