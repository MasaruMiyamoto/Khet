using UnityEngine;
using System.Collections;

public class Sphinx : MonoBehaviour
{

	// Use this for initialization

	public bool Gui;
	public bool Shot;
	public GameObject Laser;
	Koma koma;
	float muki;
	Controll con;

	void Start ()
	{
		koma = GetComponent<Koma> ();
		muki = transform.forward.z;
		con = GameObject.Find ("ControllPlayer").GetComponent<Controll> ();
		Shot = false;
	}
	
	// Update is called once per frame
	void Update ()
	{

		if (con.Turn == koma.Enemy) {
			if (Input.GetMouseButtonDown (0)) {

				if (koma.kNum == GameObject.Find ("SELECT").GetComponent<Select> ().SelectKomaNum) {
					rigidbody.useGravity = !rigidbody.useGravity;
					//								Debug.Log("OK");
					//								Debug.Log(kNum);
					//select
					if (!rigidbody.useGravity) {
						transform.Translate (0, 0.2f, 0);
//					GameObject.Find ("GUI").GetComponent<MyGUI> ().turnFlag = true;
						Gui = true;
					
					} else {
						//					Debug.Log (rigidbody.useGravity);
						//					Debug.Log (kNum);
						Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
						RaycastHit hit = new RaycastHit ();
					
						if (Physics.Raycast (ray, out hit)) {
							GameObject obj = hit.collider.gameObject;
							//Debug.Log(obj.name);
						
							if (obj.tag == "Koma") {
								//ray not tauch cube
								//							Debug.Log (obj.name);
								Koma k = obj.GetComponent<Koma> ();
							
								//Koma Cancel Select
								if (k.kNum == koma.kNum) {
									rigidbody.useGravity = true;
									GameObject.Find ("SELECT").GetComponent<Select> ().SelectKomaNum = 0;
//								GameObject.Find ("GUI").GetComponent<MyGUI> ().turnFlag = false;
									Gui = false;

								} else {
									rigidbody.useGravity = false;
								}
							} else {
								rigidbody.useGravity = false;
							}
						} else {
							rigidbody.useGravity = false;
						}
					}
				} else {
					//				Debug.Log("NO");
					//				Debug.Log(kNum);
				}
			}

		}
	}

	void OnGUI ()
	{
		if (Gui) {

			if (muki == transform.forward.z) {
				if (GUI.Button (new Rect (10, 10, 100, 50), "Left")) {
					transform.Rotate (new Vector3 (0, -90f, 0));
					rigidbody.useGravity = ! rigidbody.useGravity;
					Gui = false;
					GameObject.Find ("SELECT").GetComponent<Select> ().SelectKomaNum = 0;
					//Debug.Log("left");
				}
			} else {
				if (GUI.Button (new Rect (110, 10, 100, 50), "Right")) {
					transform.Rotate (new Vector3 (0, 90f, 0));
					rigidbody.useGravity = ! rigidbody.useGravity;
					Gui = false;
					GameObject.Find ("SELECT").GetComponent<Select> ().SelectKomaNum = 0;
				}
			}
		}

		if (Shot) {
			if (con.Turn == koma.Enemy) {
				Instantiate (Laser, transform.position, transform.rotation);
				Shot = false;
//				Debug.Log(koma.Enemy);
				con.Turn = !con.Turn;
//				Debug.Log(con.Turn);
			}
		}

	}

}
