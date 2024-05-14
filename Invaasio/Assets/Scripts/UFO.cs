using UnityEngine;
using System.Collections;

public class UFO : MonoBehaviour
{
    public int hitPoints = 1;
    public int scoreValue = 1;
    private ScoreManager scoreManager; // Reference to the ScoreManager script

    public float rotationSpeed = 10f; // Rotation speed for the UFO

    void Start()
    {
        scoreManager = FindObjectOfType<ScoreManager>();

        // Apply rotation to the UFO game object when the game starts
        SpinRotate();
    }

    public void TakeDamage(int damage)
    {
        if (damage > 0)
        {
            scoreManager.AddScore(scoreValue); // Add the score value when the UFO is destroyed
            Destroy(gameObject); // Destroy the UFO
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