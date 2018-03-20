using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveShip : MonoBehaviour {
    /// <summary>
    /// The ship object
    /// </summary>
    public GameObject Ship;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Move();
	}

    private void Move()
    {
        Ship.transform.Translate(new Vector3(0,0,-0.001f)); // Translates the position of the object in the direction of the vector that is specified
    }
}
