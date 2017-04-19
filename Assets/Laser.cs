using UnityEngine;
using System.Collections;

public class Laser : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		gameObject.transform.position += new Vector3(0,0.1f,0);
	}
}
