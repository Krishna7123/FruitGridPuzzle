using System;

[Serializable]
public class Cell
{
    public int Row;
    public int Column;

    public TileType TileType;

    public bool IsCollected;

    public Cell(int row, int column)
    {
        Row = row;
        Column = column;

        TileType = TileType.Empty;

        IsCollected = false;
    }
}