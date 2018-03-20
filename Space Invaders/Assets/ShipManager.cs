using Academy.HoloToolkit.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipManager : Singleton<ShipManager>
{
    /// <summary>
    /// The ship object
    /// </summary>
    public GameObject Ship;
    /// <summary>
    /// The list of ship objects that are currently active
    /// </summary>
    public List<GameObject> ShipList = new List<GameObject>();
    /// <summary>
    /// The maxiumum amount  of ships that can be present 
    /// </summary>
    private int MaxShips = 15;
    /// <summary>
    /// The speed that the ships will move
    /// </summary>
    public float speed;
    /// <summary>
    /// The GAME OVER message
    /// </summary>
    public GameObject gameOver;
    /// <summary>
    /// A boolean signifying whether the game has ended or not
    /// </summary>
    private bool GamePlaying = true;

    private void Start()
    {
        gameOver.GetComponent<Renderer>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (GamePlaying == true)
        {
            SpawnShip();
            UpdatePositions();
        }
    }
    /// <summary>
    /// Spawns a ship object
    /// </summary>
    private void SpawnShip()
    {
        if (ShipList.Count < MaxShips)
        {
            GameObject activeShip = Instantiate(Ship, new Vector3(randNeg(Random.Range(2f, 4f)), Random.Range(1f, 4f), randNeg(Random.Range(2f, 4f))), Quaternion.identity); //Spawns a ship object at random coordinates in the given range
            ShipList.Add(activeShip); // Adds the ship object to active list
        }
    }

    /// <summary>
	/// Randomly inverts an inputted number
	/// </summary>
	/// <returns>
	/// The inputted number which may or may not have been inverted
	/// </returns>
	/// <param name="number">
	/// The number to be inverted
	/// </param>
	private float randNeg(float number)
    {
        int neg = Random.Range(0, 2);
        if (neg == 1)
        {
            number = number * -1;
        }

        return number;
    }

    /// <summary>
    /// Updates the positions of the ships 
    /// </summary>
    private void UpdatePositions()
    {
        foreach (GameObject Ship in ShipList)
        {
            Ship.transform.LookAt(Camera.main.transform); // Rotates the ship so that it looks at the camera
            float step = speed * Time.deltaTime; // Calculates the step at which the ship will move
            Ship.transform.position = Vector3.MoveTowards(Ship.transform.position, Camera.main.transform.position, step); // Moves the ship towards the camera 


            if (Ship.transform.position == Camera.main.transform.position)
            {
                gameOver.GetComponent<Renderer>().enabled = true; //Shows the GameOver Message
                GamePlaying = false;
                
            }
        }
    }
}
