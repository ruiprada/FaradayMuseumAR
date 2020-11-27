using TMPro;
using UnityEngine;

public class InitialExplicationDisplay : MonoBehaviour
{
    [Tooltip("This manager needs to contain the settings manager script")]
    public GameObject manager;
    public InitialExplication[] initialExplications;

    public TextMeshProUGUI title;
    public TextMeshProUGUI description;

    void Start()
    {
        string expertiseLevel = manager.GetComponent<SettingsManager>().GetExpertiseLevel();
        string targetID = manager.GetComponent<TargetManager>().GetTargetID();

        for (int i = 0; i < initialExplications.Length; i++)
        {
            if(initialExplications[i].expertiseLevel == expertiseLevel &&
                initialExplications[i].artifactID == targetID)
            {
                title.text = initialExplications[i].title;
                description.text = initialExplications[i].description;
            }
        }

    }
}
