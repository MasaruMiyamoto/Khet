using UnityEngine;
using System.Collections;

public class Pyramid : MonoBehaviour
{

	// Use this for initialization
	Koma koma;
	public bool State;
	Controll con;

	void Start ()
	{
		koma = GetComponent<Koma> ();
		con = GameObject.Find ("ControllPlayer").GetComponent<Controll> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (con.Turn == koma.Enemy) {
			if (Input.GetMouseButtonDown (0)) {
			
				if (koma.kNum == GameObject.Find ("SELECT").GetComponent<Select> ().SelectKomaNum && !GameObject.Find ("ControllPlayer").GetComponent<Controll> ().Move) {
					rigidbody.useGravity = !rigidbody.useGravity;
					//				Debug.Log("OK");
					//				Debug.Log(kNum);
					//select
					if (!rigidbody.useGravity) {
						transform.Translate (0, 0.2f, 0);
					
						//change cube color yellow
						GameObject[] cs = GameObject.FindObjectsOfType (typeof(GameObject)) as GameObject[];
						foreach (GameObject c in cs) {
							if (c.transform.parent == null && c.name == "CubePrefab(Clone)") {
								Cube C = c.GetComponent<Cube> ();
							
								if (C.xNum == koma.xNum - 1 && C.yNum == koma.yNum - 1 && !C.CollisionStay) {
									C.renderer.material.color = Color.yellow;
								}
								if (C.xNum == koma.xNum && C.yNum == koma.yNum - 1 && !C.CollisionStay) {
									C.renderer.material.color = Color.yellow;
								}
								if (C.xNum == koma.xNum + 1 && C.yNum == koma.yNum - 1 && !C.CollisionStay) {
									C.renderer.material.color = Color.yellow;
								}
								if (C.xNum == koma.xNum - 1 && C.yNum == koma.yNum && !C.CollisionStay) {
									C.renderer.material.color = Color.yellow;
								}
								if (C.xNum == koma.xNum + 1 && C.yNum == koma.yNum && !C.CollisionStay) {
									C.renderer.material.color = Color.yellow;
								}
								if (C.xNum == koma.xNum - 1 && C.yNum == koma.yNum + 1 && !C.CollisionStay) {
									C.renderer.material.color = Color.yellow;
								}
								if (C.xNum == koma.xNum && C.yNum == koma.yNum + 1 && !C.CollisionStay) {
									C.renderer.material.color = Color.yellow;
								}
								if (C.xNum == koma.xNum + 1 && C.yNum == koma.yNum + 1 && !C.CollisionStay) {
									C.renderer.material.color = Color.yellow;
								}
							
							}
						}
					} else {
						//					Debug.Log (rigidbody.useGravity);
						//					Debug.Log (kNum);
						Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
						RaycastHit hit = new RaycastHit ();
					
						if (Physics.Raycast (ray, out hit)) {
							GameObject obj = hit.collider.gameObject;
							//Debug.Log(obj.name);
						
							if (obj.name == "CubePrefab(Clone)") {
								Cube c = obj.GetComponent<Cube> ();
							
								if (c.renderer.material.color == Color.yellow) {
								
									transform.position = c.pos;
									GameObject.Find ("ControllPlayer").GetComponent<Controll> ().Move = true;
//								transform.Translate (0, transform.lossyScale.y, 0);
									//color chenge
									GameObject[] cs = GameObject.FindObjectsOfType (typeof(GameObject)) as GameObject[];
									foreach (GameObject cc in cs) {
										if (cc.transform.parent == null && cc.name == "CubePrefab(Clone)") {
											Cube C = cc.GetComponent<Cube> ();
										
											if (C.xNum == koma.xNum - 1 && C.yNum == koma.yNum - 1) {
												C.renderer.material.color = Color.gray;
											}
											if (C.xNum == koma.xNum && C.yNum == koma.yNum - 1) {
												C.renderer.material.color = Color.gray;
											}
											if (C.xNum == koma.xNum + 1 && C.yNum == koma.yNum - 1) {
												C.renderer.material.color = Color.gray;
											}
											if (C.xNum == koma.xNum - 1 && C.yNum == koma.yNum) {
												C.renderer.material.color = Color.gray;
											}
											if (C.xNum == koma.xNum + 1 && C.yNum == koma.yNum) {
												C.renderer.material.color = Color.gray;
											}
											if (C.xNum == koma.xNum - 1 && C.yNum == koma.yNum + 1) {
												C.renderer.material.color = Color.gray;
											}
											if (C.xNum == koma.xNum && C.yNum == koma.yNum + 1) {
												C.renderer.material.color = Color.gray;
											}
											if (C.xNum == koma.xNum + 1 && C.yNum == koma.yNum + 1) {
												C.renderer.material.color = Color.gray;
											}
											GameObject.Find ("SELECT").GetComponent<Select> ().SelectKomaNum = 0;
										}	
									}
									//end color chenge
								
								} else {
									//								Debug.Log("White cube");
									rigidbody.useGravity = false;
								}
							} else {
								//ray not tauch cube
								//							Debug.Log (obj.name);
								Koma k = obj.GetComponent<Koma> ();
							
								//Koma Cancel Select
								if (k.kNum == koma.kNum) {
									rigidbody.useGravity = true;
									GameObject.Find ("SELECT").GetComponent<Select> ().SelectKomaNum = 0;
									GameObject.Find ("GUI").GetComponent<MyGUI> ().turnFlag = false;
								} else {
									rigidbody.useGravity = false;
								}
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
}
