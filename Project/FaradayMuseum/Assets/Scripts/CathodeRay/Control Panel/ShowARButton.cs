using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowARButton : MonoBehaviour
{
    [SerializeField]
    private bool showObjs = true;
    [SerializeField]
    private GameObject hideARButton;
    [SerializeField]
    private GameObject showARButton;
    [SerializeField]
    private GameObject[] objsToShow;

    //Delegate an event
    public static Action<bool> OnARButtonClicked;

    public void OnButtonClick()
    {
        showObjs = !showObjs;

        for (int i = 0; i < objsToShow.Length; i++)
        {
            objsToShow[i].SetActive(showObjs);
        }

        hideARButton.SetActive(showObjs);
        showARButton.SetActive(!showObjs);

        // Send a event msg
        OnARButtonClicked?.Invoke(showObjs);
    }
}
