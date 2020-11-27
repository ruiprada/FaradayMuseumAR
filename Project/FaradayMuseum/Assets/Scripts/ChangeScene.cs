using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour {


    //LoadSceneSingleton scene;
    [SerializeField]
    private GameObject loadingSceneManager;

    public static UsabilityTestsSingleton singleton = UsabilityTestsSingleton.Instance();

    public void Awake()
    {
        ////Debug.Log("o changeScene acordou");
        loadingSceneManager = GameObject.FindGameObjectWithTag("LoadManagar");
    }

    public void start()
    {
        ////Debug.Log("o changeScene comecou");
    }

    public void SceneChanger(string sceneName)
    {
        singleton.AddGameEvent(LogEventType.ChangeScene, "Telephone");

        if (!SceneManager.GetSceneByName(sceneName).IsValid()){ //isvalid() tras false se for verdade que não seja valido... portanto !
            //SceneManager.LoadScene(sceneName);
            //loadingSceneManager.GetComponent<LoadingSceneManager>().changedScene = true;
            LoadSceneSingleton.instance.StartLoading(sceneName);

       }
       else
       {
           ////Debug.Log("Erro: Não é uma scene válida");
       }
        
    }
}
