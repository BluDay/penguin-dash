/// Info.cs
// 
// Penguin Dash
// Copyrights @ 2014-2016 Bachir Bouchemla

using UnityEngine;
using System.Collections;

public class Info : MonoBehaviour 
{

	// Classes.
	public GUITexture infoBtn;
	public GUITexture infoScreen;
	public GUITexture blackrect;
	public GUITexture menu;

	public GameObject buttons;

	// Update is called once per frame
	void Update() 
	{
		// Enabling touch.
		if (Input.touchCount > 0)
		{
			for (int i = 0; i < Input.touchCount; i++)
			{
				Touch t = Input.GetTouch(i);
				if (t.phase == TouchPhase.Began)
				{
					print(i);
				}
			}
		}

		// Touched.
	    if (Input.GetMouseButtonDown(0))
		{
			// Info Button.
            if (infoBtn.HitTest(Input.mousePosition, Camera.main))
			{
				buttons.transform.position = new Vector3(-2f, buttons.transform.position.y, buttons.transform.position.z);
				infoBtn.color = new Color32(80, 80, 80, 128);
				infoScreen.transform.position = new Vector3(0.5f, infoScreen.transform.position.y, infoScreen.transform.position.z);
				blackrect.color = new Color32(0, 0, 0, 60);
			}

			// Menu Button.
			if (menu.HitTest(Input.mousePosition, Camera.main))
			{
				buttons.transform.position = new Vector3(0.5f, buttons.transform.position.y, buttons.transform.position.z);
				infoBtn.color = new Color32(128, 128, 128, 128);
				infoScreen.transform.position = new Vector3(-2f, infoScreen.transform.position.y, infoScreen.transform.position.z);
				blackrect.color = new Color32(0, 0, 0, 0);
			}
		}
	}
}
