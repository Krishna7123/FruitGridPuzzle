using UnityEngine;
using System.Collections.Generic;
public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Game Data")]
    [SerializeField] private int score;
    [SerializeField] private int moves;

    [SerializeField] private int totalFruits;
    [SerializeField] private int collectedFruits;
    private Stack<GameState> gameHistory = new Stack<GameState>();

    [Header("Win Condition")]
    [SerializeField] private int targetScore = 5;
    private bool gameOver = false;

    public bool IsGameOver => gameOver;

    public int Score => score;
    public int Moves => moves;
    public int TotalFruits => totalFruits;
    public int CollectedFruits => collectedFruits;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;

        gameOver = false;
    }

    private void Start()
    {
        UpdateHUD();
    }

    public void RegisterFruit()
    {
        totalFruits++;

        UpdateHUD();
    }

    public void CollectFruit()
    {
        collectedFruits++;
        score++;

        UpdateHUD();

        CheckGameState();
    }

    public void HitBomb()
    {
        score -= 2;

        UpdateHUD();

        CheckGameState();
    }

    public void AddMove()
    {
        moves++;

        UpdateHUD();
    }

    private void UpdateHUD()
    {
        if (UIManager.Instance != null)
        {
            UIManager.Instance.UpdateUI(
                score,
                moves,
                collectedFruits,
                totalFruits
            );
        }
    }

    public void SaveGameState(GameState state)
    {
        gameHistory.Push(state);

        Debug.Log("Game State Saved");

        Debug.Log("History Count : " + gameHistory.Count);
    }

    public GameState GetPreviousState()
    {
        if (gameHistory.Count == 0)
        {
            return null;
        }

        return gameHistory.Pop();
    }

    private void CheckGameState()
    {
        Debug.Log("--------------------------");
        Debug.Log("Score : " + score);
        Debug.Log("Moves : " + moves);
        Debug.Log("Collected Fruits : " + collectedFruits + "/" + totalFruits);

        if (score < 0)
        {
            gameOver = true;
            GameOverUI.Instance.ShowLose();
            return;
        }

        if (collectedFruits == totalFruits)
        {
            gameOver = true;

            if (score >= targetScore)
            {
                GameOverUI.Instance.ShowWin();
            }
            else if (score == 0)
            {
                GameOverUI.Instance.ShowDraw();
            }
            else
            {
                GameOverUI.Instance.ShowLose();
            }
        }
    }

    public void SetScore(int value)
    {
        score = value;
    }

    public void SetMoves(int value)
    {
        moves = value;
    }

    public void SetCollectedFruits(int value)
    {
        collectedFruits = value;
    }

    public void SetTotalFruits(int value)
    {
        totalFruits = value;
    }

    public void ResetGame()
    {
        score = 0;
        moves = 0;
        totalFruits = 0;
        collectedFruits = 0;

        gameOver = false;

        UpdateHUD();
    }

    private void OnDestroy()
    {
        if (Instance == this)
        {
            Instance = null;
        }
    }
}