using UnityEngine;
using System.Collections;

public class Invader : MonoBehaviour {
	public GameObject explo; //宣告一個名為explo的物件
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

	void OnTriggerEnter2D(Collider2D col) //名為col的觸發事件
	{
		if (col.tag == "Fireball")
		{
			Destroy(gameObject); //消滅物件本身
		}
		if (col.tag == "Ship" || col.tag == "Bullet" ) //如果碰撞的標籤是Ship或Bullet
		{
			Destroy(col.gameObject); //消滅碰撞的物件
			Destroy(gameObject); //消滅物件本身
			Instantiate(explo,transform.position,transform.rotation); //在外星人的位置產生爆炸

			if (col.tag == "Ship") //如果碰撞的標籤是Ship
			{
				Instantiate(explo,col.gameObject.transform.position,col.gameObject.transform.rotation);
				GameFunction.Instance.GameOver(); 
				//在碰撞物件的位置產生爆炸，也就是在太空船的位置產生爆炸
			}
			GameFunction.Instance.AddScore(); //呼叫GameFunction底下的AddScore()
		}
	}

}
