using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Game Data")]
    [SerializeField] private int score;
    [SerializeField] private int moves;

    [SerializeField] private int totalFruits;
    [SerializeField] private int collectedFruits;

    [Header("Win Condition")]
    [SerializeField] private int targetScore = 5;

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

    public void RegisterFruit()
    {
        totalFruits++;
    }

    public void CollectFruit()
    {
        collectedFruits++;
        score++;

        CheckGameState();
    }

    public void HitBomb()
    {
        score -= 2;

        CheckGameState();
    }

    public void AddMove()
    {
        moves++;
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