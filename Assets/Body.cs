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

		}

		void OnTriggerEnter (Collider collider)
		{
				if (collider.gameObject.tag == "Laser") {
//						pre.transform.Translate (0, 0.2f, 0);
//						pre.rigidbody.useGravity = false;
						
						Destroy (pre); 
						Destroy (collider.gameObject);
				}

		}
}
