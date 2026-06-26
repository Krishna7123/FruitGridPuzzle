using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField] private PlayerController playerController;

    [SerializeField] private float minimumSwipeDistance = 100f;

    private Vector2 touchStartPosition;
    private Vector2 touchEndPosition;

    private void Update()
    {
        ReadKeyboardInput();
        ReadTouchInput();
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

    private void ReadTouchInput()
    {
        if (Input.touchCount == 0)
            return;

        Touch touch = Input.GetTouch(0);

        switch (touch.phase)
        {
            case TouchPhase.Began:

                touchStartPosition = touch.position;

                break;

            case TouchPhase.Ended:

                touchEndPosition = touch.position;

                DetectSwipe();

                break;
        }
    }

    private void DetectSwipe()
    {
        Vector2 swipe = touchEndPosition - touchStartPosition;

        if (swipe.magnitude < minimumSwipeDistance)
            return;

        if (Mathf.Abs(swipe.x) > Mathf.Abs(swipe.y))
        {
            if (swipe.x > 0)
            {
                playerController.MoveRight();
            }
            else
            {
                playerController.MoveLeft();
            }
        }
        else
        {
            if (swipe.y > 0)
            {
                playerController.MoveUp();
            }
            else
            {
                playerController.MoveDown();
            }
        }
    }
}