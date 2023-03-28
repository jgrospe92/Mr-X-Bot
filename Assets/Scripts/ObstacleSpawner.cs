using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ObstacleSpawner : MonoBehaviour
{
    // The game object to spawn
    public GameObject objectToSpawn;

    // The interval between object spawns
    public float spawnInterval = 3f;

    // The timer to track the time since the last object spawn
    private float spawnTimer = 0f;

    public float scale = 0.9f;

    // Update is called once per frame
    void Update()
    {
        // Increment the spawn timer
        spawnTimer += Time.deltaTime;

        // If the spawn timer has exceeded the spawn interval
        if (spawnTimer >= spawnInterval)
        {
            // Reset the spawn timer
            spawnTimer = 0f;
            Quaternion spawnRotation = objectToSpawn.gameObject.transform.rotation;

            // Spawn a new instance of the objectToSpawn game object
            GameObject cylinder = Instantiate(objectToSpawn, transform.position, spawnRotation);
            Vector3 newScale = cylinder.transform.localScale;
            newScale.x *= scale += 0.1f;
            newScale.z *= scale += 0.1f ;
            cylinder.transform.localScale = newScale;
        }
    }
}
