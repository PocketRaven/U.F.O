using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    public AudioSource audioSource;

    void Start()
    {
        // Play the background music
        audioSource.Play();
    }
}