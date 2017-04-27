using UnityEngine;
using System.Collections;

public class BottomSideFunction : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.tag == "Enemy" || col.tag == "EBullet") // if collided with invader or invader's laser
		{
			Destroy(col.gameObject); // destroy collided invader or invader's laser
		}
	}
}
