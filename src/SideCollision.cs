using UnityEngine;
using System.Collections;

public class SideCollision : MonoBehaviour 
{
	// Classes
	public GameObject player;
    public float rotationDegree;
	
	// Update is called once per frame
	void OnCollisionEnter2D(Collision2D col) 
	{
        // Player detection.
        player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
		player.transform.eulerAngles = new Vector3(player.transform.eulerAngles.x, 
            player.transform.eulerAngles.y, rotationDegree);
	}
}
