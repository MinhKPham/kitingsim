using UnityEngine;
using System.Collections;

public class camera_control : MonoBehaviour {
	float speed;
	int Boundary;
	Vector3 tempPos;


	// Use this for initialization
	void Start () {
		Screen.showCursor = true;
		speed = 22f;
		Boundary = 50;
		tempPos = transform.position;


	}
	
	// Update is called once per frame
	void Update()
	{                             
		if (Input.mousePosition.x > Screen.width - Boundary)
		{
			 // move on +X axis
			tempPos.x += speed * Time.deltaTime;
			transform.position=tempPos;
		}
		
		if (Input.mousePosition.x < 0 + Boundary)
		{

			tempPos.x -= speed * Time.deltaTime;
			transform.position=tempPos;
		}
		
		if (Input.mousePosition.y > Screen.height - Boundary)
		{
			tempPos.z += speed * Time.deltaTime; // move on +Z axis
			transform.position=tempPos;
		}
		
		if (Input.mousePosition.y < 0 + Boundary)
		{
			tempPos.z -= speed * Time.deltaTime; // move on -Z axis
			transform.position=tempPos;
		}
		
	} 
}
