using UnityEngine;
using System.Collections;

public class Koma : MonoBehaviour
{

	public int xNum;
	public int yNum;
	public int kNum;
	public bool Enemy;
	Controll con;
	// Use this for initialization
	void Start ()
	{
		if (Enemy) {
			renderer.material.color = Color.red;
		}
		con = GameObject.Find ("ControllPlayer").GetComponent<Controll> ();
	}
	
	// Update is called once per frame
	void Update ()
	{

		if (con.Turn == Enemy) {
			if (Input.GetMouseButtonDown (1)) {

				if (kNum == GameObject.Find ("SELECT").GetComponent<Select> ().SelectKomaNum && name != "SphinxPrefab(Clone)") {
					rigidbody.useGravity = !rigidbody.useGravity;
//								Debug.Log(name);
//								Debug.Log(kNum);
					//select
					if (!rigidbody.useGravity) {
						transform.Translate (0, 0.2f, 0);
//					if(name != "SphinxPrefab(Clone)")
						GameObject.Find ("GUI").GetComponent<MyGUI> ().turnFlag = true;

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
								if (k.kNum == kNum) {
									rigidbody.useGravity = true;
									GameObject.Find ("SELECT").GetComponent<Select> ().SelectKomaNum = 0;
									GameObject.Find ("GUI").GetComponent<MyGUI> ().turnFlag = false;
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

	void OnCollisionEnter (Collision collision)
	{
		GameObject obj = collision.gameObject;
		if (obj.name == "CubePrefab(Clone)") {
			Cube c = obj.GetComponent<Cube> ();
			xNum = c.xNum;
			yNum = c.yNum;

			GameObject[] cs = GameObject.FindObjectsOfType (typeof(GameObject)) as GameObject[];
			foreach (GameObject cc in cs) {
				if (cc.transform.parent == null && cc.name == "CubePrefab(Clone)") {
					Cube C = cc.GetComponent<Cube> ();
					
					if (C.xNum == xNum - 1 && C.yNum == yNum - 1) {
						C.renderer.material.color = Color.gray;
					}
					if (C.xNum == xNum && C.yNum == yNum - 1) {
						C.renderer.material.color = Color.gray;
					}
					if (C.xNum == xNum + 1 && C.yNum == yNum - 1) {
						C.renderer.material.color = Color.gray;
					}
					if (C.xNum == xNum - 1 && C.yNum == yNum) {
						C.renderer.material.color = Color.gray;
					}
					if (C.xNum == xNum + 1 && C.yNum == yNum) {
						C.renderer.material.color = Color.gray;
					}
					if (C.xNum == xNum - 1 && C.yNum == yNum + 1) {
						C.renderer.material.color = Color.gray;
					}
					if (C.xNum == xNum && C.yNum == yNum + 1) {
						C.renderer.material.color = Color.gray;
					}
					if (C.xNum == xNum + 1 && C.yNum == yNum + 1) {
						C.renderer.material.color = Color.gray;
					}
				}	
			}
			//Debug.Log(c.xNum);
			//Debug.Log(c.yNum);
			//Debug.Log("hit");
		}

	}
}
