using UnityEngine;
using System.Collections;

public class BottomSideFunction : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D col) //碰撞事件
	{
		if (col.tag == "Enemy" || col.tag == "EBullet") //如果標籤是Emeny
		{
			Destroy(col.gameObject); //消滅碰撞的物件
		}
	}
}
