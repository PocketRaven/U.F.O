using UnityEngine;
using System.Collections;

public class UFO : MonoBehaviour
{
    public int hitPoints = 1;

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