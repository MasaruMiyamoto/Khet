using UnityEngine;
using System.Collections;

public class Shot : MonoBehaviour
{

	// Use this for initialization
	void Start ()
	{
	}
	
	// Update is called once per frame
	void Update ()
	{
		transform.Translate (0, 0, 0.2f);
		Destroy (gameObject, 5.0f);
	}

	void OnCollisionEnter (Collision collision)
	{
		Debug.Log ("OK");
		if (collision.gameObject.tag == "Mirror") {
			Debug.Log ("mirror");
//			transform.Rotate (new Vector3 (0, 0, 180f));
			Destroy (gameObject, 2.0f);
		}
//		Destroy(gameObject);
	}
}
