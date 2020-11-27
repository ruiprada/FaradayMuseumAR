using TMPro;
using UnityEngine;

public class HintDisplay : MonoBehaviour
{
    [Tooltip("This manager needs to contain the settings manager script")]
    public GameObject manager;
    public Hint[] hint;

    public TextMeshProUGUI title;
    public TextMeshProUGUI description;

    private string ID;

    void Start()
    {
        string expertiseLevel = manager.GetComponent<SettingsManager>().GetExpertiseLevel();
        string targetID = manager.GetComponent<TargetManager>().GetTargetID();

        for (int i = 0; i < hint.Length; i++)
        {
            if (hint[i].expertiseLevel == expertiseLevel &&
                hint[i].artifactID == targetID &&
                hint[i].ID == ID)
            {
                title.text = hint[i].title;
                description.text = hint[i].description;
            }
        }

    }

    private void Update()
    {
        // if user click, disable the hint
        if (Input.GetMouseButtonDown(0))
        {
            gameObject.SetActive(false);
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
