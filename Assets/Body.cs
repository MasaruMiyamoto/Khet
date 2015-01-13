using UnityEngine;
using System.Collections;

public class Body : MonoBehaviour
{
	public GameObject pre;
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
//		Debug.Log ("IN");
		if (collider.gameObject.tag == "Laser") {
			pre.transform.Translate (0, 0.2f, 0);
			pre.rigidbody.useGravity = false;
			Koma k = pre.gameObject.GetComponent<Koma> ();
//			k.xNum = 10;
//			k.yNum = 10;
//			k.collider.isTrigger = true;
//			k.transform.Translate(0,10f,0);
			Destroy (pre, 0.05f); 
			Destroy (collider.gameObject, 0.05f);
			k.Hidden = true;
		}

	}
}
