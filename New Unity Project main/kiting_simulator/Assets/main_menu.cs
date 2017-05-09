using UnityEngine;
using System.Collections;

public class main_menu : MonoBehaviour {

	// Use this for initialization
	public Texture gameOverTexture;
	public GUISkin myGUISkin;
	
	// Use this for initialization
	void Start () {
		Screen.showCursor = true;
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnGUI()
	{	GUI.skin = myGUISkin;
		
		
		GUI.DrawTexture(new Rect(0,0,Screen.width,Screen.height),gameOverTexture);
		if (GUI.Button(new Rect(Screen.width / 2, Screen.height /2, 150, 25),"Start")) 
		{
			Application.LoadLevel("gameplay");
		}
		if (GUI.Button(new Rect(Screen.width / 2, Screen.height /2 + 25, 150, 25),"Instruction")) 
		{
			Application.LoadLevel("instruction");
		}
		if (GUI.Button(new Rect(Screen.width / 2, Screen.height /2 + 50, 150, 25),"Quit")) 
		{

			Application.Quit();
		}

	}
}
