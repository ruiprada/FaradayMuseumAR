public class LeaveMenuWindow : GUIControl
{
    public override string Name { get { return "LeaveMenu"; } }

    GameManager gameManager;

    private void Awake()
    {
        gameManager = GameManager.Instance;
    }

    public void OnExitGame()//your GUI button control should execute this
    {
        GUIManager.ShowAndHide("MainMenu", this);
        gameManager.SetGameState(GameState.MAIN_MENU);
        gameManager.currentGame.ExitGame();
    }
}
