using UnityEngine;
using System.Collections;

public class Invaders : MonoBehaviour
{
    public GameObject invaderPrefab; // regular invader prefab
    public GameObject strongInvaderPrefab; // stronger invader prefab
    public int rowCount = 5; // Number of rows 
    public float spacing = 1.5f; // Spacing between invader prefabs
    public float strongInvaderChance = 0.1f; // Chance 
    public float fallSpeed = 1f; // Speed at which the invaders fall

    void Start()
    {
        StartCoroutine(SpawnInvadersWaves());
    }

    IEnumerator SpawnInvadersWaves()
    {
        while (true)
        {
            SpawnRowOfInvaders();
            yield return new WaitForSeconds(5f); // Wait for 5 seconds before spawning the next wave
        }
    }

    void SpawnRowOfInvaders()
    {
        Vector3 spawnPosition = transform.position; // Starting position of the row
        for (int i = 0; i < rowCount; i++)
        {
            GameObject prefabToSpawn = invaderPrefab;
            if (Random.Range(0f, 1f) < strongInvaderChance)
            {
                prefabToSpawn = strongInvaderPrefab; // Spawn the strong invader based on chance
            }

            // Calculate the position for each invader in the row
            Vector3 position = spawnPosition + Vector3.right * i * spacing;

            // Instantiate the invader prefab at the calculated position
            GameObject newInvader = Instantiate(prefabToSpawn, position, Quaternion.identity);

            // Add a Rigidbody component to the spawned invader if it doesn't have one
            Rigidbody2D rb = newInvader.GetComponent<Rigidbody2D>();
            if (rb == null)
            {
                rb = newInvader.AddComponent<Rigidbody2D>();
                rb.gravityScale = 0; // Disable gravity to prevent the invaders from falling due to gravity
            }

            // Add a constant downward velocity to make the invader fall
            rb.velocity = Vector2.down * fallSpeed;
        }
    }
}