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

    public int Score => score;
    public int Moves => moves;
    public int TotalFruits => totalFruits;
    public int CollectedFruits => collectedFruits;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
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

        if (collectedFruits == totalFruits)
        {
            if (score >= targetScore)
            {
                Debug.Log("YOU WIN");
            }
            else if (score == 0)
            {
                Debug.Log("DRAW");
            }
            else
            {
                Debug.Log("YOU LOSE");
            }
        }
    }
}