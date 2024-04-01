using UnityEngine;

public class Player : MonoBehaviour
{
    public float rotationSpeed = 100f; // Adjust this to control how fast the cannon rotates
    public float maxRotationAngle = 60f; // Maximum rotation angle in degrees

    private float currentRotation = 0f; // Variable to store current rotation angle

    public Ammus ammusPrefab;
    void Update()
    {
        // Get user input for rotation
        float rotationInput = Input.GetAxis("Horizontal");

        // Rotate the player's cannon based on input
        RotateCannon(rotationInput);

        if (Input.GetKeyDown(KeyCode.Space)  || Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    void RotateCannon(float rotationInput)
    {
        // Calculate the rotation amount based on input and rotation speed
        float rotationAmount = -rotationInput * rotationSpeed * Time.deltaTime; // Negate the rotation input

        // Update the current rotation angle
        currentRotation += rotationAmount;

        // Clamp the current rotation within the specified range
        currentRotation = Mathf.Clamp(currentRotation, -maxRotationAngle, maxRotationAngle);

        // Apply rotation to the player's cannon
        transform.localRotation = Quaternion.Euler(0f, 0f, currentRotation);
    }

    private void Shoot()
    {
        Instantiate(this.ammusPrefab, this.transform.position, Quaternion.identity);
    }
}