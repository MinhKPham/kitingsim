using UnityEngine;
using System.Collections;

public class healthbar : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GetComponent<Renderer>().material.color = Color.red;
		Cursor.visible = true;
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.localScale=new Vector3(0.46f * clicktomove.hea, -0.02f, 0.08f);
	
	}
}
