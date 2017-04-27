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
	public GameObject Fireball;
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
		MouseInput (); // Detect mouse
		#elif UNITY_ANDROID
		MobileInput(); // Detect touch
		#endif

		if (Input.GetKey (KeyCode.RightArrow)) {
			gameObject.transform.position += new Vector3 (0.1f, 0, 0);
		}

		if (Input.GetKey (KeyCode.LeftArrow)) {
			gameObject.transform.position += new Vector3 (-0.1f, 0, 0);
		}

		if (Input.GetKey (KeyCode.UpArrow)) {
			gameObject.transform.position += new Vector3 (0, 0.1f, 0);
		}

		if (Input.GetKey (KeyCode.DownArrow)) {
			gameObject.transform.position += new Vector3 (0, -0.1f, 0);
		}

		if (Input.GetKeyDown (KeyCode.Space)) {
			Vector3 pos = gameObject.transform.position + new Vector3 (0, 0.6f, 0);

			Instantiate (Bullet, pos, gameObject.transform.rotation);

		}

		// if score is above 100, you can press 'x' to fire bomb 
		if (Input.GetKeyDown(KeyCode.X))
		{
			if (GameFunction.Instance.ShootBomb() == 1)
			{
				Vector3 pos = gameObject.transform.position + new Vector3(0,0.6f,0);
				Instantiate(Fireball,pos,gameObject.transform.rotation);
			}
		}


		if (Input.acceleration.x > 0) {
			gameObject.transform.position += new Vector3(0.03f,0,0);
		}

		if (Input.acceleration.x < 0) {
			gameObject.transform.position += new Vector3(-0.03f,0,0);
		}

		if (Input.acceleration.y > 0) {
			gameObject.transform.position += new Vector3(0,0.03f,0);
		}

		if (Input.acceleration.y < 0) {
			gameObject.transform.position += new Vector3(0,-0.03f,0);
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

		//1 finger touch screen
		if (Input.touchCount == 1) {

			//IsFire = false;
			if (IsFire == false) {
				ShootBullet ();
			}

			// touch start
			if (Input.touches [0].phase == TouchPhase.Began) {
				Debug.Log("Began");
				// record touch position
				m_screenPos = Input.touches [0].position;

				IsPressing = true;
				// finger movement
			} else if (Input.touches [0].phase == TouchPhase.Moved) {
				Debug.Log("Moved");
				pos = Input.touches [0].position;

				gDefine.Direction mDirection = HandDirection(m_screenPos, pos);
				// Camera movement
				//Camera.main.transform.Translate (new Vector3 (-Input.touches [0].deltaPosition.x * Time.deltaTime, -Input.touches [0].deltaPosition.y * Time.deltaTime, 0));
			} else if (IsPressing == true) {
					gDefine.Direction mDirection = HandDirection(m_screenPos, pos);
			}

			// touch end
			if (Input.touches [0].phase == TouchPhase.Ended || Input.touches [0].phase == TouchPhase.Canceled) {
				Debug.Log("Ended");
				IsPressing = false;
				IsFire = false;
				//Vector2 pos = Input.touches [0].position;

				//gDefine.Direction mDirection = HandDirection(m_screenPos, pos);
				//Debug.Log("mDirection: " + mDirection.ToString());
			}


		} else if (Input.touchCount > 1) {
			
			if (IsFire == false) 
			{
				Vector3 pos = gameObject.transform.position + new Vector3(0,0.6f,0);
				Instantiate(Fireball,pos,gameObject.transform.rotation);
				IsFire = true;
			}
			gDefine.Direction mDirection = HandDirection(m_screenPos, pos);

		}
	}




	gDefine.Direction HandDirection(Vector2 StartPos, Vector2 EndPos)
	{
		
		gDefine.Direction mDirection;

		// horizontal movement
		if (Mathf.Abs (StartPos.x - EndPos.x) > Mathf.Abs (StartPos.y - EndPos.y)) {
			if (StartPos.x > EndPos.x) {
				// move left
				mDirection = gDefine.Direction.Left;
				//gameObject.transform.position += new Vector3(-0.05f,0,0);
			} else {
				//  move right
				mDirection = gDefine.Direction.Right;
				//gameObject.transform.position += new Vector3(0.05f,0,0);

			}
		} else {
		if (m_screenPos.y > EndPos.y) {
				// move down
				mDirection = gDefine.Direction.Down;
				//gameObject.transform.position += new Vector3(0,-0.05f,0);
			} else {
				// move up
				mDirection = gDefine.Direction.Up;
				//gameObject.transform.position += new Vector3(0,0.05f,0);
			}
		}
		return mDirection; 
	} 
		
}