using UnityEngine;
using System.Collections;

public class Laser : MonoBehaviour {

	public static Laser Instance; 
	public int Laser_damage = 10;

	// Use this for initialization
	void Start () {
		Instance = this; 
	}
	
	// Update is called once per frame
	void Update () {
		gameObject.transform.position += new Vector3(0,0.1f,0);
	}
}
