using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject BirdPrefab;

    // Frames between spawns
    public int SpawnTime = 10;

    // Internal counter
    private int counter = 0;

    void Start()
    {
        
    }

    void FixedUpdate()
    {
        // If we can spawn the Ball
        if (counter > SpawnTime)
        {
            // We generate a random x coordinate for the Bird
            float xPosition = Random.Range(-20, 20);

            // We instantiate a new Bird at the generated axis while keeping the Y and Z axes constant
            var bird = Instantiate(BirdPrefab, transform.position + new Vector3(xPosition, 2, 10), Quaternion.identity, gameObject.transform);

            // We make sure that the Bird is properly scaled
            bird.transform.localScale = new Vector3(2, 2, 2);

            // Make the bird move forward
            bird.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 10f); // forward speed

            // We tell the program to destroy the Bird after 10 seconds have passed and reset the counter
            Destroy(bird, 10);
            counter = 0;
        }
        else
        {
            counter++;
        }
    }
}