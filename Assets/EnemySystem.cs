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
		case 1:
			if (yNum > 0) {
				yNum -= 1;
			}
			break;
		case 2:
			if (xNum < 9 && yNum > 0) {
				xNum += 1;
				yNum -= 1;
			}
			break;
		case 3:
			if (xNum < 9) {
				xNum += 1;
			}
			break;
		case 4:
			if (xNum < 9 && yNum < 9) {
				xNum += 1;
				yNum += 1;
			}
			break;
		case 5:
			if (yNum < 9) {
				yNum += 1;
			}
			break;
		case 6:
			if (xNum > 0 && yNum < 9) {
				xNum -= 1;
				yNum += 1;
			}
			break;
		case 7:
			if (xNum > 0) {
				xNum -= 1;
			}
			break;
		case 8:
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
		if (right) {
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
			angle = 3;
		} else {
			x = 9;
			y = 0;
			angle = 1;
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
	int x;
	moveKoma[] move;
	// Use this for initialization
	void Start ()
	{
		x = 1;
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
				Shot (true);
//				move [2].moving (3);
			}


			//Moving gameObject
			if (x == 2) {

				GameObject[] css = GameObject.FindObjectsOfType (typeof(GameObject)) as GameObject[];
				foreach (GameObject cc in css) {
					if (cc.tag == "Koma") {
						Koma koma = cc.GetComponent<Koma> ();
						if (koma.kNum == move [2].kNum) {
//							Debug.Log (koma.xNum);
							koma.xNum = move [2].xNum;
							koma.yNum = move [2].yNum;
//							Debug.Log (koma.xNum);
						}
					}
				}
				x++;
			}
		}
	}

	void Shot (bool enemy)
	{
		Laser laser = new Laser (enemy);

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

	void compute ()
	{
		//minimax
		minimax (true, 2);
		//decision moving

	
	}

	int minimax (bool flag, int level)
	{
		int value;
	
		int childValue;

		int BestkNum = 0;
	
		if (level == 0) {
			return 0;
		}
	
		if(flag){
			value = 0;
		}else{
			value = 1000;
		}


	}

}


