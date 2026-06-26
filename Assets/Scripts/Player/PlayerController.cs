using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private GridManager gridManager;

    public void MoveUp()
    {
        gridManager.MovePlayer(-1, 0);
    }

    public void MoveDown()
    {
        gridManager.MovePlayer(1, 0);
    }

    public void MoveLeft()
    {
        gridManager.MovePlayer(0, -1);
    }

    public void MoveRight()
    {
        gridManager.MovePlayer(0, 1);
    }
}