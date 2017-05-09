using UnityEngine;
using System.Collections;

public class NewBehaviourScript1 : MonoBehaviour {
		int i=0;
		int inc = 1;
		public Transform[] targets;
		public float speed;
		public GameObject player;
		void Update() {
				player = GameObject.Find("cube");
				camera_control cc = player.GetComponent<camera_control>();
				float dist = Vector3.Distance(player.transform.position, transform.position);
				//print("Distance to other: " + dist);
				if (dist <= 50) {
						color.t+=0.005f;
				}
				else if (dist > 50) {
						color.t-=0.05f;
				}
				
				if (i == targets.Length - 1) {
						inc = -1;
				}
				if (i == 0) {
						inc = 1;
						
				}
				float step = speed * Time.deltaTime;
				Vector3 targetDir = targets[i].position - transform.position;
				float step2 = speed * Time.deltaTime;
				Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, step2, 0.0F);
				newDir.y = 0;
				transform.rotation = Quaternion.LookRotation(newDir);
				transform.position = Vector3.MoveTowards(transform.position, targets[i].position, step);
				if (transform.position == targets [i].position || Vector3.Distance(targets[i].position, transform.position)<=1.0f) {
						i += inc;
				}
		}
}
