using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour {
    public static UsabilityTestsSingleton singleton = UsabilityTestsSingleton.Instance();

    public void SceneChanger(string sceneName)
    {
        singleton.AddGameEvent(LogEventType.ChangeScene, "Telephone");

        if (!SceneManager.GetSceneByName(sceneName).IsValid()){ //isvalid() tras false se for verdade que não seja valido... portanto !
            LoadSceneSingleton.instance.LoadScene(sceneName);

       }
    }
}
