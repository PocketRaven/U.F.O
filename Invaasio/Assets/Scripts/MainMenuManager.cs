using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    public GameObject rulesPanel; 
    public GameObject volumePanel;
    public GameObject thankYouPanel; 

    [SerializeField] Slider VolumeSlider;

    void Start()
    {
 
        if (rulesPanel != null)
        {
            rulesPanel.SetActive(false);
        }
        if (volumePanel != null)
        {
            volumePanel.SetActive(false);
        }
        if (thankYouPanel != null)
        {
            thankYouPanel.SetActive(false);
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene("GameScene"); 
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

    public void ShowThankYou()
    {
        if (thankYouPanel != null)
        {
            thankYouPanel.SetActive(true);
        }
    }

    public void HideThankYou()
    {
        if (thankYouPanel != null)
        {
            thankYouPanel.SetActive(false);
        }
    }

    private void Awake()
    {
        if (PlayerPrefs.HasKey("Volume"))
        {
            SetVolume(PlayerPrefs.GetFloat("Volume"));
            VolumeSlider.value = PlayerPrefs.GetFloat("Volume");
        }
    }

    public void SetVolume(float volume)
    {
        AudioListener.volume = volume;
        PlayerPrefs.SetFloat("Volume", volume);
    }
}