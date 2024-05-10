using UnityEngine;

public class Invaders : MonoBehaviour
{
    public GameObject invaderPrefab; // regular invader prefab
    public GameObject strongInvaderPrefab; // stronger invader prefab
    public int columnCount = 5; // Number of columns 
    public int rowCount = 5; // Number of rows 
    public float spacing = 1.5f; // Spacing between invader prefabs
    public float speed = 1f; // Speed 
    public float strongInvaderChance = 0.1f; // Chance 

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
        // downward movement
        float movementAmount = speed * Time.deltaTime;

        // Move each invader downwards
        foreach (Transform child in transform)
        {
            child.transform.position -= new Vector3(0, movementAmount, 0);
        }
    }
}