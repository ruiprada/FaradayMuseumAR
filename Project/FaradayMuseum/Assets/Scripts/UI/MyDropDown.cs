using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MyDropDown : GUIControl, IPointerClickHandler
{
    public GameObject dropdownBorder;
    public GameObject hint;

    public MyTrackableEventHandler myTrackableEventHandler;

    private bool myBool = true;

    public override string Name { get { return "DropDown"; } }

    GameManager gameManager;
    // Use this for initialization
    private void Awake()
    {
        gameManager = GameManager.Instance;
        gameManager.OnStateChange += HandleOnStateChange;
    }

    void Start()
    {
        if (gameManager.gameState == GameState.IN_GAME)
        {
            OnHide();
        }
        if (gameManager.gameState == GameState.MAIN_MENU)
        {
            OnShow();
        }
    }

    private void HandleOnStateChange()
    {
        if (gameManager.gameState == GameState.IN_GAME)
        {
            OnHide();
        }
        if (gameManager.gameState == GameState.MAIN_MENU)
        {
            OnShow();
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        hint.SetActive(false);
        dropdownBorder.SetActive(false);

        myTrackableEventHandler.giveHint = false;
    }

    public void Cancel()
    {
        myTrackableEventHandler.giveHint = true;
    }
}
