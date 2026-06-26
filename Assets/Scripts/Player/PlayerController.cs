using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private GridManager gridManager;

    public void MoveUp()
    {
        if (GameManager.Instance.IsGameOver)
            return;

        gridManager.MovePlayer(-1, 0);
    }

    public void MoveDown()
    {
        if (GameManager.Instance.IsGameOver)
            return;

        gridManager.MovePlayer(1, 0);
    }

    public void MoveLeft()
    {
        if (GameManager.Instance.IsGameOver)
            return;

        gridManager.MovePlayer(0, -1);
    }

    public void MoveRight()
    {
        Debug.Log("Move Right Pressed");

        if (GameManager.Instance.IsGameOver)
        {
            Debug.Log("Game Over is TRUE");
            return;
        }

        gridManager.MovePlayer(0, 1);
    }
}