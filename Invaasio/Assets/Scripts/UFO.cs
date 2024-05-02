using UnityEngine;

public class UFO : MonoBehaviour
{
    public int hitPoints = 1; // Default hit points

    public void TakeDamage(int damage)
    {
        hitPoints -= damage;
        if (hitPoints <= 0)
        {
            Destroy(gameObject); // Destroy the UFO if hit points drop to 0 or below
        }
    }
}