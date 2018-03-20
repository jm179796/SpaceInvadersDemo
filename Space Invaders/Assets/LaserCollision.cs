using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserCollision : MonoBehaviour {
    /// <summary>
    /// The explosion prefab that will be used
    /// </summary>
    public GameObject Explosion;


	// Use this for initialization
	void Start ()
    {
        gameObject.transform.LookAt(Camera.main.transform); // Rotates the ship so that it faces the camera
	}

	private void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Ship") // Checks whether the object being collided with has the ship tag
        {
            ShipManager.Instance.ShipList.Remove(col.gameObject); //Removes the ship form the ship list in the ship manager
            Destroy(col.gameObject); //Destroys the ship object
            var Expl = Instantiate(Explosion, col.transform.position, Quaternion.identity); //Spawns an explosion prefab at the point of collision
            Destroy(Expl, 1.5f); //Destroys the explosion after 1.5 seconds
            Destroy(gameObject); // Destroys the laser object
        }
    }
}
