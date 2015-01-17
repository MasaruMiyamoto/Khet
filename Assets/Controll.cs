using UnityEngine;
using System.Collections;

public class Controll : MonoBehaviour
{

	public bool Turn;
	public bool Move;
	// Use this for initialization
	void Start ()
	{
		//will be random
		Turn = false;
		Move = false;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Move) {
			Controll con = GameObject.Find ("ControllPlayer").GetComponent<Controll> ();
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
			Move = false;
		}
	}
}
