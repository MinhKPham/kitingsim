using UnityEngine;
using System.Collections;

public class restart : MonoBehaviour {

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
		
		
		
		if (GUI.Button(new Rect(Screen.width / 2, Screen.height /2, 150, 25),"Main Menu")) 
		{
			Application.LoadLevel("main menu");
		}
		
		
	}
}
