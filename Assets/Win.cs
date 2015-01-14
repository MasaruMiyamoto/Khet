using UnityEngine;
using System.Collections;

public class Win : MonoBehaviour {
	public GameObject pre;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter (Collider collider)
	{
		if (collider.gameObject.tag == "Laser") {
			Destroy(collider.gameObject);

			GameObject[] kk = GameObject.FindGameObjectsWithTag("Koma");
			GameObject[] cc = GameObject.FindGameObjectsWithTag("Cube");

			foreach(GameObject kks in kk){
				Destroy(kks);
			}

			foreach(GameObject ccs in cc){
				Destroy(ccs);
			}

			GameObject[] ee = GameObject.FindGameObjectsWithTag("Enemy");
			
			foreach(GameObject ees in ee){
				Destroy(ees);
			}

			GameObject[] aa = GameObject.FindGameObjectsWithTag("Ally");
			
			foreach(GameObject aas in aa){
				Destroy(aas);
			}

			MyGUI set = GameObject.Find ("GUI").GetComponent<MyGUI> ();
			set.flag++;

			if(pre.GetComponent<Koma>().Enemy){
				set.win = false;
			}else{
				set.win = true;
			}

		}
	}

}
