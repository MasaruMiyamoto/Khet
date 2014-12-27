
using UnityEngine;
using System.Collections;

public class Cube : MonoBehaviour
{
	
	public int xNum;
	public int yNum;
	public Vector3 pos;
	public bool CollisionStay = false;
	public bool ScarabFlag = false;
	// Use this for initialization
	void Start ()
	{
		renderer.material.color = Color.gray;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(this.tag == "Enemy" && !GameObject.Find("SELECT").GetComponent<Select> ().Enemy){
			renderer.material.color = Color.gray;
		}else if(this.tag == "Ally" && GameObject.Find("SELECT").GetComponent<Select> ().Enemy){
			renderer.material.color = Color.gray;
		}

	}

	void OnCollisionEnter (Collision collision)
	{
		CollisionStay = true;
//		Debug.Log(collision.gameObject.GetComponent<Koma>());
		if(collision.gameObject.GetComponent<Koma>().name == "ScarabPrefab(Clone)" || collision.gameObject.GetComponent<Koma>().name == "SphinxPrefab(Clone)"){
			ScarabFlag = true;
		}
	}

	void OnCollisionExit (Collision collision)
	{
		CollisionStay = false;
		ScarabFlag = false;
	}
}