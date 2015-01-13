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
		bool flag = true;
		public bool turnFlag = false;
//	bool select = false;
<<<<<<< HEAD
	//public GameObject cubes;

	// Use this for initialization

	void OnGUI ()
	{
		if (flag) {
			if (GUI.Button (new Rect (185, 200, 100, 50), "VS")) {
				StartGame();
			}
			if (GUI.Button (new Rect (285, 200, 100, 50), "CPU")) {
				GameObject.Find ("EnemySystem").GetComponent<EnemySystem> ().Enemy = true;
				StartGame();
			}

		} else {
			//Shot Sphinx
			Controll con = GameObject.Find ("ControllPlayer").GetComponent<Controll> ();
			if (GUI.Button (new Rect (450, 30, 100, 30), "Shot!!") && GameObject.Find ("SELECT").GetComponent<Select> ().SelectKomaNum == 0) {
				if(!GameObject.Find ("Laser(Clone)")){
				GameObject[] cs = GameObject.FindObjectsOfType (typeof(GameObject)) as GameObject[];
				foreach (GameObject cc in cs) {
					if (cc.name == "SphinxPrefab(Clone)") {
=======
		//public GameObject cubes;

		// Use this for initialization

		void OnGUI ()
		{
				if (flag) {
						if (GUI.Button (new Rect (10, 10, 100, 50), "GameStart")) {
								//set board
								GameObject CubeClone;
								GameObject KomaClone;
								GameObject.Find ("EnemySystem").GetComponent<EnemySystem> ().onCPU = true;
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
												//Pyramid
												if (c.xNum == 0 && c.yNum == 3) {
														KomaClone = Instantiate (this.Pyramid, new Vector3 (c.pos.x, 0, c.pos.z), Quaternion.Euler (0, 180, 0)) as GameObject;
														KomaClone.transform.Translate (0, KomaClone.transform.lossyScale.y, 0);
														KomaClone.GetComponent<Koma> ().kNum = 1;
														KomaClone.GetComponent<Koma> ().Enemy = true;
												}

												if (c.xNum == 0 && c.yNum == 4) {
														KomaClone = Instantiate (this.Pyramid, new Vector3 (c.pos.x, 0, c.pos.z), Quaternion.Euler (0, 90, 0)) as GameObject;
														KomaClone.transform.Translate (0, KomaClone.transform.lossyScale.y, 0);
														KomaClone.GetComponent<Koma> ().kNum = 2;
														KomaClone.GetComponent<Koma> ().Enemy = true;
												}

												if (c.xNum == 2 && c.yNum == 6) {
														KomaClone = Instantiate (this.Pyramid, new Vector3 (c.pos.x, 0, c.pos.z), Quaternion.Euler (0, -90, 0)) as GameObject;
														KomaClone.transform.Translate (0, KomaClone.transform.lossyScale.y, 0);
														KomaClone.GetComponent<Koma> ().kNum = 3;
														KomaClone.GetComponent<Koma> ().Enemy = true;
												}

												if (c.xNum == 6 && c.yNum == 2) {
														KomaClone = Instantiate (this.Pyramid, new Vector3 (c.pos.x, 0, c.pos.z), Quaternion.Euler (0, 180, 0)) as GameObject;
														KomaClone.transform.Translate (0, KomaClone.transform.lossyScale.y, 0);
														KomaClone.GetComponent<Koma> ().kNum = 4;
														KomaClone.GetComponent<Koma> ().Enemy = true;
												}

												if (c.xNum == 7 && c.yNum == 3) {
														KomaClone = Instantiate (this.Pyramid, new Vector3 (c.pos.x, 0, c.pos.z), Quaternion.Euler (0, 90, 0)) as GameObject;
														KomaClone.transform.Translate (0, KomaClone.transform.lossyScale.y, 0);
														KomaClone.GetComponent<Koma> ().kNum = 5;
														KomaClone.GetComponent<Koma> ().Enemy = true;
												}

												if (c.xNum == 7 && c.yNum == 4) {
														KomaClone = Instantiate (this.Pyramid, new Vector3 (c.pos.x, 0, c.pos.z), Quaternion.Euler (0, 180, 0)) as GameObject;
														KomaClone.transform.Translate (0, KomaClone.transform.lossyScale.y, 0);
														KomaClone.GetComponent<Koma> ().kNum = 6;
														KomaClone.GetComponent<Koma> ().Enemy = true;
												}

												if (c.xNum == 7 && c.yNum == 7) {
														KomaClone = Instantiate (this.Pyramid, new Vector3 (c.pos.x, 0, c.pos.z), Quaternion.Euler (0, 180, 0)) as GameObject;
														KomaClone.transform.Translate (0, KomaClone.transform.lossyScale.y, 0);
														KomaClone.GetComponent<Koma> ().kNum = 7;
														KomaClone.GetComponent<Koma> ().Enemy = true;
												}

												//Sphinx
												if (c.xNum == 0 && c.yNum == 7) {
														KomaClone = Instantiate (this.Sphinx, new Vector3 (c.pos.x, 0, c.pos.z), Quaternion.Euler (0, 180, 0)) as GameObject;
														KomaClone.transform.Translate (0, KomaClone.transform.lossyScale.y, 0);
														KomaClone.GetComponent<Koma> ().kNum = 8;
														KomaClone.GetComponent<Koma> ().Enemy = true;
												}

												//Scarab
												if (c.xNum == 4 && c.yNum == 4) {
														KomaClone = Instantiate (this.Scarab, new Vector3 (c.pos.x, 0, c.pos.z), Quaternion.Euler (0, 90, 0)) as GameObject;
														KomaClone.transform.Translate (0, KomaClone.transform.lossyScale.y, 0);
														KomaClone.GetComponent<Koma> ().kNum = 9;
														KomaClone.GetComponent<Koma> ().Enemy = true;
												}

												if (c.xNum == 5 && c.yNum == 4) {
														KomaClone = Instantiate (this.Scarab, new Vector3 (c.pos.x, 0, c.pos.z), Quaternion.identity) as GameObject;
														KomaClone.transform.Translate (0, KomaClone.transform.lossyScale.y, 0);
														KomaClone.GetComponent<Koma> ().kNum = 10;
														KomaClone.GetComponent<Koma> ().Enemy = true;
												}

												//Anubis
												if (c.xNum == 4 && c.yNum == 7) {
														KomaClone = Instantiate (this.Anubis, new Vector3 (c.pos.x, 0, c.pos.z), Quaternion.Euler (0, 180, 0)) as GameObject;
														KomaClone.transform.Translate (0, KomaClone.transform.lossyScale.y, 0);
														KomaClone.GetComponent<Koma> ().kNum = 11;
														KomaClone.GetComponent<Koma> ().Enemy = true;
												}
						
												if (c.xNum == 6 && c.yNum == 7) {
														KomaClone = Instantiate (this.Anubis, new Vector3 (c.pos.x, 0, c.pos.z), Quaternion.Euler (0, 180, 0)) as GameObject;
														KomaClone.transform.Translate (0, KomaClone.transform.lossyScale.y, 0);
														KomaClone.GetComponent<Koma> ().kNum = 12;
														KomaClone.GetComponent<Koma> ().Enemy = true;
												}

												//Pharaoh
												if (c.xNum == 5 && c.yNum == 7) {
														KomaClone = Instantiate (this.Pharaoh, new Vector3 (c.pos.x, 0, c.pos.z), Quaternion.Euler (0, 180, 0)) as GameObject;
														KomaClone.transform.Translate (0, KomaClone.transform.lossyScale.y, 0);
														KomaClone.GetComponent<Koma> ().kNum = 13;
														KomaClone.GetComponent<Koma> ().Enemy = true;
												}

												//1p
												//Pyramid
												if (c.xNum == 2 && c.yNum == 0) {
														KomaClone = Instantiate (this.Pyramid, new Vector3 (c.pos.x, 0, c.pos.z), Quaternion.identity) as GameObject;
														KomaClone.transform.Translate (0, KomaClone.transform.lossyScale.y, 0);
														KomaClone.GetComponent<Koma> ().kNum = 21;
												}
						
												if (c.xNum == 2 && c.yNum == 3) {
														KomaClone = Instantiate (this.Pyramid, new Vector3 (c.pos.x, 0, c.pos.z), Quaternion.identity) as GameObject;
														KomaClone.transform.Translate (0, KomaClone.transform.lossyScale.y, 0);
														KomaClone.GetComponent<Koma> ().kNum = 22;
												}
						
												if (c.xNum == 2 && c.yNum == 4) {
														KomaClone = Instantiate (this.Pyramid, new Vector3 (c.pos.x, 0, c.pos.z), Quaternion.Euler (0, -90, 0)) as GameObject;
														KomaClone.transform.Translate (0, KomaClone.transform.lossyScale.y, 0);
														KomaClone.GetComponent<Koma> ().kNum = 23;
												}
						
												if (c.xNum == 3 && c.yNum == 5) {
														KomaClone = Instantiate (this.Pyramid, new Vector3 (c.pos.x, 0, c.pos.z), Quaternion.identity) as GameObject;
														KomaClone.transform.Translate (0, KomaClone.transform.lossyScale.y, 0);
														KomaClone.GetComponent<Koma> ().kNum = 24;
												}
						
												if (c.xNum == 7 && c.yNum == 1) {
														KomaClone = Instantiate (this.Pyramid, new Vector3 (c.pos.x, 0, c.pos.z), Quaternion.Euler (0, 90, 0)) as GameObject;
														KomaClone.transform.Translate (0, KomaClone.transform.lossyScale.y, 0);
														KomaClone.GetComponent<Koma> ().kNum = 25;
												}
						
												if (c.xNum == 9 && c.yNum == 3) {
														KomaClone = Instantiate (this.Pyramid, new Vector3 (c.pos.x, 0, c.pos.z), Quaternion.Euler (0, -90, 0)) as GameObject;
														KomaClone.transform.Translate (0, KomaClone.transform.lossyScale.y, 0);
														KomaClone.GetComponent<Koma> ().kNum = 26;
												}
						
												if (c.xNum == 9 && c.yNum == 4) {
														KomaClone = Instantiate (this.Pyramid, new Vector3 (c.pos.x, 0, c.pos.z), Quaternion.identity) as GameObject;
														KomaClone.transform.Translate (0, KomaClone.transform.lossyScale.y, 0);
														KomaClone.GetComponent<Koma> ().kNum = 27;
												}

												//Sphinx
												if (c.xNum == 9 && c.yNum == 0) {
														KomaClone = Instantiate (this.Sphinx, new Vector3 (c.pos.x, 0, c.pos.z), Quaternion.identity) as GameObject;
														KomaClone.transform.Translate (0, KomaClone.transform.lossyScale.y, 0);
														KomaClone.GetComponent<Koma> ().kNum = 28;
												}

												//Scarab
												if (c.xNum == 4 && c.yNum == 3) {
														KomaClone = Instantiate (this.Scarab, new Vector3 (c.pos.x, 0, c.pos.z), Quaternion.identity) as GameObject;
														KomaClone.transform.Translate (0, KomaClone.transform.lossyScale.y, 0);
														KomaClone.GetComponent<Koma> ().kNum = 29;
												}
						
												if (c.xNum == 5 && c.yNum == 3) {
														KomaClone = Instantiate (this.Scarab, new Vector3 (c.pos.x, 0, c.pos.z), Quaternion.Euler (0, 90, 0)) as GameObject;
														KomaClone.transform.Translate (0, KomaClone.transform.lossyScale.y, 0);
														KomaClone.GetComponent<Koma> ().kNum = 30;
												}

												//Anubis
												if (c.xNum == 3 && c.yNum == 0) {
														KomaClone = Instantiate (this.Anubis, new Vector3 (c.pos.x, 0, c.pos.z), Quaternion.Euler (0, 0, 0)) as GameObject;
														KomaClone.transform.Translate (0, KomaClone.transform.lossyScale.y, 0);
														KomaClone.GetComponent<Koma> ().kNum = 31;
												}
						
												if (c.xNum == 5 && c.yNum == 0) {
														KomaClone = Instantiate (this.Anubis, new Vector3 (c.pos.x, 0, c.pos.z), Quaternion.identity) as GameObject;
														KomaClone.transform.Translate (0, KomaClone.transform.lossyScale.y, 0);
														KomaClone.GetComponent<Koma> ().kNum = 32;
												}

												//Anubis
												if (c.xNum == 4 && c.yNum == 0) {
														KomaClone = Instantiate (this.Pharaoh, new Vector3 (c.pos.x, 0, c.pos.z), Quaternion.identity) as GameObject;
														KomaClone.transform.Translate (0, KomaClone.transform.lossyScale.y, 0);
														KomaClone.GetComponent<Koma> ().kNum = 33;
												}

										}
								}
								//set wall
								for (float i = 0.55f; i < 8; i = i + 1.1f) {
										for (float j = 0.55f; j < 10; j = j + 1.1f) {
												Instantiate (this.wallY, new Vector3 (j, 0, 3.95f), Quaternion.Euler (0, 90, 0));
										}
										Instantiate (this.wallX, new Vector3 (4.95f, 0, i), Quaternion.Euler (0, 0, 0));
								}
	
								//set koma
								//Instantiate(this.koma, new Vector3(0, 0.55f, 0), Quaternion.identity);
								flag = false;
						}
				} else {
						//Shot Sphinx
						Controll con = GameObject.Find ("ControllPlayer").GetComponent<Controll> ();
						if (GUI.Button (new Rect (350, 30, 100, 30), "Shot!!") && GameObject.Find ("SELECT").GetComponent<Select> ().SelectKomaNum == 0) {
								if (!GameObject.Find ("Laser(Clone)")) {
										GameObject[] cs = GameObject.FindObjectsOfType (typeof(GameObject)) as GameObject[];
										foreach (GameObject cc in cs) {
												if (cc.name == "SphinxPrefab(Clone)") {
>>>>>>> FETCH_HEAD
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
								GUI.Label (new Rect (380, 10, 100, 30), "Player");
						} else {
								GUI.Label (new Rect (380, 10, 100, 30), "Enemy");
						}
				}
<<<<<<< HEAD
				GameObject.Find ("ControllPlayer").GetComponent<Controll> ().Move = false;
				}
			}
			if (!con.Turn) {
				GUI.Label (new Rect (480, 10, 100, 30), "Player");
			} else {
				GUI.Label (new Rect (480, 10, 100, 30), "Enemy");
			}
		}
=======
>>>>>>> FETCH_HEAD

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

	void StartGame(){
		//set board
		GameObject CubeClone;
		GameObject KomaClone;
		
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
				//Pyramid
				if (c.xNum == 0 && c.yNum == 3) {
					KomaClone = Instantiate (this.Pyramid, new Vector3 (c.pos.x, 0, c.pos.z), Quaternion.Euler (0, 180, 0)) as GameObject;
					KomaClone.transform.Translate (0, KomaClone.transform.lossyScale.y, 0);
					KomaClone.GetComponent<Koma> ().kNum = 1;
					KomaClone.GetComponent<Koma> ().Enemy = true;
				}
				
				if (c.xNum == 0 && c.yNum == 4) {
					KomaClone = Instantiate (this.Pyramid, new Vector3 (c.pos.x, 0, c.pos.z), Quaternion.Euler (0, 90, 0)) as GameObject;
					KomaClone.transform.Translate (0, KomaClone.transform.lossyScale.y, 0);
					KomaClone.GetComponent<Koma> ().kNum = 2;
					KomaClone.GetComponent<Koma> ().Enemy = true;
				}
				
				if (c.xNum == 2 && c.yNum == 6) {
					KomaClone = Instantiate (this.Pyramid, new Vector3 (c.pos.x, 0, c.pos.z), Quaternion.Euler (0, -90, 0)) as GameObject;
					KomaClone.transform.Translate (0, KomaClone.transform.lossyScale.y, 0);
					KomaClone.GetComponent<Koma> ().kNum = 3;
					KomaClone.GetComponent<Koma> ().Enemy = true;
				}
				
				if (c.xNum == 6 && c.yNum == 2) {
					KomaClone = Instantiate (this.Pyramid, new Vector3 (c.pos.x, 0, c.pos.z), Quaternion.Euler (0, 180, 0)) as GameObject;
					KomaClone.transform.Translate (0, KomaClone.transform.lossyScale.y, 0);
					KomaClone.GetComponent<Koma> ().kNum = 4;
					KomaClone.GetComponent<Koma> ().Enemy = true;
				}
				
				if (c.xNum == 7 && c.yNum == 3) {
					KomaClone = Instantiate (this.Pyramid, new Vector3 (c.pos.x, 0, c.pos.z), Quaternion.Euler (0, 90, 0)) as GameObject;
					KomaClone.transform.Translate (0, KomaClone.transform.lossyScale.y, 0);
					KomaClone.GetComponent<Koma> ().kNum = 5;
					KomaClone.GetComponent<Koma> ().Enemy = true;
				}
				
				if (c.xNum == 7 && c.yNum == 4) {
					KomaClone = Instantiate (this.Pyramid, new Vector3 (c.pos.x, 0, c.pos.z), Quaternion.Euler (0, 180, 0)) as GameObject;
					KomaClone.transform.Translate (0, KomaClone.transform.lossyScale.y, 0);
					KomaClone.GetComponent<Koma> ().kNum = 6;
					KomaClone.GetComponent<Koma> ().Enemy = true;
				}
				
				if (c.xNum == 7 && c.yNum == 7) {
					KomaClone = Instantiate (this.Pyramid, new Vector3 (c.pos.x, 0, c.pos.z), Quaternion.Euler (0, 180, 0)) as GameObject;
					KomaClone.transform.Translate (0, KomaClone.transform.lossyScale.y, 0);
					KomaClone.GetComponent<Koma> ().kNum = 7;
					KomaClone.GetComponent<Koma> ().Enemy = true;
				}
				
				//Sphinx
				if (c.xNum == 0 && c.yNum == 7) {
					KomaClone = Instantiate (this.Sphinx, new Vector3 (c.pos.x, 0, c.pos.z), Quaternion.Euler (0, 180, 0)) as GameObject;
					KomaClone.transform.Translate (0, KomaClone.transform.lossyScale.y, 0);
					KomaClone.GetComponent<Koma> ().kNum = 8;
					KomaClone.GetComponent<Koma> ().Enemy = true;
				}
				
				//Scarab
				if (c.xNum == 4 && c.yNum == 4) {
					KomaClone = Instantiate (this.Scarab, new Vector3 (c.pos.x, 0, c.pos.z), Quaternion.Euler (0, 90, 0)) as GameObject;
					KomaClone.transform.Translate (0, KomaClone.transform.lossyScale.y, 0);
					KomaClone.GetComponent<Koma> ().kNum = 9;
					KomaClone.GetComponent<Koma> ().Enemy = true;
				}
				
				if (c.xNum == 5 && c.yNum == 4) {
					KomaClone = Instantiate (this.Scarab, new Vector3 (c.pos.x, 0, c.pos.z), Quaternion.identity) as GameObject;
					KomaClone.transform.Translate (0, KomaClone.transform.lossyScale.y, 0);
					KomaClone.GetComponent<Koma> ().kNum = 10;
					KomaClone.GetComponent<Koma> ().Enemy = true;
				}
				
				//Anubis
				if (c.xNum == 4 && c.yNum == 7) {
					KomaClone = Instantiate (this.Anubis, new Vector3 (c.pos.x, 0, c.pos.z), Quaternion.Euler (0, 180, 0)) as GameObject;
					KomaClone.transform.Translate (0, KomaClone.transform.lossyScale.y, 0);
					KomaClone.GetComponent<Koma> ().kNum = 11;
					KomaClone.GetComponent<Koma> ().Enemy = true;
				}
				
				if (c.xNum == 6 && c.yNum == 7) {
					KomaClone = Instantiate (this.Anubis, new Vector3 (c.pos.x, 0, c.pos.z), Quaternion.Euler (0, 180, 0)) as GameObject;
					KomaClone.transform.Translate (0, KomaClone.transform.lossyScale.y, 0);
					KomaClone.GetComponent<Koma> ().kNum = 12;
					KomaClone.GetComponent<Koma> ().Enemy = true;
				}
				
				//Pharaoh
				if (c.xNum == 5 && c.yNum == 7) {
					KomaClone = Instantiate (this.Pharaoh, new Vector3 (c.pos.x, 0, c.pos.z), Quaternion.Euler (0, 180, 0)) as GameObject;
					KomaClone.transform.Translate (0, KomaClone.transform.lossyScale.y, 0);
					KomaClone.GetComponent<Koma> ().kNum = 13;
					KomaClone.GetComponent<Koma> ().Enemy = true;
				}
				
				//1p
				//Pyramid
				if (c.xNum == 2 && c.yNum == 0) {
					KomaClone = Instantiate (this.Pyramid, new Vector3 (c.pos.x, 0, c.pos.z), Quaternion.identity) as GameObject;
					KomaClone.transform.Translate (0, KomaClone.transform.lossyScale.y, 0);
					KomaClone.GetComponent<Koma> ().kNum = 21;
				}
				
				if (c.xNum == 2 && c.yNum == 3) {
					KomaClone = Instantiate (this.Pyramid, new Vector3 (c.pos.x, 0, c.pos.z), Quaternion.identity) as GameObject;
					KomaClone.transform.Translate (0, KomaClone.transform.lossyScale.y, 0);
					KomaClone.GetComponent<Koma> ().kNum = 22;
				}
				
				if (c.xNum == 2 && c.yNum == 4) {
					KomaClone = Instantiate (this.Pyramid, new Vector3 (c.pos.x, 0, c.pos.z), Quaternion.Euler (0, -90, 0)) as GameObject;
					KomaClone.transform.Translate (0, KomaClone.transform.lossyScale.y, 0);
					KomaClone.GetComponent<Koma> ().kNum = 23;
				}
				
				if (c.xNum == 3 && c.yNum == 5) {
					KomaClone = Instantiate (this.Pyramid, new Vector3 (c.pos.x, 0, c.pos.z), Quaternion.identity) as GameObject;
					KomaClone.transform.Translate (0, KomaClone.transform.lossyScale.y, 0);
					KomaClone.GetComponent<Koma> ().kNum = 24;
				}
				
				if (c.xNum == 7 && c.yNum == 1) {
					KomaClone = Instantiate (this.Pyramid, new Vector3 (c.pos.x, 0, c.pos.z), Quaternion.Euler (0, 90, 0)) as GameObject;
					KomaClone.transform.Translate (0, KomaClone.transform.lossyScale.y, 0);
					KomaClone.GetComponent<Koma> ().kNum = 25;
				}
				
				if (c.xNum == 9 && c.yNum == 3) {
					KomaClone = Instantiate (this.Pyramid, new Vector3 (c.pos.x, 0, c.pos.z), Quaternion.Euler (0, -90, 0)) as GameObject;
					KomaClone.transform.Translate (0, KomaClone.transform.lossyScale.y, 0);
					KomaClone.GetComponent<Koma> ().kNum = 26;
				}
				
				if (c.xNum == 9 && c.yNum == 4) {
					KomaClone = Instantiate (this.Pyramid, new Vector3 (c.pos.x, 0, c.pos.z), Quaternion.identity) as GameObject;
					KomaClone.transform.Translate (0, KomaClone.transform.lossyScale.y, 0);
					KomaClone.GetComponent<Koma> ().kNum = 27;
				}
				
				//Sphinx
				if (c.xNum == 9 && c.yNum == 0) {
					KomaClone = Instantiate (this.Sphinx, new Vector3 (c.pos.x, 0, c.pos.z), Quaternion.identity) as GameObject;
					KomaClone.transform.Translate (0, KomaClone.transform.lossyScale.y, 0);
					KomaClone.GetComponent<Koma> ().kNum = 28;
				}
				
				//Scarab
				if (c.xNum == 4 && c.yNum == 3) {
					KomaClone = Instantiate (this.Scarab, new Vector3 (c.pos.x, 0, c.pos.z), Quaternion.identity) as GameObject;
					KomaClone.transform.Translate (0, KomaClone.transform.lossyScale.y, 0);
					KomaClone.GetComponent<Koma> ().kNum = 29;
				}
				
				if (c.xNum == 5 && c.yNum == 3) {
					KomaClone = Instantiate (this.Scarab, new Vector3 (c.pos.x, 0, c.pos.z), Quaternion.Euler (0, 90, 0)) as GameObject;
					KomaClone.transform.Translate (0, KomaClone.transform.lossyScale.y, 0);
					KomaClone.GetComponent<Koma> ().kNum = 30;
				}
				
				//Anubis
				if (c.xNum == 3 && c.yNum == 0) {
					KomaClone = Instantiate (this.Anubis, new Vector3 (c.pos.x, 0, c.pos.z), Quaternion.identity) as GameObject;
					KomaClone.transform.Translate (0, KomaClone.transform.lossyScale.y, 0);
					KomaClone.GetComponent<Koma> ().kNum = 31;
				}
				
				if (c.xNum == 5 && c.yNum == 0) {
					KomaClone = Instantiate (this.Anubis, new Vector3 (c.pos.x, 0, c.pos.z), Quaternion.identity) as GameObject;
					KomaClone.transform.Translate (0, KomaClone.transform.lossyScale.y, 0);
					KomaClone.GetComponent<Koma> ().kNum = 32;
				}
				
				//Anubis
				if (c.xNum == 4 && c.yNum == 0) {
					KomaClone = Instantiate (this.Pharaoh, new Vector3 (c.pos.x, 0, c.pos.z), Quaternion.identity) as GameObject;
					KomaClone.transform.Translate (0, KomaClone.transform.lossyScale.y, 0);
					KomaClone.GetComponent<Koma> ().kNum = 33;
				}
				
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
		flag = false;
	
	}


}
