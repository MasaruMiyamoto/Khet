using UnityEngine;
using System.Collections;

public class Destroy : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter (Collider collider)
	{
		if (collider.gameObject.tag == "Laser") {
			transform.Translate (0, 0.2f, 0);
			rigidbody.useGravity = false;
			Koma k = gameObject.GetComponent<Koma> ();
			k.xNum = 10;
			k.yNum = 10;
			k.transform.Translate(0,100f,0);
			//						Destroy (pre,0.05f); 
			Destroy (collider.gameObject, 0.05f);
			k.Hidden = true;
		}
		
	}
}
