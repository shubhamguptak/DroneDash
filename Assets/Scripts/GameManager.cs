using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    private int currentScore = 0;
    public static GameManager instance;

    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] public TextMeshProUGUI gameOverText;
    [SerializeField] private PlayerController playerController;

    private void Awake() => instance = this;

    private void Start() => UpdateScoreText();

    public void IncrementScore()
    {
        currentScore++;
        UpdateScoreText();
        playerController.IncreaseSpeed();
    }

    private void UpdateScoreText() => scoreText.text = "SCORE: " + currentScore;

    public void GameOver() => gameOverText.enabled = true;
}
