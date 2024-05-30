using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    public AudioSource audioSource;

    void Start()
    {
        audioSource.Play();
    }
}