using UnityEngine;
using System.Collections;

public class Select : MonoBehaviour
{
		// Use this for initialization
		public int SelectKomaNum;
		public bool Enemy;
		Controll con;

		void Start ()
		{
				con = GameObject.Find ("ControllPlayer").GetComponent<Controll> ();
		}
	
		// Update is called once per frame
		void Update ()
		{
				//Always useing ray
		
				if (!GameObject.Find ("ControllPlayer").GetComponent<Controll> ().Move) {
						if (Input.GetMouseButtonDown (0)) {
								Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
								RaycastHit hit = new RaycastHit ();
								if (Physics.Raycast (ray, out hit)) {
										GameObject obj = hit.collider.gameObject;
										if (obj.tag == "Koma") {
												Koma k = obj.GetComponent<Koma> ();
												if (SelectKomaNum == 0 && con.Turn == k.Enemy) {
														SelectKomaNum = k.kNum;
														Enemy = k.Enemy;
												}
										}
								}
						}

						if (Input.GetMouseButtonDown (1)) {
			
								Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
								RaycastHit hit = new RaycastHit ();
								if (Physics.Raycast (ray, out hit)) {
										GameObject obj = hit.collider.gameObject;
										if (obj.tag == "Koma") {
												Koma k = obj.GetComponent<Koma> ();
												if (SelectKomaNum == 0 && con.Turn == k.Enemy) {
														SelectKomaNum = k.kNum;
												}
										}
								}
						}
				}
		}


}
