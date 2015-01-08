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
	int undoX;
	int undoY;
	
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
		rotation (Angle);
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

	public void moving (int muki)
	{
		undoX = xNum;
		undoY = yNum;

		switch (muki) {
		case 0:
			if (yNum > 0) {
				yNum -= 1;
			}
			break;
		case 1:
			if (xNum < 9 && yNum > 0) {
				xNum += 1;
				yNum -= 1;
			}
			break;
		case 2:
			if (xNum < 9) {
				xNum += 1;
			}
			break;
		case 3:
			if (xNum < 9 && yNum < 9) {
				xNum += 1;
				yNum += 1;
			}
			break;
		case 4:
			if (yNum < 9) {
				yNum += 1;
			}
			break;
		case 5:
			if (xNum > 0 && yNum < 9) {
				xNum -= 1;
				yNum += 1;
			}
			break;
		case 6:
			if (xNum > 0) {
				xNum -= 1;
			}
			break;
		case 7:
			if (xNum > 0 && yNum > 0) {
				xNum -= 1;
				yNum -= 1;
			}
			break;
		default:
			Debug.Log ("Happen anything error");
			break;
		}
		//		Debug.Log ("use");
	}

	public void moveJudge (moveKoma m)
	{
		if (Name == "ScarabePrefab(Clone)" && (m.Name == "AnubisPrefab(Clone)" || m.Name == "MirrorPrefab(Clone)")) {
			xNum = m.xNum;
			yNum = m.yNum;
			m.xNum = undoX;
			m.yNum = undoY;
		} else {
			xNum = undoX;
			yNum = undoY;
		}
	}

	public void spin (bool right)
	{

		if(Name == "SphinxPrefab(Clone)"){
			if(Enemy){
				if(Angle == 90 && right){
					Angle = 180;
				}else if(Angle == 180 && !right){
					Angle = 90;
				}
			}else{
				if(Angle == 270 && right){
					Angle = 0;
				}else if(Angle == 0 && !right){
					Angle = 270;
				}
			}
		}else if (right) {
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

	public void angleSet(int a){
		switch(a){
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
	int SEARCH_LEVEL;
	moveKoma[] move;
	// Use this for initialization
	void Start ()
	{
		x = 1;
		SEARCH_LEVEL = 3;
		move = new moveKoma[30];
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (GameObject.Find ("ControllPlayer").GetComponent<Controll> ().Turn && !GameObject.Find ("Laser(Clone)")) {

			while (x == 1) {

				int i = 0;
				GameObject[] cs = GameObject.FindObjectsOfType (typeof(GameObject)) as GameObject[];
				foreach (GameObject cc in cs) {
					if (cc.tag == "Koma") {
						Koma koma = cc.GetComponent<Koma> (); 
						move [i].enterKoma (koma.xNum, koma.yNum, koma.kNum, koma.Enemy, koma.name, (int)koma.transform.eulerAngles.y);
						move [i].init ();
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
				x++;
				compute ();
//				move [2].moving (3);
			}

		}
	}

	void Shot (bool enemy)
	{

		Laser laser = new Laser (enemy);
		for (int i=0; i<move.Length; i++) {
			if (move [i].Name == "SphinxPrefab(Clone)" && move[i].Enemy == enemy)
				laser.angleSet(move[i].Angle);
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
			if (izanami)
				break;
		}
	}

	void Destroy (moveKoma m)
	{
		m.xNum = 10;
		m.yNum = 10;

	}

	void undoGame (moveKoma[] m)
	{
		moveKoma[] undo = new moveKoma[30];
		for (int i= 0; i<undo.Length; i++) {
			move [i] = undo [i];
		}
	}

	void komaMove (int num, moveKoma m)
	{

		moveKoma[] undo = new moveKoma[30];
		for (int i = 0; i<move.Length; i++) {
			undo [i] = move [i];
		}

		if(num < 8){
			m.moving(num);
		}else if (num == 8){
			m.spin(true);
		}else if(num == 9){
			m.spin(false);
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

		for (int i = 0; i<undo.Length; i++) {
			m.moveJudge (undo [i]);
		}

	}

	void compute ()
	{
		//minimax
		int v = minimax (true, SEARCH_LEVEL);
		//decision moving
//		Debug.Log (v);
		realMove(v);
//		Debug.Log (v.mNum);
//		Debug.Log (v.val);

	}

	int minimax (bool flag, int level)
	{
//		Debug.Log("mini");
		Value value = new Value ();
		int val = 0;
		int childValue = 0;
	
		if (level == 0) {
			for (int i=0; i<move.Length; i++) {
				if (move [i].xNum == 10 && move [i].yNum == 10 && !move [i].Enemy)
					val += move [i].Value;
			}
			return val;
		}
	
		if (flag) {
			val = 0;
		} else {
			val = 10000;
		}

		for (int i = 0; i<move.Length; i++) {
			for (int num = 0; num<10; num++) {
			
				moveKoma[] undo = new moveKoma[30];
				for (int j = 0; j<move.Length; j++) {
					undo [j] = move [j];
				}

				if (move [i].Enemy == flag) {
					komaMove (num, move [i]);
					Shot (flag);
					value.kNum = move [i].kNum;
					value.mNum = num;
				}

				if(move != undo){
					childValue = minimax (!flag, level - 1);
				}

				if (flag) {
					if (childValue > val) {
						val = childValue;
					}
				} else {
					if (childValue < val) {
						val = childValue;
					}
				}

				for (int k= 0; k<move.Length; k++) {
					move [k] = undo [k];
				}

			}
		}
		if (level == SEARCH_LEVEL) {
			return value.mNum + value.kNum * 10;
		} else {
			return val;
		}
	}

	void realMove(int val){
		moveKoma p = new moveKoma(); 

		GameObject[] kks = GameObject.FindObjectsOfType (typeof(GameObject)) as GameObject[];
		foreach (GameObject kk in kks) {
			if (kk.tag == "Koma") {
				Koma koma = kk.GetComponent<Koma> ();
				if (koma.kNum == val/10) {
					p.xNum = koma.xNum;
					p.yNum = koma.yNum;

					//move
					if(val%10 < 8){
						p.moving(val%10);

						GameObject[] cs = GameObject.FindObjectsOfType (typeof(GameObject)) as GameObject[];
						foreach (GameObject cc in cs) {
							if (cc.name == "CubePrefab(Clone)") {
								Cube C = cc.GetComponent<Cube> ();
								if(C.xNum == p.xNum && C.yNum == p.yNum){

									if(!C.CollisionStay){
										koma.transform.position = C.pos;
									}else{

										GameObject[] kss = GameObject.FindObjectsOfType (typeof(GameObject)) as GameObject[];
										foreach (GameObject ks in kss) {
											if (ks.tag == "Koma") {
												Koma komas = ks.GetComponent<Koma> ();
												if(komas.xNum == p.xNum && komas.yNum == p.yNum){
													komas.transform.position = koma.transform.position;
													koma.transform.position = C.pos;
												}
											}
										}
									}
								}
							}
						}

					}else if(val%10 == 8){
//						p.spin(true);
						koma.transform.Rotate (new Vector3 (0, 90f, 0));
					}else if(val%10 == 9){
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


