using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class color : MonoBehaviour {
		public static float t=0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
				
				Image img = gameObject.GetComponent<Image>();

				Color c = img.color;
				if (t <= 0) {t = 0;
				}
				if (t >= 1) {t = 1;
				}
				c.a = t;

				img.color = c;


	
	}
	
}
