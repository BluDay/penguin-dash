/// MenuButtonInput.cs
// 
// Penguin Dash
// Copyrights @ Bachir Bouchemla

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using System.Collections;

public class MenuButtonTouch : MonoBehaviour 
{
	// Classes.
	Animator anim;
	PlayerSettings Player;
	public bool menuClicked;
	public GUITexture menu;
	public GUITexture Blackrect;

	// Use this for initialization
	void Start() 
	{
		Time.timeScale = 1;
		anim = Blackrect.GetComponent<Animator>();
		Player = GetComponent<PlayerSettings>();
	}

	// Animation coroutine.
	IEnumerator Back(float wait)
	{
		menu.color = new Color32(198, 198, 255, 255);
		anim.Play("BlackrectFadeOut");
		yield return new WaitForSeconds(wait);
		Application.LoadLevel(1);
	}

	// Update is called once per frame
	void Update() 
	{
		// If Clicked
	    if (Input.touchCount > 0)
		{
			for (int i = 0; i < Input.touchCount; i++)
			{
				Touch t = Input.GetTouch(i);
				if (t.phase == TouchPhase.Began && t.phase == TouchPhase.Stationary)
				{
                    if (menu.HitTest(t.position, Camera.main))
					{
						// Level 1 Gets Clicked.
						print("Menu Clicked");
					}
				}
			}
		}

		// Input Mouse Down.
		if (Input.GetMouseButtonDown(0))
		{
			if (menu.HitTest(Input.mousePosition, Camera.main))
			{

				if (Application.loadedLevelName == "Level1" || 
				    Application.loadedLevelName == "Level2" || 
				    Application.loadedLevelName == "Level3" || 
				    Application.loadedLevelName == "Level4" || 
				    Application.loadedLevelName == "Level5" || 
				    Application.loadedLevelName == "Level6")
				{
					if(Player.Dead)
					{
						GameObject deathSound = GameObject.Find("One shot audio");
						deathSound.GetComponent<AudioSource>().Pause();
					}
				}

				Time.timeScale = 1;
				menuClicked = true;
				StartCoroutine(Back(0.25f));
			}
		}
		// On Back Key Press.
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			Time.timeScale = 1;
			StartCoroutine(Back(0.25f));
		}
	}	
}
