using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField] private PlayerController playerController;

    private void Update()
    {
        ReadKeyboardInput();
    }

    private void ReadKeyboardInput()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            playerController.MoveUp();
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            playerController.MoveDown();
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            playerController.MoveLeft();
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            playerController.MoveRight();
        }
    }
}