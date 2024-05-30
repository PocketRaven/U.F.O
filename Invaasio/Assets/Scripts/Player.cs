using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    // Existing variables
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
    public Image[] hitPointUI; 
    private int currentHitPoints;
    public GameObject gameOverPanel; 
    public GameObject victoryPanel; 
    public int victoryScore = 250; 
    private int currentScore = 0;

    void Start()
    {
        currentHitPoints = hitPointUI.Length;
        gameOverPanel.SetActive(false); // Gameover piilossa
        victoryPanel.SetActive(false); // Voitto ikkuna piilossa
    }

    void Update()
    {
        // Existing update code
        float rotationInput = Input.GetAxis("Horizontal");
        RotateCannon(rotationInput);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot(mainCannon, mainCannonBulletSpeed, ammusPrefab);
            Shoot(leftCannon, secondaryCannonBulletSpeed, secondaryAmmusPrefab, 1.5f);
            Shoot(rightCannon, secondaryCannonBulletSpeed, secondaryAmmusPrefab, 1.5f);
            Shoot(leftSecondaryCannon, secondaryCannonBulletSpeed, secondaryAmmusPrefab, 1f);
            Shoot(rightSecondaryCannon, secondaryCannonBulletSpeed, secondaryAmmusPrefab, 1f);
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            ResetPlayerRotation();
        }

        // Check for victory
        if (currentScore >= victoryScore)
        {
            Victory();
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
            hitPointUI[currentHitPoints].enabled = false; // HP pois

            if (currentHitPoints <= 0)
            {
                GameOver();
            }
        }
    }

    void GameOver()
    {
        gameOverPanel.SetActive(true); // Näytä gameover
        Time.timeScale = 0; // Stop 
    }

    public void AddScore(int points)
    {
        currentScore += points;
    }

    void Victory()
    {
        victoryPanel.SetActive(true); // Näytä voitto
        Time.timeScale = 0; // Stop 
    }

    public void RestartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("GameScene");
    }

    public void ExitToMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Menu");
    }
}