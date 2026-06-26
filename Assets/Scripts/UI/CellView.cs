using TMPro;
using UnityEngine;

public class CellView : MonoBehaviour
{
    [SerializeField] private TMP_Text iconText;

    public void SetTile(TileType tileType)
    {
        switch (tileType)
        {
            case TileType.Empty:
                iconText.text = "";
                break;

            case TileType.Player:
                iconText.text = "🙂";
                break;

            case TileType.Fruit:
                iconText.text = "🍎";
                break;

            case TileType.Bomb:
                iconText.text = "💣";
                break;
        }
    }
}