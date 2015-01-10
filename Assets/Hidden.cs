using UnityEngine;
using System.Collections;

public class Hidden : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (!gameObject.transform.parent.gameObject.renderer.enabled) {
			//			Debug.Log("enable");
			renderer.enabled = false;
		}
	}
}
