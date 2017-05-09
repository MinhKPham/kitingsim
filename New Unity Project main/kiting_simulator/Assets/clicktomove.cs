using UnityEngine;
using System.Collections;

public class clicktomove : MonoBehaviour
{
	public static int kill;
	public float speed;
	float temspeed;
	public CharacterController controller;
	static public float t1;
	GameObject thingtofollow;
	bool w;
	[SerializeField] private ParticleSystem effect;
	[SerializeField] private ParticleSystem effect2;
	public static int hea;

	
	private Vector3 position;
	
	// Use this for initialization
	void Start ()
	{
		Screen.showCursor = true;
		kill = 0;
		t1 = 3;
		hea = 4;
		temspeed = speed;
		position = transform.position;
	}

	
	// Update is called once per frame
	void Update ()
	{

		t1 += Time.deltaTime;
		if (kill >= 7) {
			Application.LoadLevel("win");
		}
		if (hea <= 0) {
			Application.LoadLevel("game over");
			Debug.Log ("dead");

			Destroy (gameObject);
		}
		if (Input.GetMouseButton (1)) {
			speed=temspeed;

			locatePosition();
			locatethings();
			RaycastHit hit2;
			Ray ray2 = Camera.main.ScreenPointToRay (Input.mousePosition);
			if(Physics.Raycast(ray2, out hit2, 100, LayerMask.NameToLayer("Terrain")) && w==false)
			{
				effect.transform.position = hit2.point;
				effect.Play();
			}
		}
		if (w == true) {
			if (thingtofollow==null){
				position = transform.position;
			}


		}



		moveToPosition ();
	}
	void locatethings()
	{
		RaycastHit hit;
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);

		if (Physics.Raycast (ray, out hit, 1000)) 
		{
			if (hit.transform.gameObject.tag == "w"){

				thingtofollow=hit.transform.gameObject;
				position=thingtofollow.transform.position;
				w=true;

			}
			

		}
		
		
	}
	void locatePosition()
	{
		RaycastHit hit;
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		if (Physics.Raycast (ray, out hit, 1000)) 
		{


			position=new Vector3(hit.point.x, hit.point.y, hit.point.z);
			Debug.Log(position);
			w=false;
		}

		
	}
	void moveToPosition()
	{

		if (w == false) {
			if (Vector3.Distance (transform.position, position) < 1.5f) {
				return;
			}
			else  
			{
				
				Quaternion newRotation = Quaternion.LookRotation (position - transform.position, Vector3.forward);
				newRotation.x = 0f;
				newRotation.z = 0f;
				
				
				//transform.forward=(position-transform.position).normalized;
				
				
				transform.rotation = Quaternion.Slerp (transform.rotation, newRotation, Time.deltaTime*20);
				//transform.rotation = Quaternion.Euler(newRotation.z,newRotation.y*114,newRotation.x);
				controller.SimpleMove (transform.forward*speed);
				
				//transform.Translate(Vector3.forward*speed);
				
			}
		}
		if (w == true) {
			if (Vector3.Distance (transform.position, position) <= 16f) {
				Quaternion newRotation = Quaternion.LookRotation (position - transform.position, Vector3.forward);
				newRotation.x = 0f;
				newRotation.z = 0f;

				
				
				//transform.forward=(position-transform.position).normalized;
				
				
				transform.rotation = Quaternion.Slerp (transform.rotation, newRotation, Time.deltaTime*20);
				if (t1>=0f && t1<=0.4f && thingtofollow!=null){

					Instantiate(effect2,transform.position+(transform.forward*2), transform.rotation);
				}
				//Instantiate(effect2,transform.position+(transform.forward*2), transform.rotation);

				return;
			}
			else  
			{
				
				Quaternion newRotation = Quaternion.LookRotation (position - transform.position, Vector3.forward);
				newRotation.x = 0f;
				newRotation.z = 0f;
				
				
				//transform.forward=(position-transform.position).normalized;
				
				
				transform.rotation = Quaternion.Slerp (transform.rotation, newRotation, Time.deltaTime*20);
				//transform.rotation = Quaternion.Euler(newRotation.z,newRotation.y*114,newRotation.x);
				controller.SimpleMove (transform.forward*speed);
				
				//transform.Translate(Vector3.forward*speed);
				
			}
		}

	}

}