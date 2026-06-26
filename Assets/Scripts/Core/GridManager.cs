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
    [SerializeField] private GridRenderer gridRenderer;

    public Cell[,] Grid => grid;
    public int Rows => rows;
    public int Columns => columns;

    public int PlayerRow => playerRow;
    public int PlayerColumn => playerColumn;
    private void Awake()
    {
        CreateGrid();

        
    }

    private void Start()
    {
        PlacePlayer();

        SpawnFruits();

        SpawnBombs();
        PrintGrid();
       // gridRenderer.RefreshGrid();
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

                if (GameManager.Instance == null)
                {
                    Debug.LogError("GameManager.Instance is NULL!");
                }
                else
                {
                    GameManager.Instance.RegisterFruit();
                }

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

        if (newRow < 0 || newRow >= rows)
            return;

        if (newColumn < 0 || newColumn >= columns)
            return;

        TileType destinationTile = grid[newRow, newColumn].TileType;

        if (destinationTile == TileType.Fruit)
        {
            GameManager.Instance.CollectFruit();
            Debug.Log("Fruit Collected!");
        }

        if (destinationTile == TileType.Bomb)
        {
            GameManager.Instance.HitBomb();
            Debug.Log("Bomb Hit!");
        }

        grid[playerRow, playerColumn].TileType = TileType.Empty;

        playerRow = newRow;
        playerColumn = newColumn;

        grid[playerRow, playerColumn].TileType = TileType.Player;

        GameManager.Instance.AddMove();

        PrintGrid();

        if (gridRenderer != null)
        {
            gridRenderer.RefreshGrid();
        }
    }

    public Cell[,] CloneGrid()
    {
        Cell[,] copy = new Cell[rows, columns];

        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < columns; col++)
            {
                Cell original = grid[row, col];

                Cell clone = new Cell(original.Row, original.Column);

                clone.TileType = original.TileType;
                clone.IsCollected = original.IsCollected;

                copy[row, col] = clone;
            }
        }

        return copy;
    }
}