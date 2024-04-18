// Obstacles.cs
// 
// Penguin Dash
// Copyrights @ 2014-2015 Bachir Bouchemla

using UnityEngine;
using System.Collections;

public class ObstaclesDestroyer : MonoBehaviour 
{
    // Variables
    public bool longDestroyer;
    public bool regDestroyer;

    public GameObject regDes;
    public GameObject longDes;

	// Collision is called by hit.
	void OnCollisionEnter2D(Collision2D col)
	{
        // Long Destroyer
        if (longDestroyer)
        {
            if (col.gameObject.tag == "LongEnemy")
            {
                DestroyObject(col.gameObject);
            }
            if (col.gameObject.tag == "NotEnemy")
            {
                DestroyObject(col.gameObject);
            }
            if (col.gameObject.tag == "EnemyB")
            {
                DestroyObject(col.gameObject);
            }
            if (col.gameObject.tag == "EnemyS")
            {
                DestroyObject(col.gameObject);
            }
            if (col.gameObject.tag == "WoodenSign")
            {
                DestroyObject(col.gameObject);
            }
            if (col.gameObject.tag == "Tunnel")
            {
                DestroyObject(col.gameObject);
            }
        }

        // Regular Destroyer
        if (regDestroyer)
        {
            if (col.gameObject.tag == "EnemyB")
            {
                DestroyObject(col.gameObject);
            }
            if (col.gameObject.tag == "EnemyS")
            {
                DestroyObject(col.gameObject);
            }
            if (col.gameObject.tag == "WoodenSign")
            {
                DestroyObject(col.gameObject);
            }
            if (col.gameObject.tag == "Tunnel")
            {
                DestroyObject(col.gameObject);
            }
        }
	}

	// Update is called once per frame
	void Update () 
	{
		longDes.transform.position = new Vector2(-75f, 20f);
        regDes.transform.position = new Vector2(-15f, 20f);
    }
}
