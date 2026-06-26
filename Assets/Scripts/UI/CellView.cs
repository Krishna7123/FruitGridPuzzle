using UnityEngine;
using UnityEngine.UI;

public class CellView : MonoBehaviour
{
    [Header("Image")]
    [SerializeField] private Image tileImage;

    [Header("Sprites")]
    [SerializeField] private Sprite emptySprite;
    [SerializeField] private Sprite playerSprite;
    [SerializeField] private Sprite fruitSprite;
    [SerializeField] private Sprite bombSprite;

    public void SetTile(TileType tileType)
    {
        switch (tileType)
        {
            case TileType.Empty:
                tileImage.sprite = emptySprite;
                break;

            case TileType.Player:
                tileImage.sprite = playerSprite;
                break;

            case TileType.Fruit:
                tileImage.sprite = fruitSprite;
                break;

            case TileType.Bomb:
                tileImage.sprite = bombSprite;
                break;
        }
    }
}