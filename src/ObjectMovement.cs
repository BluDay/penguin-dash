// EnemiesMovement.cs
// 
// Penguin Dash
// Copyrights @ 2014-2015 Bachir Bouchemla

using UnityEngine;
using System.Collections;

public class ObjectMovement : MonoBehaviour 
{
    // Classes
	public float Movspeed;
	public float timer = 0.0f;
    public GameObject player;
    //public GameObject[] enviroment;
    PlayerSettings p;

	// Use this for initialization
	void Start() 
	{
		p = player.GetComponent<PlayerSettings>();
	}

	// Update is called once per frame
	void FixedUpdate() 
	{
        // Enemies Movment Speed.
        if (p.Dead == false)
		{
            transform.Translate(Vector2.right * Movspeed * Time.deltaTime);
            //enviroment[0].transform.position = new Vector3(transform.position.x,
                                                           //enviroment[0].transform.position.y,
                                                           //enviroment[0].transform.position.z);
            //enviroment[1].transform.position = new Vector3(transform.position.x,
                                                          // enviroment[1].transform.position.y,
                                                           //enviroment[1].transform.position.z);
            player.transform.position = new Vector3(transform.position.x + -3.7f,
                                                    player.transform.position.y,
                                                    player.transform.position.z);

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
