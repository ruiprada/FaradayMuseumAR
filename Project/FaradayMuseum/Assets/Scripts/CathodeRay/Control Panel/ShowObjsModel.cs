using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowObjsModel : MonoBehaviour
{
    [SerializeField]
    private bool showObjs = true;
    [SerializeField]
    private GameObject hideButton;
    [SerializeField]
    private GameObject showButton;
    [SerializeField]
    private GameObject[] objsToShow;

    public void OnButtonClick()
    {
        showObjs = !showObjs;

        for(int i = 0; i < objsToShow.Length; i++)
        {
            objsToShow[i].SetActive(showObjs);
        }

        hideButton.SetActive(showObjs);
        showButton.SetActive(!showObjs);
    }
}
