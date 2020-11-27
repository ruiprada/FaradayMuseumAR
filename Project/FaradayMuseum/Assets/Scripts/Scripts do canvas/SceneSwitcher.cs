using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public void GotoMainScene()
    {
        SceneManager.LoadScene("main");
    }

    public void GotoMenuScene()
    {
        SceneManager.LoadScene("menu");
    }

    public void GotoScene(string sceneName)
    {
        if (!SceneManager.GetSceneByName(sceneName).IsValid())
        { //isvalid() tras false se for verdade que não seja valido... portanto !
            //SceneManager.LoadScene(sceneName);
            LoadSceneSingleton.instance.StartLoading(sceneName);

        }
    }
}
