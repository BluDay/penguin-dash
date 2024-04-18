// PlanetsMovement.cs
// 
// Penguin Dash
// Copyrights @ 2014-2015 Bachir Bouchemla

using UnityEngine;
using System.Collections;

public class PlanetsMovement : MonoBehaviour 
{
    // Classes
    public float Movspeed;
    public GameObject player;
    PlayerSettings p;

    // Use this for initialization
    void Start() 
    {
        p = player.GetComponent<PlayerSettings>();
    }


    // Update is called once per frame
    void Update() 
    {
        // Movement speed.
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
