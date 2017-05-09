using UnityEngine;
using System.Collections;

public class adjust : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
				RaycastHit hit;
				Vector3 forward = transform.TransformDirection (Vector3.forward);
				if (Physics.Raycast (transform.position, forward, out hit, 100)) {
						
				}
	}
}
