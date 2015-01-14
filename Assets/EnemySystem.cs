using UnityEngine;
using System.Collections;

public struct moveKoma
{
	public int xNum;
	public int yNum;
	public int kNum;
	public bool Enemy;
	public string Name;
	public int Angle;
	public bool up;
	public bool down;
	public bool left;
	public bool right;
	public int Value;
	public int undoX;
	public int undoY;
	
	public void enterKoma (int xnum, int ynum, int knum, bool enemy, string name, int angle)
	{
		xNum = xnum;
		yNum = ynum;
		kNum = knum;
		Enemy = enemy;
		Name = name;
		Angle = angle;
		Value = initVal (name);
	}

	public void init ()
	{
		cleanAngle (Angle);
		rotation (Angle);
		rmUndo ();
	}

	void rotation (int angle)
	{

		if (Name == "MirrorPrefab(Clone)" || Name == "ScarabPrefab(Clone)") {
			switch (angle) {
			case 0:
				up = true;
				down = false;
				left = true;
				right = false;
				break;
			case 90:
				up = true;
				down = false;
				left = false;
				right = true;
				break;
			case 180:
				up = false;
				down = true;
				left = false;
				right = true;
				break;
			case 270:
				up = false;
				down = true;
				left = true;
				right = false;
				break;
			default:
				break;
			}
		} else if (Name == "AnubisPrefab(Clone)") {
			switch (angle) {
			case 0:
				up = true;
				break;
			case 90:
				right = true;
				break;
			case 180:
				down = true;
				break;
			case 270:
				left = true;
				break;
			default:
				break;
			}
		}
	}

	void cleanAngle (int angle)
	{
		if (angle == 89)
			Angle = 90;
		else if (angle == 179)
			Angle = 180;
		else if (angle == 269)
			Angle = 270;
		else if (angle == 359)
			Angle = 360;
//		else Debug.Log("AngleError");

	}

	public void moving (int muki)
	{
		rmUndo ();

		switch (muki) {
		case 0:
			if (yNum < 7) {
				yNum += 1;
			}
			break;
		case 1:
			if (xNum < 9 && yNum < 7) {
				xNum += 1;
				yNum += 1;
			}
			break;
		case 2:
			if (xNum < 9) {
				xNum += 1;
			}
			break;
		case 3:
			if (xNum < 9 && yNum > 0) {
				xNum += 1;
				yNum -= 1;
			}
			break;
		case 4:
			if (yNum > 0) {
				yNum -= 1;
			}
			break;
		case 5:
			if (xNum > 0 && yNum > 0) {
				xNum -= 1;
				yNum -= 1;
			}
			break;
		case 6:
			if (xNum > 0) {
				xNum -= 1;
			}
			break;
		case 7:
			if (xNum > 0 && yNum < 7) {
				xNum -= 1;
				yNum += 1;
			}
			break;
		default:
			Debug.Log ("Happen anything error");
			break;
		}
		//		Debug.Log ("use");
	}

	public void spin (bool right)
	{

		if (Name == "SphinxPrefab(Clone)") {
			if (Enemy) {
				if (Angle == 90 && right) {
					Angle = 180;
				} else if (Angle == 180 && !right) {
					Angle = 90;
				}
			} else {
				if (Angle == 270 && right) {
					Angle = 0;
				} else if (Angle == 0 && !right) {
					Angle = 270;
				}
			}
		} else if (right) {
			Angle += 90;
			if (Angle == 360)
				Angle = 0;
		} else {
			Angle -= 90;
			if (Angle == -90)
				Angle = 270;
		}
		init ();
	}

	void rmUndo ()
	{
		undoX = xNum;
		undoY = yNum;
	}

	int initVal (string name)
	{
		if (name == "PharaohPrefab(Clone)") {
			return 100;
		} else if (name == "AnubisPrefab(Clone)") {
			return 50;
		} else if (name == "MirrorPrefab(Clone)") {
			return 10;
		}
		return 0;
	}
}

public struct Laser
{
	public int x;
	public int y;
	public int angle;

	public Laser (bool enemy)
	{
		if (enemy) {
			x = 0;
			y = 7;
		} else {
			x = 9;
			y = 0;
		}
		angle = 1;
	}

	public void angleSet (int a)
	{
		switch (a) {
		case 0:
			angle = 1;
			break;
		case 90:
			angle = 2;
			break;
		case 180:
			angle = 3;
			break;
		case 270:
			angle = 4;
			break;
		default:
			break;
		}
	}

	public void move ()
	{
		switch (angle) {
		case 1:
			y -= 1;
			break;
		case 2:
			x += 1;
			break;
		case 3:
			y += 1;
			break;
		case 4:
			x -= 1;
			break;
		default:
			break;
		}
	}

	public void spin (bool right)
	{
		if (right)
			angle++;
		else
			angle--;

		if (angle == 5)
			angle = 1;
		if (angle == 0)
			angle = 4;
	}

}

public struct Value
{
	public int val;
	public int kNum;
	public int mNum;
}

//public struct Undo{
//	public moveKoma[] koma;
//
//	public Undo(moveKoma[] m){
//		koma = new moveKoma[30];
//		koma = m;
//	}
//
//}

public class EnemySystem : MonoBehaviour
{
	public int x;
	public bool Enemy;
	int SEARCH_LEVEL;
	moveKoma[] move;
	moveKoma[] list;
	// Use this for initialization
	void Start ()
	{
		x = 1;
		SEARCH_LEVEL = 3;
		list = new moveKoma[30];
//		move = new moveKoma[26];
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (GameObject.Find ("ControllPlayer").GetComponent<Controll> ().Turn && !GameObject.Find ("Laser(Clone)") && Enemy) {
			Resources.UnloadUnusedAssets ();
			while (x == 1) {

				int i = 0;
				GameObject[] cs = GameObject.FindObjectsOfType (typeof(GameObject)) as GameObject[];
				foreach (GameObject cc in cs) {
					if (cc.tag == "Koma") {
						Koma koma = cc.GetComponent<Koma> (); 
						list [i].enterKoma (koma.xNum, koma.yNum, koma.kNum, koma.Enemy, koma.name, (int)koma.transform.eulerAngles.y);
						list [i].init ();
//						Debug.Log(i);
//						Debug.Log (move[26].Name);
//						if (move [i].kNum == 26) {
//							Debug.Log (move [i].up);
//							Debug.Log (move [i].xNum);
//							Debug.Log (move [i].yNum);
//						}
						i++;
					}
				}
//				Debug.Log (i);
				move = new moveKoma[i];
				for (int j = 0; j<i; j++) {
					move [j] = list [j];
				}
				x++;
				Time.timeScale = 0;
				compute ();
				Time.timeScale = 1;
//				move [2].moving (3);
			}

		}
	}

	void Shot (bool enemy)
	{

		Laser laser = new Laser (enemy);
		for (int i=0; i<move.Length; i++) {
			if (move [i].Name == "SphinxPrefab(Clone)" && move [i].Enemy == enemy)
				laser.angleSet (move [i].Angle);
		}
		while (true) {

			laser.move ();
			if (laser.x < 0 || laser.x > 9 || laser.y < 0 || laser.y > 9) {
				break;
			}
			bool izanami = false;

			for (int i=0; i<move.Length; i++) {
//				Debug.Log("DesShot");

				if (laser.x == move [i].xNum && laser.y == move [i].yNum) {

					if (laser.angle == 1) {
						if (move [i].Name != "ScarabPrefab(Clone)") {
							if (move [i].down) {
								if (move [i].right) {
									laser.spin (true);
								} else if (move [i].left) {
									laser.spin (false);
								}
							} else {
								Destroy (move [i]);
								izanami = true;
							}
						} else {
							if (move [i].down) {
								if (move [i].right) {
									laser.spin (true);
								} else if (move [i].left) {
									laser.spin (false);
								}
							} else {
								if (!move [i].right) {
									laser.spin (true);
								} else if (!move [i].left) {
									laser.spin (false);
								}
							}
						}
					}

					if (laser.angle == 2) {
						if (move [i].Name != "ScarabPrefab(Clone)") {
							if (move [i].left) {
								if (move [i].up) {
									laser.spin (false);
								} else if (move [i].down) {
									laser.spin (true);
								}
							} else {
								Destroy (move [i]);
								izanami = true;
							}
						} else {
							if (move [i].left) {
								if (move [i].up) {
									laser.spin (false);
								} else if (move [i].down) {
									laser.spin (true);
								}
							} else {
								if (!move [i].up) {
									laser.spin (false);
								} else if (!move [i].down) {
									laser.spin (true);
								}
							}
						}
					}


					if (laser.angle == 3) {
						if (move [i].Name != "ScarabPrefab(Clone)") {
							if (move [i].up) {
								if (move [i].right) {
									laser.spin (false);
								} else if (move [i].left) {
									laser.spin (true);
								}
							} else {
								Destroy (move [i]);
								izanami = true;
							}
						} else {
							if (move [i].up) {
								if (move [i].right) {
									laser.spin (false);
								} else if (move [i].left) {
									laser.spin (true);
								}
							} else {
								if (!move [i].right) {
									laser.spin (false);
								} else if (!move [i].left) {
									laser.spin (true);
								}
							}
						}
					}


					if (laser.angle == 4) {
						if (move [i].Name != "ScarabPrefab(Clone)") {
							if (move [i].right) {
								if (move [i].up) {
									laser.spin (true);
								} else if (move [i].down) {
									laser.spin (false);
								}
							} else {
								Destroy (move [i]);
								izanami = true;
							}
						} else {
							if (move [i].right) {
								if (move [i].up) {
									laser.spin (true);
								} else if (move [i].down) {
									laser.spin (false);
								}
							} else {
								if (!move [i].up) {
									laser.spin (true);
								} else if (!move [i].down) {
									laser.spin (false);
								}
							}
						}
					}


				}
			}
			if (izanami) {
				Resources.UnloadUnusedAssets ();
				break;
			}
		}
	}

	int returnShot (bool enemy)
	{
		
		Laser laser = new Laser (enemy);
		for (int i=0; i<move.Length; i++) {
			if (move [i].Name == "PharaohPrefab(Clone)" && move [i].Enemy != enemy)
				laser.angleSet (move [i].Angle);
		}
		while (true) {
			
			laser.move ();
			if (laser.x < 0 || laser.x > 9 || laser.y < 0 || laser.y > 9) {
				break;
			}
			
			for (int i=0; i<move.Length; i++) {
				//				Debug.Log("DesShot");
				
				if (laser.x == move [i].xNum && laser.y == move [i].yNum) {
					
					if (laser.angle == 1) {
						if (move [i].Name != "ScarabPrefab(Clone)") {
							if (move [i].down) {
								if (move [i].right) {
									laser.spin (true);
								} else if (move [i].left) {
									laser.spin (false);
								}
							}
						} else {
							if (move [i].down) {
								if (move [i].right) {
									laser.spin (true);
								} else if (move [i].left) {
									laser.spin (false);
								}
							} else {
								if (!move [i].right) {
									laser.spin (true);
								} else if (!move [i].left) {
									laser.spin (false);
								}
							}
						}
					}
					
					if (laser.angle == 2) {
						if (move [i].Name != "ScarabPrefab(Clone)") {
							if (move [i].left) {
								if (move [i].up) {
									laser.spin (false);
								} else if (move [i].down) {
									laser.spin (true);
								}
							}
						} else {
							if (move [i].left) {
								if (move [i].up) {
									laser.spin (false);
								} else if (move [i].down) {
									laser.spin (true);
								}
							} else {
								if (!move [i].up) {
									laser.spin (false);
								} else if (!move [i].down) {
									laser.spin (true);
								}
							}
						}
					}
					
					
					if (laser.angle == 3) {
						if (move [i].Name != "ScarabPrefab(Clone)") {
							if (move [i].up) {
								if (move [i].right) {
									laser.spin (false);
								} else if (move [i].left) {
									laser.spin (true);
								}
							}
						} else {
							if (move [i].up) {
								if (move [i].right) {
									laser.spin (false);
								} else if (move [i].left) {
									laser.spin (true);
								}
							} else {
								if (!move [i].right) {
									laser.spin (false);
								} else if (!move [i].left) {
									laser.spin (true);
								}
							}
						}
					}
					
					
					if (laser.angle == 4) {
						if (move [i].Name != "ScarabPrefab(Clone)") {
							if (move [i].right) {
								if (move [i].up) {
									laser.spin (true);
								} else if (move [i].down) {
									laser.spin (false);
								}
							}
						} else {
							if (move [i].right) {
								if (move [i].up) {
									laser.spin (true);
								} else if (move [i].down) {
									laser.spin (false);
								}
							} else {
								if (!move [i].up) {
									laser.spin (true);
								} else if (!move [i].down) {
									laser.spin (false);
								}
							}
						}
					}
					
					
				}
			}
		}

		return boardScore (laser.x, laser.y, enemy);
	}

	int boardScore (int x, int y, bool enemy)
	{
		if (enemy) {
			if (x >= -1 && x <= 2 && y >= 5 && y <= 8)
				return 30;
			else if (x == -1 && y <= 4)
				return 20;
		} else {
			if (x >= 7 && x <= 10 && y >= -1 && y <= 2)
				return 30;
			else if (x == 10 && y <= 3)
				return 20;
		}
		return 0;
	}

	void Destroy (moveKoma m)
	{
		m.xNum = 10;
		m.yNum = 10;

	}

	moveKoma komaMove (int num, moveKoma m)
	{
//		if (m.kNum == 8) {
//			Debug.Log (m.xNum);
//			Debug.Log (m.yNum);
//			Debug.Log (m.Name);
//			Debug.Log ("move");
//		}
		moveKoma[] undo = new moveKoma[move.Length];
		for (int i = 0; i<move.Length; i++) {
			undo [i] = move [i];
		}

		if (num < 8) {
			if (m.Name == "ScarabPrefab(Clone)" || m.Name == "MirrorPrefab(Clone)" || m.Name == "AnubisPrefab(Clone)")
				m.moving (num);

		} else if (num == 8) {
			if (m.Name != "PharaohPrefab(Clone)")
				m.spin (true);
		} else if (num == 9) {
			if (m.Name != "PharaohPrefab(Clone)")
				m.spin (false);
		}

//		switch (num) {
//		case 0:
//			m.moving (1);
//			break;
//		case 1:
//			m.moving (2);
//			break;
//		case 2:
//			m.moving (3);
//			break;
//		case 3:
//			m.moving (4);
//			break;
//		case 4:
//			m.moving (5);
//			break;
//		case 5:
//			m.moving (6);
//			break;
//		case 6:
//			m.moving (7);
//			break;
//		case 7:
//			m.moving (8);
//			break;
//		case 8:
//			m.spin (true);
//			break;
//		case 9:
//			m.spin (false);
//			break;
//		default:
//			break;
//		}

//		for (int i = 0; i<undo.Length; i++) {
//			m.moveJudge (undo [i]);
//		}
//		Debug.Log("Before");
		for (int i = 0; i<undo.Length; i++) {
			if (m.xNum == undo [i].xNum && m.yNum == undo [i].yNum && num < 8) {
//				Debug.Log(m.Name);
//				Debug.Log(undo[i].Name);
				if (m.Name == "ScarabPrefab(Clone)" && (undo [i].Name == "AnubisPrefab(Clone)" || undo [i].Name == "MirrorPrefab(Clone)")) {
//					Debug.Log("calling");
					for (int j = 0; j<move.Length; j++) {
						if (move [j].xNum == undo [i].xNum && move [j].yNum == undo [i].yNum) {
							move [j].xNum = m.xNum;
							move [j].yNum = m.yNum;
						}
					}
					break;
				} else {
//					Debug.Log("cal");
//					Debug.Log(m.undoX);
					m.xNum = m.undoX;
					m.yNum = m.undoY;
					break;
				}
			}
		}
		
		return m;
	}

	void compute ()
	{
		//minimax
//		int v = minimax (true, SEARCH_LEVEL);
		int v = alphaBeta (true, SEARCH_LEVEL, 0, 10000);
		//decision moving
		Debug.Log (v);
		realMove (v);
//		Debug.Log (v.mNum);
//		Debug.Log (v.val);

	}

//	int minimax (bool flag, int level)
//	{
////		Debug.Log("mini");
//		Value value = new Value ();
//		int val = 0;
//		int childValue = 0;
//	
//		if (level == 0) {
//			for (int i=0; i<move.Length; i++) {
//				if (move [i].xNum == 10 && move [i].yNum == 10 && !move [i].Enemy)
//					val += move [i].Value;
//			}
//			return val;
//		}
//	
//		if (flag) {
//			val = 0;
//		} else {
//			val = 10000;
//		}
//
//		for (int i = 0; i<move.Length; i++) {
//			for (int num = 0; num<10; num++) {
//			
//				moveKoma[] undo = new moveKoma[30];
//				for (int j = 0; j<move.Length; j++) {
//					undo [j] = move [j];
//				}
//
//				if (move [i].Enemy == flag) {
//					komaMove (num, move [i]);
//					Shot (flag);
//					value.kNum = move [i].kNum;
//					value.mNum = num;
//				}
//
//				childValue = minimax (!flag, level - 1);
//
//				if (flag) {
//					if (childValue > val) {
//						val = childValue;
//					}
//				} else {
//					if (childValue < val) {
//						val = childValue;
//					}
//				}
//
//				for (int k= 0; k<move.Length; k++) {
//					move [k] = undo [k];
//				}
//
//			}
//		}
//		if (level == SEARCH_LEVEL) {
//			return value.mNum + value.kNum * 10;
//		} else {
//			return val;
//		}
//	}

	int alphaBeta (bool flag, int level, int alpha, int beta)
	{
		//		Debug.Log("mini");
//		Value value = new Value ();
		int val = 0;
		int childValue = 0;

		int bestK = 0;
		int bestM = 0;
		int count = 0;

//		if(count == 26){
//			if (flag) {
//				return 0;
//			} else {
//				return 10000;
//			}
//		}else{
//			count = 0;
//		}


		if (level == 0) {
			for (int i=0; i<move.Length; i++) {
				if (move [i].Enemy == flag && move [i].xNum < 10 && move [i].yNum < 10)
					val += move [i].Value;
				if (move [i].xNum == 10 && move [i].yNum == 10 && move [i].Enemy != flag)
					val += move [i].Value;
			}
//			val += returnShot (flag);
//			if (val > 0)
//				Debug.Log (val);
			Resources.UnloadUnusedAssets ();
			return val;
		}
		
		if (flag) {
			val = 0;
		} else {
			val = 10000;
		}
		
		for (int i = 0; i<move.Length; i++) {
			for (int num = 0; num<10; num++) {
				if (move [i].Enemy == flag) {
					count = 0;
					Resources.UnloadUnusedAssets();
					moveKoma[] undo = new moveKoma[move.Length];
					for (int j = 0; j<move.Length; j++) {
						undo [j] = move [j];
					}
				
//					if (move [i].kNum == 8) {
//						Debug.Log (move [i].xNum);
//						Debug.Log (move [i].yNum);
//						Debug.Log (move [i].Angle);
//						Debug.Log ("");
//					}
//					Debug.Log (move [i].xNum);
//					Debug.Log (move [i].yNum);
					move [i] = komaMove (num, move [i]);
//					Debug.Log (move [i].xNum);
//					Debug.Log (move [i].yNum);
//					Debug.Log ("");
					Shot (flag);

					int l;
					for (l = 0; l<undo.Length; l++) {
						if (undo [l].xNum == move [l].xNum && undo [l].yNum == move [l].yNum && undo [l].Angle == move [l].Angle) {
							count++;
						} else {
//							if (move [l].kNum == 9) {
//								Debug.Log (move [l].xNum);
//								Debug.Log (move [l].yNum);
//								Debug.Log (move [l].Angle);
//								Debug.Log ("");
//								
//								Debug.Log (undo [l].xNum);
//								Debug.Log (undo [l].yNum);
//								Debug.Log (undo [l].Angle);
//								Debug.Log ("");
//							}
						}
					}
//					if (move [i].kNum == 9) {
//						Debug.Log (l);
//						Debug.Log (count);
//						Debug.Log ("");
//					}
					if (count != 26) {
//					Debug.Log ("child");
						childValue = alphaBeta (!flag, level - 1, alpha, beta);
					} 

//					for (int k= 0; k<move.Length; k++) {
//						move [k] = undo [k];
//						Debug.Log ("undo"); //OK
//						Debug.Log (move [k].xNum);
//						Debug.Log (undo [k].xNum);
//					}
//					else {
//					if (flag) {
//						childValue = 0;
//					} else {
//						childValue = 10000;
//					}
//				}

					if (flag) {
						if (childValue > val) {
							val = childValue;
							bestK = move [i].kNum;
							bestM = num;
							alpha = val;
						}

						if (val > beta) {
							for (int k= 0; k<move.Length; k++) {
								move [k] = undo [k];
							}
							Resources.UnloadUnusedAssets ();
							return val;
						}


					} else {
						if (childValue < val) {
							val = childValue;
							bestK = move [i].kNum;
							bestM = num;
							beta = val;
						}

						if (val < alpha) {
							for (int k= 0; k<move.Length; k++) {
								move [k] = undo [k];
							}
							Resources.UnloadUnusedAssets ();
							return val;
						}
//					if (level != SEARCH_LEVEL) {
//						for (int j = 0; j<move.Length; j++) {
//							if (undo [j].xNum == move [j].xNum && undo [j].yNum == move [j].yNum && undo [j].Angle == move [j].Angle) {
//								count++;
//							}
//						}
//					}
//					
//					if (count == 26) {
//						return val;
//					}
					}
				
					for (int k= 0; k<move.Length; k++) {
						move [k] = undo [k];
//						Debug.Log("undo"); //OK
//						Debug.Log (move [k].xNum);
//						Debug.Log (undo [k].xNum);
					}
					Resources.UnloadUnusedAssets ();
				}
			}
		}
		if (level == SEARCH_LEVEL) {
//			for (int i = 0; i<move.Length; i++) {
//				Debug.Log (move [i].xNum);
//				Debug.Log (move [i].yNum);
//				Debug.Log ("");
//			}
			Resources.UnloadUnusedAssets ();
			return bestM + bestK * 10;
		} else {
//			Debug.Log (val);
			Resources.UnloadUnusedAssets ();
			return val;
		}
	}

	void realMove (int val)
	{
		moveKoma p = new moveKoma (); 

		GameObject[] kks = GameObject.FindObjectsOfType (typeof(GameObject)) as GameObject[];
		foreach (GameObject kk in kks) {
			if (kk.tag == "Koma") {
				Koma koma = kk.GetComponent<Koma> ();
				if (koma.kNum == val / 10) {
					p.xNum = koma.xNum;
					p.yNum = koma.yNum;

					//move
					if (val % 10 < 8) {
						p.moving (val % 10);

						GameObject[] cs = GameObject.FindObjectsOfType (typeof(GameObject)) as GameObject[];
						foreach (GameObject cc in cs) {
							if (cc.name == "CubePrefab(Clone)") {
								Cube C = cc.GetComponent<Cube> ();
								if (C.xNum == p.xNum && C.yNum == p.yNum) {

									if (!C.CollisionStay) {
										koma.transform.position = C.pos;
									} else {

										GameObject[] kss = GameObject.FindObjectsOfType (typeof(GameObject)) as GameObject[];
										foreach (GameObject ks in kss) {
											if (ks.tag == "Koma") {
												Koma komas = ks.GetComponent<Koma> ();
												if (komas.xNum == p.xNum && komas.yNum == p.yNum) {
													komas.transform.position = koma.transform.position;
													koma.transform.position = C.pos;
												}
											}
										}
									}
								}
							}
						}

					} else if (val % 10 == 8) {
//						p.spin(true);
						koma.transform.Rotate (new Vector3 (0, 90f, 0));
					} else if (val % 10 == 9) {
//						p.spin(false);
						koma.transform.Rotate (new Vector3 (0, -90f, 0));
					}


				}
			}
		}

		//shot laser
		Controll con = GameObject.Find ("ControllPlayer").GetComponent<Controll> ();
		GameObject[] sc = GameObject.FindObjectsOfType (typeof(GameObject)) as GameObject[];
		foreach (GameObject ss in sc) {
			if (ss.name == "SphinxPrefab(Clone)") {
				//						Debug.Log(cc.name);
				if (ss.GetComponent<Koma> ().Enemy == con.Turn) {
					ss.GetComponent<Sphinx> ().Shot = true;
				}
			}
		}
		GameObject.Find ("ControllPlayer").GetComponent<Controll> ().Move = false;
	}

}


