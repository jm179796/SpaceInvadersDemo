using Academy.HoloToolkit.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserManager : Singleton<LaserManager> {
    
    /// <summary>
    /// The laser object that will be used
    /// </summary>
    public GameObject LaserPrefab;

    /// <summary>
    /// Executes when an air tap is detected by the Gesture Manager
    /// </summary>
    void OnAirTapped()
    {
        FireLaser();
    }
    public void FireLaser()

    /// <summary>
    /// Fires the laser
    /// </summary>
    {
        var Laser = Instantiate(LaserPrefab, Camera.main.transform.position, Quaternion.identity); // Spawns the laser prefab
        Laser.transform.Translate(new Vector3(0, -0.1f, 0)); // Moves the object downwards by 0.1 units
        Laser.transform.LookAt(Camera.main.transform); // Rotates the object to look at the camera
        Laser.GetComponent<Rigidbody>().velocity = Camera.main.transform.forward * 6; // Increases the object's speed
        Destroy(Laser, 2.0f); // Destroys the laser object after 2 seconds
    }
}
