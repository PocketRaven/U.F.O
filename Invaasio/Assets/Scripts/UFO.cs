using UnityEngine;

public class UFO : MonoBehaviour
{
    public int hitPoints = 1; 

    private ScoreManager scoreManager; // Reference to the ScoreManager script

    void Start()
    {
        scoreManager = FindObjectOfType<ScoreManager>();
    }

    public void TakeDamage(int damage)
    {
        hitPoints -= damage;
        if (hitPoints <= 0)
        {
            if (damage == 1)
            {
                scoreManager.AddScore(1); 
            }
            else if (damage == 2)
            {
                scoreManager.AddScore(5); 
            }

            Destroy(gameObject);
        }
    }
}