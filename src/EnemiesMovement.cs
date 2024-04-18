// EnemiesMovement.cs
// 
// Penguin Dash
// Copyrights @ 2014-2015 Bachir Bouchemla

using UnityEngine;
using System.Collections;

public class EnemiesMovement : MonoBehaviour 
{
    // Classes
	public float Movspeed;
	public float timer = 0.0f;
	public GameObject player;
	public GameObject Enemies1;
	public GameObject Enemies2;
	PlayerSettings p;

	// Use this for initialization
	void Start() 
	{
		p = player.GetComponent<PlayerSettings>();
		Enemies2.SetActive(false);
	}

	// Update is called once per frame
	void FixedUpdate() 
	{

		// Timer
		timer += Time.deltaTime;
		if (Application.loadedLevelName == "Level1" || Application.loadedLevelName == "Level2")
		{
			if (timer >= 46.75f)
			{
				Destroy(Enemies1);
				Enemies2.SetActive(true);
			}
		}
		if (Application.loadedLevelName == "Level3")
		{
			if (timer >= 41.75f)
			{
				Destroy(Enemies1);
				Enemies2.SetActive(true);
			}
		}
		if (Application.loadedLevelName == "Level4")
		{
			if (timer >= 58f)
			{
				Destroy(Enemies1);
				Enemies2.SetActive(true);
			}
		}
		if (Application.loadedLevelName == "Level5")
		{
			if (timer >= 40.5f)
			{
				Destroy(Enemies1);
				Enemies2.SetActive(true);
			}
		}
        if (Application.loadedLevelName == "Level6")
        {
            if (timer >= 40.5f)
            {
                Destroy(Enemies1);
                Enemies2.SetActive(true);
            }
        }


        // Enemies Movment Speed.
        if (p.Dead == false)
		{
			transform.Translate(Vector2.right * Movspeed * Time.deltaTime);
		}
		if (p.Dead == true)
		{
			Movspeed = 0;
		}
		if (p.End == true)
		{
			Movspeed = 0;
		}
	}
}
