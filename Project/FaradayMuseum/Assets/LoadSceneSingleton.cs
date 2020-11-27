using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class LoadSceneSingleton : MonoBehaviour
{

    private string levelName;
    public static LoadSceneSingleton instance;
    private GameManager gameManager = GameManager.Instance;
    public Animator transition;
    public float transitionTime;

    //UserTest
    public static UsabilityTestsSingleton singleton = UsabilityTestsSingleton.Instance();
    private bool LOG = false;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        // UserTest
        singleton.AddGameEvent(LogEventType.OnAppLoad);

        if (LOG)
        {
            StartCoroutine("SendToSigma");
        }

        //unity permissions do not work
        UniAndroidPermission.RequestPermission(AndroidPermission.CALL_PHONE); 
        UniAndroidPermission.RequestPermission(AndroidPermission.READ_PHONE_STATE);
        UniAndroidPermission.RequestPermission(AndroidPermission.WRITE_EXTERNAL_STORAGE);
        UniAndroidPermission.RequestPermission(AndroidPermission.READ_EXTERNAL_STORAGE);

    }

    public void LoadScene(string name)
    {
        levelName = name;
        StartCoroutine(Load());
    }

    IEnumerator Load()
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(levelName);
    }

        IEnumerator SendToSigma()
    {
        while (true)
        {
            singleton.SendtoSigma();
            yield return new WaitForSeconds(10.0f);
        }
    }
 
    IEnumerator SaveToMobile()
    {
        while (true)
        {
            singleton.SaveOnMobile();
            yield return new WaitForSeconds(30.0f);
        }
    }
}

