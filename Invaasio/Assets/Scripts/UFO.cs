using UnityEngine;

public class UFO : MonoBehaviour
{
    public int hitPoints = 1; // Default hit points

    private ScoreManager scoreManager; // Reference to the ScoreManager script

    void Start()
    {
        // Get the ScoreManager script component from the GameManager object
        scoreManager = FindObjectOfType<ScoreManager>();
    }

    public void TakeDamage(int damage)
    {
        hitPoints -= damage;
        if (hitPoints <= 0)
        {
            // Call the appropriate method from the ScoreManager script based on the hitPoints value
            if (damage == 1)
            {
                scoreManager.AddScore(10); // Add 1 point for weaker UFO
            }
            else if (damage == 2)
            {
                scoreManager.AddScore(50); // Add 2 points for stronger UFO
            }

            // Destroy the UFO if hit points drop to 0 or below
            Destroy(gameObject);
        }
    }
}