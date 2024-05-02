using UnityEngine;

public class Invaders : MonoBehaviour
{
    public GameObject invaderPrefab; // Reference to the regular invader prefab
    public GameObject strongInvaderPrefab; // Reference to the stronger invader prefab
    public int columnCount = 5; // Number of columns in the grid
    public int rowCount = 5; // Number of rows in the grid
    public float spacing = 1.5f; // Spacing between invader prefabs
    public float speed = 1f; // Speed at which the column moves downwards
    public float strongInvaderChance = 0.1f; // Chance to spawn a stronger invader

    void Start()
    {
        CreateInvadersGrid();
    }

    void Update()
    {
        MoveColumnDown();
    }

    void CreateInvadersGrid()
    {
        for (int row = 0; row < rowCount; row++)
        {
            for (int col = 0; col < columnCount; col++)
            {
                GameObject prefabToSpawn = invaderPrefab;
                if (Random.Range(0f, 1f) < strongInvaderChance)
                {
                    prefabToSpawn = strongInvaderPrefab; // Spawn the strong invader based on chance
                }

                Vector3 position = transform.position + new Vector3(col * spacing, -row * spacing, 0);
                Instantiate(prefabToSpawn, position, Quaternion.identity, transform);
            }
        }
    }

    void MoveColumnDown()
    {
        // Calculate the downward movement
        float movementAmount = speed * Time.deltaTime;

        // Move each invader in the column downwards
        foreach (Transform child in transform)
        {
            child.transform.position -= new Vector3(0, movementAmount, 0);
        }
    }
}