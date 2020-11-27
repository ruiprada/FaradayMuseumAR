using UnityEngine;
using System.Collections;

// Game States
// for now we are only using these two
public enum GameState { INTRO, MAIN_MENU, IN_GAME }

public delegate void OnStateChangeHandler();

public class GameManager
{
    protected GameManager() { }
    private static GameManager instance = null;
    public event OnStateChangeHandler OnStateChange;
    public GameState gameState { get; private set; }
    public Game currentGame { get; private set; }

    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new GameManager();
            }
            return instance;
        }

    }

    public void SetGameState(GameState state)
    {
        gameState = state;
        if (OnStateChange != null)
        {
            OnStateChange();
        }
    }

    public void SetCurrentGame(Game game)
    {
        currentGame = game;

    }

    public void OnApplicationQuit()
    {
        instance = null;
    }
}