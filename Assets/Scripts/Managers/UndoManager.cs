using System.Collections.Generic;
using UnityEngine;

public class UndoManager : MonoBehaviour
{
    public static UndoManager Instance;
    [SerializeField] private GridManager gridManager;
    [SerializeField] private GameManager gameManager;

    private Stack<GameState> history = new Stack<GameState>();

    private void Awake()
    {
        Instance = this;
    }

    public void SaveState(GameState state)
    {
        history.Push(state);
    }

    public GameState Undo()
    {
        if (history.Count == 0)
            return null;

        return history.Pop();
    }

    public bool HasUndo()
    {
        return history.Count > 0;
    }

    public void SaveCurrentState()
    {
        GameState state = new GameState();

        state.Grid = gridManager.CloneGrid();

        state.PlayerRow = gridManager.PlayerRow;
        state.PlayerColumn = gridManager.PlayerColumn;

        state.Score = gameManager.Score;
        state.Moves = gameManager.Moves;

        state.CollectedFruits = gameManager.CollectedFruits;
        state.TotalFruits = gameManager.TotalFruits;

        SaveState(state);

        Debug.Log("Current State Saved");
    }
}