using UnityEngine;
using System.Collections;

public class startins : MonoBehaviour {

	// Use this for initialization

	public GUISkin myGUISkin;
	
	// Use this for initialization
	void Start () {
		Cursor.visible = true;
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnGUI()
	{	GUI.skin = myGUISkin;
		
		

		if (GUI.Button(new Rect(Screen.width / 2, Screen.height /2, 150, 25),"Start")) 
		{
			Application.LoadLevel("gameplay");
		}

		
	}
}
