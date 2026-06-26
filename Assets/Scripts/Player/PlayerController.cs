using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private GridManager gridManager;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            gridManager.MovePlayer(-1, 0);
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            gridManager.MovePlayer(1, 0);
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            gridManager.MovePlayer(0, -1);
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            gridManager.MovePlayer(0, 1);
        }
    }
}