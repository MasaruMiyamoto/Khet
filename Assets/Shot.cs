using UnityEngine;
using System.Collections;

public class Shot : MonoBehaviour
{
		public float Speed;
		// Use this for initialization
		void Start ()
		{
				Speed = 0.05f;
		}
	
		// Update is called once per frame
		void Update ()
		{
				transform.Translate (0, 0, Speed);
//				Destroy (gameObject, 5.0f);
		}

		void OnTriggerEnter (Collider collider)
		{
		if (collider.gameObject.tag == "Mirror") {
			
//			Debug.Log (collider.gameObject.transform.localRotation);
//			Debug.Log ("mirror");
//			transform.Rotate (new Vector3 (0, -90f, 0));
//			Destroy (gameObject);
		}
//		Destroy(gameObject);
		}
}
