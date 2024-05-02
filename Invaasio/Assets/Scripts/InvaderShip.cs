using UnityEngine;

public class InvaderShip : MonoBehaviour
{
    public float speed = 5f; // Adjust speed as needed
    public GameObject invaderPrefab; // Reference to the invader prefab

    void Update()
    {
        // Move the object downwards
        transform.Translate(Vector3.down * speed * Time.deltaTime);

        // Check if the object is out of bounds (below the screen)
        if (transform.position.y < -10f) // Adjust the value based on your scene's setup
        {
            // Destroy the object if it's below the screen
            Destroy(gameObject);
        }
    }
    void Start()
    {
        // Spawn seven other copies of the invader prefab in a line next to each other
        for (int i = 1; i <= 7; i++)
        {
            Vector3 positionOffset = Vector3.right * i; // Offset position to the right
            GameObject newInvader = Instantiate(invaderPrefab, transform.position + positionOffset, Quaternion.identity);
            newInvader.transform.parent = transform; // Set the spawner as the parent
        }
    }
}