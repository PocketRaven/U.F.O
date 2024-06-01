using UnityEngine;

public class SetResolution : MonoBehaviour
{
    void Start()
    {
        Screen.SetResolution(800, 600, false); // Set the resolution to 800x600 in windowed mode
    }
}