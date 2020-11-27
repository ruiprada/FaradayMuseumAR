using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class MyTrackableEventHandler : DefaultTrackableEventHandler
{
    #region PRIVATE_MEMBER_VARIABLES

    #endregion // PROTECTED_MEMBER_VARIABLES

    #region PUBLIC_VARIABLES

    public GameObject DropdownBorder;

    public GameObject hint;

    public bool giveHint;

    public bool active = false;

    private Game gameScript;

    public GameObject preview;

    #endregion

    #region PUBLIC_VARIABLES

    private IEnumerator coroutine;

    #endregion

    protected override void Start()
    {

        giveHint = true;

        gameScript = gameObject.GetComponent<Game>();

        base.Start();
        StartCoroutine(Hint(5.0f));
    }

    protected override void OnTrackingFound()
    {
        if (!active) return;

        base.OnTrackingFound();

        giveHint = false;

        gameScript.StartGame();
    }

    protected override void OnTrackingLost()
    {
        base.OnTrackingLost();

        giveHint = true;

        gameScript.LostFocus();
    }

    public void StartTracking()
    {
        active = true;
    }

    public void StopTracking()
    {
        active = false;
    }

    IEnumerator Hint(float waitTime)
    {
        while (true)
        {
            yield return new WaitForSeconds(waitTime);

            if (giveHint && DropdownBorder.activeInHierarchy == false)
            {
                hint.SetActive(true);
                DropdownBorder.SetActive(true);
            }
        }
    }
}
