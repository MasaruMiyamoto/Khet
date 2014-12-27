using UnityEngine;
using System.Collections;

public class ChengeColor : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GameObject parent = gameObject.transform.parent.gameObject;
		Koma k = parent.GetComponent<Koma>();
		if(k.Enemy){
//			Debug.Log("parent");
			renderer.material.color = Color.red;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
