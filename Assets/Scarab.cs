using UnityEngine;
using System.Collections;

public class Scarab : MonoBehaviour
{
	
	// Use this for initialization
	Koma koma;
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

				if (koma.kNum == GameObject.Find ("SELECT").GetComponent<Select> ().SelectKomaNum) {
					rigidbody.useGravity = !rigidbody.useGravity;

					//select
					if (!rigidbody.useGravity) {
						transform.Translate (0, 0.2f, 0);
					
						//change cube color yellow
						GameObject[] cs = GameObject.FindObjectsOfType (typeof(GameObject)) as GameObject[];
						foreach (GameObject c in cs) {
							if (c.transform.parent == null && c.name == "CubePrefab(Clone)") {
								Cube C = c.GetComponent<Cube> ();
							
								if (C.xNum == koma.xNum - 1 && C.yNum == koma.yNum - 1 && !C.ScarabFlag) {
									C.renderer.material.color = Color.yellow;
								}
								if (C.xNum == koma.xNum && C.yNum == koma.yNum - 1 && !C.ScarabFlag) {
									C.renderer.material.color = Color.yellow;
								}
								if (C.xNum == koma.xNum + 1 && C.yNum == koma.yNum - 1 && !C.ScarabFlag) {
									C.renderer.material.color = Color.yellow;
								}
								if (C.xNum == koma.xNum - 1 && C.yNum == koma.yNum && !C.ScarabFlag) {
									C.renderer.material.color = Color.yellow;
								}
								if (C.xNum == koma.xNum + 1 && C.yNum == koma.yNum && !C.ScarabFlag) {
									C.renderer.material.color = Color.yellow;
								}
								if (C.xNum == koma.xNum - 1 && C.yNum == koma.yNum + 1 && !C.ScarabFlag) {
									C.renderer.material.color = Color.yellow;
								}
								if (C.xNum == koma.xNum && C.yNum == koma.yNum + 1 && !C.ScarabFlag) {
									C.renderer.material.color = Color.yellow;
								}
								if (C.xNum == koma.xNum + 1 && C.yNum == koma.yNum + 1 && !C.ScarabFlag) {
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
//								Debug.Log ("White cube");
									rigidbody.useGravity = false;
								}
//						} else if (obj.name == "ScarabPrefab(Clone)") {
//							rigidbody.useGravity = false;
//							Debug.Log ("OK");
							} else {
								//ray not tauch cube
//							Debug.Log (obj.name);
								Koma k = obj.GetComponent<Koma> ();
								rigidbody.useGravity = false;
								//Koma Cancel Select
								if (k.kNum == koma.kNum) {
//								Debug.Log ("Cancel");
									rigidbody.useGravity = true;
									GameObject.Find ("SELECT").GetComponent<Select> ().SelectKomaNum = 0;
									GameObject.Find ("GUI").GetComponent<MyGUI> ().turnFlag = false;
								} else if (obj.name == "MirrorPrefab(Clone)") {
									if ((k.xNum == koma.xNum - 1 && k.yNum == koma.yNum - 1) ||
										(k.xNum == koma.xNum && k.yNum == koma.yNum - 1) ||
										(k.xNum == koma.xNum + 1 && k.yNum == koma.yNum - 1) ||

										(k.xNum == koma.xNum - 1 && k.yNum == koma.yNum) ||

										(k.xNum == koma.xNum + 1 && k.yNum == koma.yNum) ||

										(k.xNum == koma.xNum - 1 && k.yNum == koma.yNum + 1) ||
										(k.xNum == koma.xNum && k.yNum == koma.yNum + 1) ||
										(k.xNum == koma.xNum + 1 && k.yNum == koma.yNum + 1)
								   ) {
										rigidbody.useGravity = true;
										Vector3 tmp;
										tmp = koma.transform.position;
										koma.transform.position = k.transform.position;
										k.transform.position = tmp;
//								k.transform.Translate (0, k.transform.lossyScale.y, 0);
//								koma.transform.Translate (0, koma.transform.lossyScale.y, 0);
										GameObject.Find ("SELECT").GetComponent<Select> ().SelectKomaNum = 0;
									}
								}
							}
						} else {
							//ray not hit anyone
							rigidbody.useGravity = false;
						}
					}
				} else {
//				Debug.Log ("NO");
//				Debug.Log (koma.kNum);
//				rigidbody.useGravity = false;
				}
			}



		}
	}


}
