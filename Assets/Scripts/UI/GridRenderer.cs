using UnityEngine;
using System.Collections;

public class GridRenderer : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GridManager gridManager;
    [SerializeField] private Transform boardParent;
    [SerializeField] private CellView cellPrefab;

    private CellView[,] cellViews;

    private IEnumerator Start()
    {
        yield return null;

        CreateBoard();
        RefreshGrid();
    }

    private void CreateBoard()
    {
        foreach (Transform child in boardParent)
        {
            Destroy(child.gameObject);
        }

        cellViews = new CellView[gridManager.Rows, gridManager.Columns];

        for (int row = 0; row < gridManager.Rows; row++)
        {
            for (int col = 0; col < gridManager.Columns; col++)
            {
                CellView newCell = Instantiate(cellPrefab, boardParent);

                cellViews[row, col] = newCell;
            }
        }
    }

    public void RefreshGrid()
    {
        if (cellViews == null)
            return;

        for (int row = 0; row < gridManager.Rows; row++)
        {
            for (int col = 0; col < gridManager.Columns; col++)
            {
                cellViews[row, col].SetTile(
                    gridManager.Grid[row, col].TileType
                );
            }
        }
    }
}