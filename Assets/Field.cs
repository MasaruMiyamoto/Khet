﻿using UnityEngine;
using System.Collections;

public class Field : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerExit(Collider collider){
		Destroy (collider.gameObject);
	}
}
