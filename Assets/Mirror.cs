using UnityEngine;
using System.Collections;

public class Mirror : MonoBehaviour
{
//		public GameObject Laser;
//		Vector3 stay;
	float me;
	float you;
	// Use this for initialization
	void Start ()
	{
//				stay.x = transform.rotation.x;
//				stay.y = transform.rotation.y;
//				stay.z = transform.rotation.z;

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
//						GameObject laser = Instantiate (Laser, parent.transform.position, transform.rotation) as GameObject;
//						Destroy (obj);
			me = (int)parent.transform.eulerAngles.y;
			if (me == 89 || me == 179 || me == 269 || me == 359)
				me += 1;

			you = (int)obj.transform.eulerAngles.y;
//						Debug.Log (me);
//						Debug.Log (you);
//			Debug.Log (obj.transform.eulerAngles);
//						if (Mathf.Abs(me - you) != 0 && Mathf.Abs (me - you) != 180) {
////								obj.transform.LookAt (Vector3.zero);
//								if (me < 180)
//										obj.transform.Rotate (0, -me, 0);
//								else
//										obj.transform.Rotate (0, me, 0);
//						} else{
//				Debug.Log ("OK");
//								if (me < 180)
//										obj.transform.Rotate (0, -90f, 0);
//								else
//										obj.transform.Rotate (0, 90f, 0);
//						}

			if (me - you == 0) {
//				Debug.Log ("1");
				obj.transform.Rotate (0, -90f, 0);
			} else if (me - you == 180) {
//				Debug.Log ("2");
				obj.transform.Rotate (0, 90f, 0);
			} else if (me - you == -180) {
//				Debug.Log ("3");
				obj.transform.Rotate (0, 90f, 0);
			} else {
//				Debug.Log ("4");
				obj.transform.Rotate (0, -90f, 0);
			}
		}
	}
}
