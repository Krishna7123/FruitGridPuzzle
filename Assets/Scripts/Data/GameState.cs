using System;

[Serializable]
public class GameState
{
    public Cell[,] Grid;

    public int PlayerRow;
    public int PlayerColumn;

    public int Score;
    public int Moves;

    public int CollectedFruits;
    public int TotalFruits;
}