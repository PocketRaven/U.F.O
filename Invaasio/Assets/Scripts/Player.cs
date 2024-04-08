using UnityEngine;

public class Player : MonoBehaviour
{
    public float rotationSpeed = 100f;
    public float maxRotationAngle = 60f;

    public Ammus ammusPrefab;
    public Ammus secondaryAmmusPrefab;

    public float launchOffset = 0.0f; // Adjust this value in the editor
    public Transform mainCannon;
    public Transform leftCannon;
    public Transform rightCannon;
    public Transform leftSecondaryCannon;
    public Transform rightSecondaryCannon;

    public float mainCannonBulletSpeed = 10f;
    public float secondaryCannonBulletSpeed = 5f;

    void Update()
    {
        float rotationInput = Input.GetAxis("Horizontal");
        RotateCannon(rotationInput);

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            // Main cannon with a lifespan of 1 second
            Shoot(mainCannon, mainCannonBulletSpeed, ammusPrefab);

            // Secondary cannons with a lifespan of 0.5 seconds
            Shoot(leftCannon, secondaryCannonBulletSpeed, secondaryAmmusPrefab, 1f);
            Shoot(rightCannon, secondaryCannonBulletSpeed, secondaryAmmusPrefab, 1f);

            // Newly added secondary cannons with a lifespan of 0.25 seconds
            Shoot(leftSecondaryCannon, secondaryCannonBulletSpeed, secondaryAmmusPrefab, 0.7f);
            Shoot(rightSecondaryCannon, secondaryCannonBulletSpeed, secondaryAmmusPrefab, 0.7f);
        }
    }

    void RotateCannon(float rotationInput)
    {
        float rotationAmount = -rotationInput * rotationSpeed * Time.deltaTime;
        float currentRotation = transform.localEulerAngles.z + rotationAmount;

        // Ensure rotation stays within 0 to 360 degrees
        if (currentRotation > 180f) currentRotation -= 360f;
        else if (currentRotation < -180f) currentRotation += 360f;

        // Clamp the rotation angle
        currentRotation = Mathf.Clamp(currentRotation, -maxRotationAngle, maxRotationAngle);

        // Set the new rotation
        transform.localEulerAngles = new Vector3(0f, 0f, currentRotation);
    }

    void Shoot(Transform cannon, float bulletSpeed, Ammus bulletPrefab, float bulletLifespan = 1f)
    {
        Vector3 shootDirection = cannon.up;
        Vector3 launchPosition = cannon.position + shootDirection * launchOffset;

        Ammus bullet = Instantiate(bulletPrefab, launchPosition, Quaternion.identity);
        bullet.direction = shootDirection;
        bullet.speed = bulletSpeed;

        Destroy(bullet.gameObject, bulletLifespan);
    }
}