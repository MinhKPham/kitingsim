using UnityEngine;
using System.Collections;

public class getrekt : MonoBehaviour {
	bool rekt;
	public int health;
	float  t;
	bool getshot;
	bool extra;

	GameObject[] list;
	public GameObject thecube;
	private Color originalColor;
	float speed;
	float timehit;
	// Use this for initialization
	void Start () {
		Screen.showCursor = true;
		bool extra = false;
		speed = 6f;
		timehit = 1;
		originalColor = renderer.material.color;

		list=GameObject.FindGameObjectsWithTag ("main");
		thecube = list [0];
	}
	void OnMouseEnter() {
		renderer.material.color = Color.red;
	}
	void OnMouseExit()
	{
		renderer.material.color = originalColor;
	}

	// Update is called once per frame

	void Update () {
		t=clicktomove.t1;
		Debug.Log (t);
		timehit += Time.deltaTime;
		if (clicktomove.kill >= 5 && extra==false) {
			speed+=3.5f;
			extra=true;
			originalColor=Color.grey;
		}

		if (t>0.3f && t<0.9f){
			
			
			renderer.material.color = originalColor;
			
		}




		if (health == 0) {

			if (t>0.2){
				clicktomove.kill+=1;
				Destroy (gameObject);
			}


		}



		if (Input.GetMouseButton (1)) {
			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			if (Physics.Raycast (ray, out hit, 1000)) {
				if (hit.transform == transform) {

					rekt = true;
				
				}
				if (hit.transform != transform) {

					rekt = false;
				}
			
			
				}
	
		}
		if (thecube == null) {
			return;
		}
		if (thecube != null) {
			transform.LookAt (thecube.transform);
		}
		if (Vector3.Distance (transform.position, thecube.transform.position) >= 2.3f) {
			transform.position = new Vector3 (transform.position.x, 2f, transform.position.z);

			transform.position += transform.forward*speed*Time.deltaTime;
			transform.position = new Vector3 (transform.position.x, 2f, transform.position.z);
		}
		if (Vector3.Distance (transform.position, thecube.transform.position) < 3f && timehit>=1f) {
			Debug.Log ("get hit");
			clicktomove.hea-=1;
			timehit=0;
		}
		if (Vector3.Distance (transform.position, thecube.transform.position) <= 16f && rekt == true) {
			getshot=true;


		}
		else if (rekt==false || Vector3.Distance (transform.position, thecube.transform.position) > 16f){
			getshot=false;
		}
		if (getshot == true) {


			if (clicktomove.t1>=1f){

				health-=1;
				speed+=1f;
				renderer.material.color = originalColor;
				clicktomove.t1=0;
			}

			if (clicktomove.t1<0.3f){
				

				renderer.material.color = Color.blue;

			}


		}

	}
}
