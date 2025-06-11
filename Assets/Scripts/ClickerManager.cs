using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ClickerManager : MonoBehaviour
{
    public int score = 0;
    public int pointsPerClick = 1; // Control upgrade effect here
    public TMP_Text scoreText;

    public Button clickButton;
    public Button saveButton;
    public Button loadButton;
    public Button upgradeButton; // NEW: Upgrade Button

    void Start()
    {
        clickButton.onClick.AddListener(IncreaseScore);
        saveButton.onClick.AddListener(SaveScore);
        loadButton.onClick.AddListener(LoadScore);
        upgradeButton.onClick.AddListener(UpgradeClick);
        upgradeButton.gameObject.SetActive(false); // Hide until unlocked

        UpdateScoreText();
    }

    void Update()
    {
        // Check if upgrade should be shown
        if (score >= 10 && !upgradeButton.gameObject.activeSelf)
        {
            upgradeButton.gameObject.SetActive(true);
        }
    }

    void IncreaseScore()
    {
        score += pointsPerClick;
        UpdateScoreText();
    }

    void SaveScore()
    {
        PlayerPrefs.SetInt("score", score);
        PlayerPrefs.Save();
    }

    void LoadScore()
    {
        score = PlayerPrefs.GetInt("score", 0);
        UpdateScoreText();
    }

    void UpgradeClick()
    {
        pointsPerClick = 5;
        upgradeButton.interactable = false;
        upgradeButton.GetComponentInChildren<TMP_Text>().text = "Upgrade bought!";
    }

    void UpdateScoreText()
    {
        scoreText.text = "Score: " + score;
    }
}
