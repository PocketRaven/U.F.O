using UnityEngine;

public class Player : MonoBehaviour
{
    public float rotationSpeed = 100f;
    public float maxRotationAngle = 60f;

    public Ammus ammusPrefab;
    public Ammus secondaryAmmusPrefab;

    public float launchOffset = 0.5f; // Adjust this value in the edito
    public Transform mainCannon;
    public Transform leftCannon;
    public Transform rightCannon;

    public float mainCannonBulletSpeed = 10f;
    public float secondaryCannonBulletSpeed = 5f;

    void Update()
    {
        float rotationInput = Input.GetAxis("Horizontal");
        RotateCannon(rotationInput);

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            Shoot(mainCannon, mainCannonBulletSpeed, ammusPrefab);

            // Shoot from secondary cannons
            Shoot(leftCannon, secondaryCannonBulletSpeed, secondaryAmmusPrefab);
            Shoot(rightCannon, secondaryCannonBulletSpeed, secondaryAmmusPrefab);
        }
    }

    void RotateCannon(float rotationInput)
    {
        float rotationAmount = -rotationInput * rotationSpeed * Time.deltaTime;
        float currentRotation = transform.localRotation.eulerAngles.z + rotationAmount;

        // Ensure rotation stays within -180 to 180 degrees
        if (currentRotation > 180f)
            currentRotation -= 360f;

        // Clamp the rotation angle
        float clampedRotation = Mathf.Clamp(currentRotation, -maxRotationAngle, maxRotationAngle);

        // Set the new rotation
        transform.localRotation = Quaternion.Euler(0f, 0f, clampedRotation);
    }

    void Shoot(Transform cannon, float bulletSpeed, Ammus bulletPrefab)
    {
        Vector3 shootDirection = cannon.up;

        // Calculate the launch position with an offset from the cannon tip
        Vector3 launchPosition = cannon.position + shootDirection * launchOffset;

        // Instantiate the bullet prefab at the adjusted launch position
        Ammus bullet = Instantiate(bulletPrefab, launchPosition, Quaternion.identity);

        // Set bullet properties
        bullet.direction = shootDirection;
        bullet.speed = bulletSpeed;

        // Destroy the bullet after its lifespan
        Destroy(bullet.gameObject, 1f);
    }
}