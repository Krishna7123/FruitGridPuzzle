using UnityEngine;

public class GridRenderer : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GridManager gridManager;
    [SerializeField] private Transform boardParent;
    [SerializeField] private CellView cellPrefab;

    private CellView[,] cellViews;

    private void Start()
    {
       
        CreateBoard();
    }

    private void CreateBoard()
    {
        Debug.Log("CreateBoard Started");

        cellViews = new CellView[gridManager.Rows, gridManager.Columns];

        for (int row = 0; row < gridManager.Rows; row++)
        {
            for (int col = 0; col < gridManager.Columns; col++)
            {
                Debug.Log($"Creating Cell {row},{col}");

                CellView newCell = Instantiate(cellPrefab, boardParent);

                Debug.Log("newCell = " + (newCell != null));

                Debug.Log("Grid Cell = " + (gridManager.Grid[row, col] != null));

                cellViews[row, col] = newCell;

                newCell.SetTile(gridManager.Grid[row, col].TileType);
            }
        }

        Debug.Log("CreateBoard Finished");
    }
    public void RefreshGrid()
    {
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