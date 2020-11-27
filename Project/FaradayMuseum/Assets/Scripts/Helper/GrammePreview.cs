public class GrammePreview : GUIControl
{
    public override string Name { get { return "GrammePreview"; } }

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
    }
}
