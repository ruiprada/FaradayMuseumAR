using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    public Transform mainCanvas;

    private GameObject gameSpecificCanvas;

    public BoxBlur ARCameraBlur;

    public GameObject ObjectOverview;

    private GameManager gameManager = GameManager.Instance;

    // Start is called before the first frame update
    void Start()
    {
        foreach (Transform chield in mainCanvas)
        {
            if (chield.name == gameObject.name)
            {
                gameSpecificCanvas = chield.gameObject;
            }
        }
    }

    public void StartGame()
    {
        if (gameManager.gameState == GameState.MAIN_MENU)
        {
            ARCameraBlur.Blur();

            ObjectOverview.SetActive(true);
            gameSpecificCanvas.SetActive(true);

            gameManager.SetGameState(GameState.IN_GAME);
            gameManager.SetCurrentGame(this);
        }
    }

    public void LostFocus()
    {
        if (gameManager.gameState == GameState.IN_GAME)
        {
            ARCameraBlur.ResetBlur();
            //gameSpecificCanvas.SetActive(false);
        }
    }

    public void ExitGame()
    {
        ARCameraBlur.ResetBlur();
        gameSpecificCanvas.SetActive(false);
        gameManager.SetGameState(GameState.MAIN_MENU);
    }
}
