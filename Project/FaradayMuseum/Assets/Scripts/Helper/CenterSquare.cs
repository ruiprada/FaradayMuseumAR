public class CenterSquare : GUIControl
{
    public override string Name { get { return "CenterSquare"; } }

    GameManager gameManager;

    private void Awake()
    {
        gameManager = GameManager.Instance;
        gameManager.OnStateChange += HandleOnStateChange;
    }

    private void HandleOnStateChange()
    {
        if (gameManager.gameState == GameState.IN_GAME)
        {
            OnHide();
        }
        //if (gameManager.gameState == GameState.MAIN_MENU)
        //{
        //    OnShow();
        //}
    }
}
