using UnityEngine;

public class UFO : MonoBehaviour
{
    public int hitPoints = 1; // Default hit points
    public GameObject explosionPrefab; // Reference to the explosion prefab

    public void TakeDamage(int damage)
    {
        hitPoints -= damage;
        if (hitPoints <= 0)
        {
            Explode();
            Destroy(gameObject); // Destroy the UFO if hit points drop to 0 or below
        }
    }

    void Explode()
    {
        if (explosionPrefab != null)
        {
            GameObject explosion = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            Destroy(explosion, 0.2f); // Destroy the explosion after 0.5 seconds
        }
    }
}