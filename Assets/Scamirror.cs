﻿using UnityEngine;
using System.Collections;

public class Scamirror : MonoBehaviour
{
	float me;
	float you;
	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (!gameObject.transform.parent.gameObject.renderer.enabled) {
			//			Debug.Log("enable");
			renderer.enabled = false;
		}
	}

	void OnTriggerEnter (Collider collider)
	{
		GameObject obj;
		obj = collider.gameObject;
		if (obj.tag == "Laser") {
			//						obj.GetComponent<Shot> ().Speed = 0;
			GameObject parent = transform.parent.gameObject;

//			float x1,x2,y1,y2;
//			x1 = obj.transform.position.x + 0.05f;
//			x2 = parent.transform.position.x + 0.05f;
//			y1 = obj.transform.position.z + 0.05f;
//			y2 = parent.transform.position.z+0.05f;
//			
//			if (x1.ToString("N2") == x2.ToString("N2") && y1.ToString("N2") == y2.ToString("N2")) {

				me = (int)parent.transform.eulerAngles.y;
				if (me == 89 || me == 179 || me == 269)
					me += 1;
				if (me == 359)
					me = 0;
				
				you = (int)obj.transform.eulerAngles.y;
//									Debug.Log (me);
//									Debug.Log (you);
				//			Debug.Log (obj.transform.eulerAngles);

				if (me - you == 0) {
//				Debug.Log ("1");
					obj.transform.Rotate (0, 90f, 0);
				} else if (me - you == 90) {
//				Debug.Log ("2");
					obj.transform.Rotate (0, -90f, 0);
				} else if (me - you == -90) {
//				Debug.Log ("3");
					obj.transform.Rotate (0, -90f, 0);
				} else if (me - you == 180) {
//				Debug.Log ("4");
					obj.transform.Rotate (0, 90f, 0);
				} else if (me - you == -180) {
//				Debug.Log ("5");
					obj.transform.Rotate (0, 90f, 0);
				} else if (me - you == 270) {
//				Debug.Log ("6");
					obj.transform.Rotate (0, -90f, 0);
				} else if (me - you == -270) {
//				Debug.Log ("7");
					obj.transform.Rotate (0, -90f, 0);
				}

//				obj.transform.position = new Vector3(x1,0.25f,y1);

//			}
		}
	}
}
