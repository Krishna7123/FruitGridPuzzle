using UnityEngine;

public class GridManager : MonoBehaviour
{
    [Header("Grid Settings")]
    private int playerRow = 0;
    private int playerColumn = 0;
    [SerializeField] private int rows = 4;
    [SerializeField] private int columns = 4;
    [SerializeField] private int fruitCount = 5;
    [SerializeField] private int bombCount = 3;

    private Cell[,] grid;

    private void Start()
    {
        CreateGrid();

        PlacePlayer();

        SpawnFruits();

        SpawnBombs();

        PrintGrid();
    }

    private void CreateGrid()
    {
        grid = new Cell[rows, columns];

        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < columns; col++)
            {
                grid[row, col] = new Cell(row, col);
            }
        }
    }

    private void PlacePlayer()
    {
        grid[0, 0].TileType = TileType.Player;
    }

    private void SpawnFruits()
    {
        int spawned = 0;

        while (spawned < fruitCount)
        {
            int row = Random.Range(0, rows);
            int col = Random.Range(0, columns);

            if (grid[row, col].TileType == TileType.Empty)
            {
                grid[row, col].TileType = TileType.Fruit;

                spawned++;
            }
        }
    }

    private void SpawnBombs()
    {
        int spawned = 0;

        while (spawned < bombCount)
        {
            int row = Random.Range(0, rows);
            int col = Random.Range(0, columns);

            if (grid[row, col].TileType == TileType.Empty)
            {
                grid[row, col].TileType = TileType.Bomb;

                spawned++;
            }
        }
    }

    private void PrintGrid()
    {
        Debug.Log("----- GRID -----");

        for (int row = 0; row < rows; row++)
        {
            string line = "";

            for (int col = 0; col < columns; col++)
            {
                switch (grid[row, col].TileType)
                {
                    case TileType.Empty:
                        line += ". ";
                        break;

                    case TileType.Player:
                        line += "P ";
                        break;

                    case TileType.Fruit:
                        line += "F ";
                        break;

                    case TileType.Bomb:
                        line += "B ";
                        break;
                }
            }

            Debug.Log(line);
        }
    }

    public void MovePlayer(int rowOffset, int columnOffset)
    {
        int newRow = playerRow + rowOffset;
        int newColumn = playerColumn + columnOffset;

        if (newRow < 0 || newRow >= rows)
            return;

        if (newColumn < 0 || newColumn >= columns)
            return;

        grid[playerRow, playerColumn].TileType = TileType.Empty;

        playerRow = newRow;
        playerColumn = newColumn;

        grid[playerRow, playerColumn].TileType = TileType.Player;

        PrintGrid();
    }
}