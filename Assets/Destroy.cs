﻿using UnityEngine;
using System.Collections;

public class Destroy : MonoBehaviour {
	public GameObject pre;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter (Collider collider)
	{
		//		Debug.Log ("IN");
		if (collider.gameObject.tag == "Laser") {
			int me = (int)pre.transform.eulerAngles.y;
			int you = (int)collider.gameObject.transform.eulerAngles.y;
//						Debug.Log (me);
//						Debug.Log (you);
			if (me - you == 180 || me - you == -180) {
				Destroy (collider.gameObject);
			} else {
				pre.transform.Translate (0, 0.2f, 0);
				pre.rigidbody.useGravity = false;
//				Koma k = gameObject.GetComponent<Koma> ();
				//				k.xNum = 10;
				//				k.yNum = 10;
				//				k.collider.isTrigger = true;
				//				k.transform.Translate (0, 10f, 0);
				Destroy (pre, 0.05f); 
				Destroy (collider.gameObject, 0.05f);
				//				k.Hidden = true;
			}
		}
	}
}
