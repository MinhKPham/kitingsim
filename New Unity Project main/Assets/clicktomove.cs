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
	bool turn;
	[SerializeField] private ParticleSystem effect;
	[SerializeField] private ParticleSystem effect2;
	public static int hea;

		int d;
	private Vector3 position;
	
	// Use this for initialization
	void Start ()
	{
		Cursor.visible = true;
		kill = 0;
		t1 = 3;
		hea = 4;
		turn = false;
		temspeed = speed;
		position = transform.position;
				d = 0;
	}

	
	// Update is called once per frame
	void Update ()
	{

		t1 += Time.deltaTime;
		if (kill >= 6) {
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
			//Debug.Log(position);
			w=false;
		}

		
	}
	void moveToPosition()
	{

		if (w == false) {
			if (Vector3.Distance (transform.position, position) < 1.5f) {
								d =0;
				return;
				
			}
			else  
			{
				
				
				
				
				
				
								transform.LookAt (position);
								transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0);

								//transform.rotation = Quaternion.Slerp (transform.rotation, newRotation, Time.deltaTime*20);
								//transform.Rotate(new Vector3(newRotation.z,newRotation.x,newRotation.y-transform.rotation.y));
				//if (transform.rotation == newRotation) {
								controller.SimpleMove (transform.forward * speed);
										 
					
				
				
			}
		}
		if (w == true) {
			if (Vector3.Distance (transform.position, position) <= 16f) {
								transform.LookAt (position);
								transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0);
								//transform.rotation = Quaternion.Slerp (transform.rotation, newRotation, Time.deltaTime*20);
								//transform.Rotate(new Vector3(newRotation.z,newRotation.x,newRotation.y-transform.rotation.y));
								//if (transform.rotation == newRotation) {
								//controller.SimpleMove (transform.forward * speed);

				if (t1>=0f && t1<=0.4f && thingtofollow!=null){

					Instantiate(effect2,transform.position+(transform.forward*2), transform.rotation);
				}
				//Instantiate(effect2,transform.position+(transform.forward*2), transform.rotation);

				return;
			}
			else  
			{
				
								transform.LookAt (position);
								transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0);
								//transform.rotation = Quaternion.Slerp (transform.rotation, newRotation, Time.deltaTime*20);
								//transform.Rotate(new Vector3(newRotation.z,newRotation.x,newRotation.y-transform.rotation.y));
								//if (transform.rotation == newRotation) {
								controller.SimpleMove (transform.forward * speed);

				
				//transform.Translate(Vector3.forward*speed);
				
			}
		}

	}

}