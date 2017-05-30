using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour {

	public static Bomb Instance; 
	public int bomb_damage = 30;
	// Use this for initialization
	void Start () {
		Instance = this;
	}
	
	// Update is called once per frame
	void Update () {
		gameObject.transform.position += new Vector3(0,0.1f,0);		
	}
}
