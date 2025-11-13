using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    
    [Header("UI References")]
    public Text coinsText;
    public GameObject gameOverPanel;
    public GameObject levelCompletePanel;
    public Text finalCoinsText;
    
    [Header("Audio")]
    public AudioClip backgroundMusic;
    public AudioClip victorySound;
    
    private int coins = 0;
    private int totalCoins = 0;
    private AudioSource audioSource;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        totalCoins = GameObject.FindGameObjectsWithTag("Coin").Length;
        UpdateUI();
        
        // Play background music
        if (backgroundMusic != null)
        {
            audioSource.clip = backgroundMusic;
            audioSource.loop = true;
            audioSource.Play();
        }
    }

    public void AddCoin()
    {
        coins++;
        UpdateUI();
    }

    void UpdateUI()
    {
        if (coinsText != null)
        {
            coinsText.text = $"Coins: {coins}/{totalCoins}";
        }
    }

    public void GameOver()
    {
        gameOverPanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void LevelComplete()
    {
        levelCompletePanel.SetActive(true);
        finalCoinsText.text = $"You collected {coins} out of {totalCoins} coins!";
        
        if (victorySound != null)
        {
            audioSource.PlayOneShot(victorySound);
        }
        
        Time.timeScale = 0f;
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void NextLevel()
    {
        Time.timeScale = 1f;
        // Load next level - you'll need to set this up in your build settings
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextSceneIndex);
        }
        else
        {
            SceneManager.LoadScene(0); // Return to first level
        }
    }

    public void MainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
}
