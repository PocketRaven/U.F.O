using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float rotationSpeed = 100f;
    public float maxRotationAngle = 60f;

    public Ammus ammusPrefab;
    public Ammus secondaryAmmusPrefab;

    public AudioSource shootingAudioSource;
    public AudioClip shootingSoundEffect;

    public float launchOffset = 0.0f;
    public Transform mainCannon;
    public Transform leftCannon;
    public Transform rightCannon;
    public Transform leftSecondaryCannon;
    public Transform rightSecondaryCannon;

    public float mainCannonBulletSpeed = 10f;
    public float secondaryCannonBulletSpeed = 5f;

    public Image[] hitPointUI; // Array of Image components representing hit points
    private int currentHitPoints;

    void Start()
    {
        currentHitPoints = hitPointUI.Length;
    }

    void Update()
    {
        float rotationInput = Input.GetAxis("Horizontal");
        RotateCannon(rotationInput);

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            Shoot(mainCannon, mainCannonBulletSpeed, ammusPrefab);
            Shoot(leftCannon, secondaryCannonBulletSpeed, secondaryAmmusPrefab, 1f);
            Shoot(rightCannon, secondaryCannonBulletSpeed, secondaryAmmusPrefab, 1f);
            Shoot(leftSecondaryCannon, secondaryCannonBulletSpeed, secondaryAmmusPrefab, 0.7f);
            Shoot(rightSecondaryCannon, secondaryCannonBulletSpeed, secondaryAmmusPrefab, 0.7f);
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            ResetPlayerRotation();
        }
    }

    void RotateCannon(float rotationInput)
    {
        float rotationAmount = -rotationInput * rotationSpeed * Time.deltaTime;
        float currentRotation = transform.localEulerAngles.z + rotationAmount;

        if (currentRotation > 180f) currentRotation -= 360f;
        else if (currentRotation < -180f) currentRotation += 360f;

        currentRotation = Mathf.Clamp(currentRotation, -maxRotationAngle, maxRotationAngle);
        transform.localEulerAngles = new Vector3(0f, 0f, currentRotation);
    }

    void ResetPlayerRotation()
    {
        Vector3 newRotation = transform.rotation.eulerAngles;
        newRotation.z = 0f;
        transform.rotation = Quaternion.Euler(newRotation);
    }

    void Shoot(Transform cannon, float bulletSpeed, Ammus bulletPrefab, float bulletLifespan = 1f)
    {
        Vector3 shootDirection = cannon.up;
        Vector3 launchPosition = cannon.position + shootDirection * launchOffset;

        Ammus bullet = Instantiate(bulletPrefab, launchPosition, Quaternion.identity);
        bullet.direction = shootDirection;
        bullet.speed = bulletSpeed;

        shootingAudioSource.PlayOneShot(shootingSoundEffect);
        Destroy(bullet.gameObject, bulletLifespan);
    }

    public void InvaderPassed()
    {
        if (currentHitPoints > 0)
        {
            currentHitPoints--;
            hitPointUI[currentHitPoints].enabled = false; // Disable the hit point image
        }
    }
}