using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class camera_control : MonoBehaviour {
		public float speedH = 4.0f;
		public float speedV = 4.0f;
		public float sp=0.1f;
		private float yaw = 0.0f;
		private float pitch = 0.0f;
		public Object t;
		private int i = 0;
		public Vector3 tf;
		public string[] mis;
		public Text text;
		void Start(){
				for (int i = 0; i < mis.Length; i++) {
						mis [i] = "\n" + mis [i] + "\n";
				}
		}
		void Update () {
				

				text.text = "";
				for (int i = 0; i < mis.Length; i++) {
						text.text+=mis [i];
				}
				tf = transform.position;
				Screen.lockCursor = true;
				float spawnDistance = 10;

				Vector3 spawnPos = transform.position + transform.forward*spawnDistance;
				i++;

				yaw += speedH * Input.GetAxis("Mouse X");
				pitch -= speedV * Input.GetAxis("Mouse Y");
				if (pitch <= -90) {
						pitch = -90;
				}
				if (pitch >= 90) {
						pitch = 90;
				}


				transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
				transform.Translate(Vector3.forward * 0.0f);
		}

}
