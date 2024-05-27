using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    public GameObject rulesPanel; // Reference to the RulesPanel
    public GameObject volumePanel; // Reference to the VolumePanel

    [SerializeField] Slider VolumeSlider;

    void Start()
    {
        // Ensure the panels are hidden at the start
        if (rulesPanel != null)
        {
            rulesPanel.SetActive(false);
        }
        if (volumePanel != null)
        {
            volumePanel.SetActive(false);
        }

    }

    public void StartGame()
    {
        SceneManager.LoadScene("GameScene"); // Replace "GameScene" with the name of your main game scene
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ShowRules()
    {
        if (rulesPanel != null)
        {
            rulesPanel.SetActive(true);
        }
    }

    public void HideRules()
    {
        if (rulesPanel != null)
        {
            rulesPanel.SetActive(false);
        }
    }

    public void ShowVolume()
    {
        if (volumePanel != null)
        {
            volumePanel.SetActive(true);
        }
    }

    public void HideVolume()
    {
        if (volumePanel != null)
        {
            volumePanel.SetActive(false);
        }
    }

    private void Awake()
    {
        if (PlayerPrefs.HasKey("Volume"))
            {
            SetVolume(PlayerPrefs.GetFloat("Volume"));
            VolumeSlider.value = PlayerPrefs.GetFloat("Volume"); }
    }

    public void SetVolume(float volume)
    {
        AudioListener.volume = volume;
        PlayerPrefs.SetFloat("Volume", volume);

    }


}

