using UnityEngine;
using System.Collections;

public class MyGUI : MonoBehaviour
{

		public GameObject cube;
		public GameObject wallX;
		public GameObject wallY;
		public GameObject Pyramid;
		public GameObject Sphinx;
		public GameObject Scarab;
		public GameObject Anubis;
		public GameObject Pharaoh;

//	GameObject mCube;
//	GameObject mKoma;
		public int flag = 0;
		public bool win;
		public bool turnFlag = false;

		//set board
		GameObject CubeClone;
		GameObject KomaClone;

//	bool select = false;
		//public GameObject cubes;

		// Use this for initialization

		void OnGUI ()
		{
				if (flag == 0) {
						if (GUI.Button (new Rect (185, 200, 100, 50), "VS")) {
								StartGame ();
						}
						if (GUI.Button (new Rect (285, 200, 100, 50), "CPU")) {
								GameObject.Find ("EnemySystem").GetComponent<EnemySystem> ().Enemy = true;
								StartGame ();
						}

				} else if (flag == 1) {
						//Shot Sphinx
						Controll con = GameObject.Find ("ControllPlayer").GetComponent<Controll> ();
						if (GUI.Button (new Rect (450, 30, 100, 30), "Shot!!") && GameObject.Find ("SELECT").GetComponent<Select> ().SelectKomaNum == 0) {
								if (!GameObject.Find ("Laser(Clone)")) {
										GameObject[] cs = GameObject.FindObjectsOfType (typeof(GameObject)) as GameObject[];
										foreach (GameObject cc in cs) {
												if (cc.name == "SphinxPrefab(Clone)") {
//						Debug.Log(cc.name);
														if (cc.GetComponent<Koma> ().Enemy == con.Turn) {
																cc.GetComponent<Sphinx> ().Shot = true;
																GameObject.Find ("EnemySystem").GetComponent<EnemySystem> ().x = 1;
														}
												}
										}
										GameObject.Find ("ControllPlayer").GetComponent<Controll> ().Move = false;
								}
						}
						if (!con.Turn) {
								GUI.Label (new Rect (480, 10, 100, 30), "Player");
						} else {
								GUI.Label (new Rect (480, 10, 100, 30), "Enemy");
						}
				} else if (flag == 2) {

						if (!win) {
								GUI.Label (new Rect (245, 100, 200, 100), "Player Win!!");
						} else {
								GUI.Label (new Rect (240, 100, 200, 100), "Computer Win!!");
						}

						if (GUI.Button (new Rect (235, 200, 100, 50), "Restart")) {
								flag = 0;
								turnFlag = false;
						}
				}

				if (turnFlag) {
//			Debug.Log ("GUI");


						GameObject[] ks = GameObject.FindObjectsOfType (typeof(GameObject)) as GameObject[];
						foreach (GameObject kc in ks) {
								if (kc.transform.parent == null && kc.tag == "Koma") {
										Koma k = kc.GetComponent<Koma> ();

//					Debug.Log(k.name);
//					if (k.name != "SphinxPrefab(Clone)") {
										if (k.kNum == GameObject.Find ("SELECT").GetComponent<Select> ().SelectKomaNum) {
//						Debug.Log ("hoge");
												if (GUI.Button (new Rect (10, 10, 100, 50), "Left")) {
														k.transform.Rotate (new Vector3 (0, -90f, 0));
														k.rigidbody.useGravity = ! k.rigidbody.useGravity;
														turnFlag = false;
														GameObject.Find ("ControllPlayer").GetComponent<Controll> ().Move = true;
														GameObject.Find ("SELECT").GetComponent<Select> ().SelectKomaNum = 0;
														//Debug.Log("left");
												}
												if (GUI.Button (new Rect (110, 10, 100, 50), "Right")) {
														k.transform.Rotate (new Vector3 (0, 90f, 0));
														k.rigidbody.useGravity = ! k.rigidbody.useGravity;
														turnFlag = false;
														GameObject.Find ("ControllPlayer").GetComponent<Controll> ().Move = true;
														GameObject.Find ("SELECT").GetComponent<Select> ().SelectKomaNum = 0;
												}
										}
//					}else{
//						k.rigidbody.useGravity = ! k.rigidbody.useGravity;
//						turnFlag = false;
//						transform.Translate (0, -0.2f, 0);
//						GameObject.Find ("SELECT").GetComponent<Select> ().SelectKomaNum = 0;
//					}
								}
						}
				}
		}

		void StartGame ()
		{

		
				for (float i = 0; i < 8; i = i + 1.1f) {
						for (float j = 0; j < 11; j = j + 1.1f) {
				
								CubeClone = Instantiate (this.cube, new Vector3 (j, 0, i), Quaternion.identity) as GameObject;
								//mas.transform.parent = cubes.transform;
								Cube c = CubeClone.GetComponent<Cube> ();
								c.xNum = (int)j;
								c.yNum = (int)i;
				
								if (c.xNum == 0) {
										c.tag = "Enemy";
								}
								if (c.xNum == 8) {
										if (c.yNum == 0) {
												c.tag = "Enemy";
										}
										if (c.yNum == 7) {
												c.tag = "Enemy";
										}
								}
				
								if (c.xNum == 9) {
										c.tag = "Ally";
								}
				
								if (c.xNum == 1) {
										if (c.yNum == 0) {
												c.tag = "Ally";
										}
										if (c.yNum == 7) {
												c.tag = "Ally";
										}
								}
				
								c.pos = c.transform.position;
				
								//cpu
								defGame (c.xNum, c.yNum,c.pos);
				
						}
				}
				//set wall
				for (float i = 0.55f; i < 8; i = i + 1.1f) {
						for (float j = 0.55f; j < 10; j = j + 1.1f) {
								Instantiate (this.wallY, new Vector3 (j, 0, 3.85f), Quaternion.Euler (0, 90, 0));
						}
						Instantiate (this.wallX, new Vector3 (4.95f, 0, i), Quaternion.Euler (0, 0, 0));
				}
		
				//set koma
				//Instantiate(this.koma, new Vector3(0, 0.55f, 0), Quaternion.identity);
				flag++;
	
		}

		void setKoma (bool enemy, Vector3 vector, int rotation, int number, GameObject obj)
		{
				KomaClone = Instantiate (obj, new Vector3 (vector.x, 0, vector.z), Quaternion.Euler (0, rotation, 0)) as GameObject;
				KomaClone.transform.Translate (0, KomaClone.transform.lossyScale.y, 0);
				KomaClone.GetComponent<Koma> ().kNum = number;
				KomaClone.GetComponent<Koma> ().Enemy = enemy;
		}

		void defGame (int x, int y, Vector3 vec)
		{
				//Pyramid
				if (x == 0 && y == 3) {
						setKoma (true, vec, 180, 1, this.Pyramid);
				}
		
				if (x == 0 && y == 4) {
			setKoma (true, vec, 90, 2, this.Pyramid);
				}
		
				if (x == 2 && y == 6) {
						setKoma (true, vec, -90, 3, this.Pyramid);
				}
		
				if (x == 6 && y == 2) {
						setKoma (true, vec, 180, 4, this.Pyramid); 
				}
		
				if (x == 7 && y == 3) {
						setKoma (true, vec, 90, 5, this.Pyramid);
			
				}
		
				if (x == 7 && y == 4) {
						setKoma (true, vec, 180, 6, this.Pyramid);
				}
		
				if (x == 7 && y == 7) {
						setKoma (true, vec, 180, 7, this.Pyramid);
				}
		
				//Sphinx
				if (x == 0 && y == 7) {
						setKoma (true, vec, 180, 8, this.Sphinx);
				}
		
				//Scarab
				if (x == 4 && y == 4) {
						setKoma (true, vec, 90, 9, this.Scarab);
				}
		
				if (x == 5 && y == 4) {
						setKoma (true, vec, 0, 10, this.Scarab);
				}
		
				//Anubis
				if (x == 4 && y == 7) {
						setKoma (true, vec, 0, 11, this.Anubis);
				}
		
				if (x == 6 && y == 7) {
						setKoma (true, vec, 0, 12, this.Anubis);
				}
		
				//Pharaoh
				if (x == 5 && y == 7) {
						setKoma (true, vec, 180, 13, this.Pharaoh);
				}
		
				//1p
				//Pyramid
				if (x == 2 && y == 0) {
						setKoma (false, vec, 0, 21, this.Pyramid);
				}
		
				if (x == 2 && y == 3) {
						setKoma (false, vec, 0, 22, this.Pyramid);
				}
		
				if (x == 2 && y == 4) {
						setKoma (false, vec, -90, 23, this.Pyramid);
				}
		
				if (x == 3 && y == 5) {
						setKoma (false, vec, 0, 24, this.Pyramid);
				}
		
				if (x == 7 && y == 1) {
						setKoma (false, vec, 90, 25, this.Pyramid);
				}
		
				if (x == 9 && y == 3) {
						setKoma (false, vec, -90, 26, this.Pyramid);
				}
		
				if (x == 9 && y == 4) {
						setKoma (false, vec, 0, 27, this.Pyramid);
				}
		
				//Sphinx
				if (x == 9 && y == 0) {
						setKoma (false, vec, 0, 28, this.Sphinx);
				}
		
				//Scarab
				if (x == 4 && y == 3) {
						setKoma (false, vec, 0, 29, this.Scarab);
				}
		
				if (x == 5 && y == 3) {
						setKoma (false, vec, 90, 30, this.Scarab);
				}
		
				//Anubis
				if (x == 3 && y == 0) {
						setKoma (false, vec, 180, 31, this.Anubis);
				}
		
				if (x == 5 && y == 0) {
						setKoma (false, vec, 180, 32, this.Anubis);
				}
		
				//Anubis
				if (x == 4 && y == 0) {
						setKoma (false, vec, 0, 33, this.Pharaoh);
				}
		}

}
