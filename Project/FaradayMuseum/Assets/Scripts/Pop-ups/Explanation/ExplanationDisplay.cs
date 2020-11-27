using TMPro;
using UnityEngine;

public class ExplanationDisplay : MonoBehaviour
{
    [Tooltip("This manager needs to contain the settings manager script")]
    public GameObject manager;
    public Explanation[] explanation;

    public TextMeshProUGUI title;
    public TextMeshProUGUI description;

    private string ID;

    private void Update()
    {
        // if user click, disable the explanation
        if (Input.GetMouseButtonDown(0))
        {
            gameObject.SetActive(false);
        }
    }

    void Start()
    {
        string expertiseLevel = manager.GetComponent<SettingsManager>().GetExpertiseLevel();
        string targetID = manager.GetComponent<TargetManager>().GetTargetID();

        for (int i = 0; i < explanation.Length; i++)
        {
            if (explanation[i].expertiseLevel == expertiseLevel &&
                explanation[i].artifactID == targetID && 
                explanation[i].ID == ID)
            {
                title.text = explanation[i].title;
                description.text = explanation[i].description;
            }
        }

    }

    public string GetID()
    {
        return ID;
    }

    public void SetID(string id)
    {
        ID = id;
    }
}