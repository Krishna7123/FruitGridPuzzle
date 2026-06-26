using UnityEngine;

public class GridManager : MonoBehaviour
{
    [Header("Grid Settings")]
 
    [SerializeField] private int rows = 4;
    [SerializeField] private int columns = 4;
    [SerializeField] private int fruitCount = 5;
    [SerializeField] private int bombCount = 3;

    private Cell[,] grid;
    private int playerRow;
    private int playerColumn;
    
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
        playerRow = 0;
        playerColumn = 0;
        grid[playerRow,playerColumn].TileType = TileType.Player;
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
                GameManager.Instance.RegisterFruit();
                Debug.Log("Fruit Spawned : " + row + "," + col);

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
                Debug.Log("Bomb Spawned : " + row + "," + col);

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

        // Check top boundary
        if (newRow < 0)
            return;

        // Check bottom boundary
        if (newRow >= rows)
            return;

        // Check left boundary
        if (newColumn < 0)
            return;

        // Check right boundary
        if (newColumn >= columns)
            return;

        // Remove player from old position
        TileType destinationTile = grid[newRow, newColumn].TileType;

        // Collect Fruit
        if (destinationTile == TileType.Fruit)
        {
            GameManager.Instance.CollectFruit();
            Debug.Log("Fruit Collected!");
        }

        // Hit Bomb
        if (destinationTile == TileType.Bomb)
        {
            GameManager.Instance.HitBomb();
            Debug.Log("Bomb Hit!");
        }

        // Remove player from old position
        grid[playerRow, playerColumn].TileType = TileType.Empty;

        // Move player
        playerRow = newRow;
        playerColumn = newColumn;

        // Place player
        grid[playerRow, playerColumn].TileType = TileType.Player;

        GameManager.Instance.AddMove();

        PrintGrid();
    }
}