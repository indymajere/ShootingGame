using UnityEngine;
using System.Collections;

public class gDefine {

	public enum Direction{
		Up,
		Down,
		Left,
		Right
	}
}

public class ShipControl : MonoBehaviour {
	public GameObject Bullet;
	public bool IsPressing = false;
	public bool IsFire = false;
	public Vector2 pos;


	private Vector2 m_screenPos = new Vector2 ();

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

		#if UNITY_EDITOR || UNITY_STANDALONE
		MouseInput(); // 滑鼠偵測
		#elif UNITY_ANDROID
		MobileInput(); // 觸碰偵測
		#endif

		if (Input.GetKey (KeyCode.RightArrow)) {
			gameObject.transform.position += new Vector3(0.1f,0,0);
		}

		if (Input.GetKey (KeyCode.LeftArrow)) {
			gameObject.transform.position += new Vector3(-0.1f,0,0);
		}

		if (Input.GetKey (KeyCode.UpArrow)) {
			gameObject.transform.position += new Vector3(0,0.1f,0);
		}

		if (Input.GetKey (KeyCode.DownArrow)) {
			gameObject.transform.position += new Vector3(0,-0.1f,0);
		}

		if (Input.GetKeyDown(KeyCode.Space))
		{
			Vector3 pos = gameObject.transform.position + new Vector3(0,0.6f,0);

			Instantiate(Bullet,pos,gameObject.transform.rotation);

		}

		if (Input.acceleration.x > 0) {
			gameObject.transform.position += new Vector3(0.03f,0,0);
		}

		if (Input.acceleration.x < 0) {
			gameObject.transform.position += new Vector3(-0.03f,0,0);
		}


	}

	public void LeftShip()
	{
		gameObject.transform.position += new Vector3(-0.5f,0,0);
	}

	public void RightShip()
	{
		gameObject.transform.position += new Vector3(0.5f,0,0);
	}

	public void ShootBullet()
	{
		Vector3 posb = gameObject.transform.position + new Vector3 (0, 0.6f, 0);
		Instantiate (Bullet, posb, gameObject.transform.rotation);
		//gDefine.Direction mDirection = HandDirection(m_screenPos, pos);
		IsFire = true;
	}

	void MouseInput()
	{
		if (Input.GetMouseButtonDown(0))
		{
			m_screenPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
		}

		if(Input.GetMouseButtonUp(0))
		{
			pos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);

			gDefine.Direction mDirection = HandDirection(m_screenPos, pos);
			Debug.Log("mDirection: " + mDirection.ToString());
		}
	}


	void MobileInput ()
	{
		if (Input.touchCount <= 0)
			return;

		//1個手指觸碰螢幕
		if (Input.touchCount == 1) {

			//IsFire = false;
			if (IsFire == false) {
				ShootBullet ();
			}

			//開始觸碰
			if (Input.touches [0].phase == TouchPhase.Began) {
				Debug.Log("Began");
				//紀錄觸碰位置
				m_screenPos = Input.touches [0].position;

				IsPressing = true;
				//手指移動
			} else if (Input.touches [0].phase == TouchPhase.Moved) {
				Debug.Log("Moved");
				pos = Input.touches [0].position;

				gDefine.Direction mDirection = HandDirection(m_screenPos, pos);
				//移動攝影機
				//Camera.main.transform.Translate (new Vector3 (-Input.touches [0].deltaPosition.x * Time.deltaTime, -Input.touches [0].deltaPosition.y * Time.deltaTime, 0));
			} else if (IsPressing == true) {
					gDefine.Direction mDirection = HandDirection(m_screenPos, pos);
			}

			//手指離開螢幕
			if (Input.touches [0].phase == TouchPhase.Ended || Input.touches [0].phase == TouchPhase.Canceled) {
				Debug.Log("Ended");
				IsPressing = false;
				IsFire = false;
				//Vector2 pos = Input.touches [0].position;

				//gDefine.Direction mDirection = HandDirection(m_screenPos, pos);
				//Debug.Log("mDirection: " + mDirection.ToString());
			}
			//攝影機縮放，如果1個手指以上觸碰螢幕


		} else if (Input.touchCount > 1) {
			
			if (IsFire == false) 
			{
				Vector3 posb = gameObject.transform.position + new Vector3 (0, 0.6f, 0);
				//Instantiate (Bullet, posb, gameObject.transform.rotation);
				IsFire = true;
			}
			gDefine.Direction mDirection = HandDirection(m_screenPos, pos);
			/*
			//記錄兩個手指位置
			Vector2 finger1 = new Vector2 ();
			Vector2 finger2 = new Vector2 ();

			//記錄兩個手指移動距離
			Vector2 move1 = new Vector2 ();
			Vector2 move2 = new Vector2 ();

			//是否是小於2點觸碰
			for (int i=0; i<2; i++) {
				UnityEngine.Touch touch = UnityEngine.Input.touches [i];

				if (touch.phase == TouchPhase.Ended)
					break;

				if (touch.phase == TouchPhase.Moved) {
					//每次都重置
					float move = 0;

					//觸碰一點
					if (i == 0) {
						finger1 = touch.position;
						move1 = touch.deltaPosition;
						//另一點
					} else {
						finger2 = touch.position;
						move2 = touch.deltaPosition;

						//取最大X
						if (finger1.x > finger2.x) {
							move = move1.x;
						} else {
							move = move2.x;
						}

						//取最大Y，並與取出的X累加
						if (finger1.y > finger2.y) {
							move += move1.y;
						} else {
							move += move2.y;
						}

						//當兩指距離越遠，Z位置加的越多，相反之
						Camera.main.transform.Translate (0, 0, move * Time.deltaTime);
					}
				}
			}//end for   */
		}//end else if   
	}//end void




	gDefine.Direction HandDirection(Vector2 StartPos, Vector2 EndPos)
	{
		
		gDefine.Direction mDirection;

		//手指水平移動
		if (Mathf.Abs (StartPos.x - EndPos.x) > Mathf.Abs (StartPos.y - EndPos.y)) {
			if (StartPos.x > EndPos.x) {
				//手指向左滑動
				mDirection = gDefine.Direction.Left;
				//gameObject.transform.position += new Vector3(-0.05f,0,0);
			} else {
				//手指向右滑動
				mDirection = gDefine.Direction.Right;
				//gameObject.transform.position += new Vector3(0.05f,0,0);

			}
		} else {
		if (m_screenPos.y > EndPos.y) {
				//手指向下滑動
				mDirection = gDefine.Direction.Down;
				//gameObject.transform.position += new Vector3(0,-0.05f,0);
			} else {
				//手指向上滑動
				mDirection = gDefine.Direction.Up;
				//gameObject.transform.position += new Vector3(0,0.05f,0);
			}
		}
		return mDirection; 
	} 
		
}