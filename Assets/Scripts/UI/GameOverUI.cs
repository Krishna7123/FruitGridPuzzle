using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverUI : MonoBehaviour
{
    public static GameOverUI Instance;

    [Header("UI")]
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private TMP_Text resultText;

    private void Awake()
    {
        Instance = this;

        gameOverPanel.SetActive(false);
    }

    public void ShowWin()
    {
        gameOverPanel.SetActive(true);

        resultText.text = "🎉 YOU WIN";
    }

    public void ShowLose()
    {
        gameOverPanel.SetActive(true);

        resultText.text = "💀 YOU LOSE";
    }

    public void ShowDraw()
    {
        gameOverPanel.SetActive(true);

        resultText.text = "🤝 DRAW";
    }

    public void RestartGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(
            UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex
        );
    }
}