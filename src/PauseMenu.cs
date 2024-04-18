// PauseMenu.cs
// 
// Penguin Dash
// Copyrights @ 2014-2015 Bachir Bouchemla

using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour 
{

	// Classes.
	Animator anim;
	public bool menuClicked;
	public GUITexture menubtn;
	public GUITexture restartbtn;
	public GUITexture Blackrect;
	public GameObject player;
	public float timer = 0.0f;
	
	// Use this for initialization
	void Start() 
	{
		anim = Blackrect.GetComponent<Animator>();
	}
	
	// Animation coroutine.
	IEnumerator Back(float wait)
	{

		menubtn.color = new Color32(180, 180, 180, 255);
		anim.Play("BlackrectFadeOut");
		yield return new WaitForSeconds(wait);
		SceneManager.LoadScene("MainMenu");
	}
	
	// Update is called once per frame
	void Update() 
	{
		// Timer
		timer += Time.deltaTime;

		// If Clicked
		if (Input.touchCount > 0)
		{
			for (int i = 0; i < Input.touchCount; i++)
			{
				Touch t = Input.GetTouch(i);
				print(t);
			}
		}

		// Input Mouse Down.
		if (Input.GetMouseButtonDown(0))
		{
			// Menu
			if (menubtn.HitTest(Input.mousePosition, Camera.main))
			{
				Time.timeScale = 1;
				menuClicked = true;
				StartCoroutine(Back(0.25f));
			}
			// Restart
			if (restartbtn.HitTest(Input.mousePosition, Camera.main))
			{
				restartbtn.color = new Color32(180, 180, 180, 255);
				Application.LoadLevel(Application.loadedLevel);
			}
		}
	}
}
