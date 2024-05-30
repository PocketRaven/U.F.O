using UnityEngine;
using System.Collections;

public class UFO : MonoBehaviour
{
    public int hitPoints = 1;
    public int scoreValue = 1;
    private ScoreManager scoreManager; 
    public GameObject explosionPrefab;

    public float rotationSpeed = 10f; 

    void Start()
    {
        scoreManager = FindObjectOfType<ScoreManager>();

        //lis‰‰ rotaatio
        SpinRotate();
    }

    public void TakeDamage(int damage)
    {
        hitPoints -= damage;
        if (hitPoints <= 0)
        {
            if (damage == 1)
            {
                scoreManager.AddScore(scoreValue);
            }

            // Instantiate explosion prefab
            GameObject explosion = Instantiate(explosionPrefab, transform.position, Quaternion.identity);

            // Destroy explosion after 0.5 seconds
            Destroy(explosion, 0.5f);

            // Destroy the UFO
            Destroy(gameObject);
        }
    }

    void SpinRotate()
    {
        // Rotate the UFO game object continuously
        StartCoroutine(RotateUFO());
    }

    IEnumerator RotateUFO()
    {
        while (true)
        {
            transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
            yield return null;
        }
    }
}