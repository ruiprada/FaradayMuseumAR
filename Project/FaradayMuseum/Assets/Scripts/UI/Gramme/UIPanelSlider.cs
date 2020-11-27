using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class UIPanelSlider : MonoBehaviour
{
    #region PUBLIC_VARIABLES
    public Text minValue;
    public Text maxValue;
    public Text currentValueAbove;
    public Text currentValueInside;
    [Range(1, 3)]
    public int valueDisappearAfter = 2;

    #endregion PUBLIC_VARIABLES

    #region PRIVATE_VARIABLES

    private Slider slider;
    private bool dirty;

    #endregion PRIVATE_VARIABLES

    void Start()
    {
        slider = GetComponent<Slider>();

        minValue.text = slider.minValue.ToString();
        maxValue.text = slider.maxValue.ToString();

        StartCoroutine(RemoveAfterSeconds(valueDisappearAfter, currentValueAbove.gameObject));
    }


    void Update()
    {
        if(!dirty){
            currentValueAbove.gameObject.SetActive(false);
            currentValueInside.gameObject.SetActive(true);
        }
    }

    // Update is called once per frame
    public void UpdateValue()
    {
        dirty = true;
        currentValueAbove.text = slider.value.ToString();
        currentValueInside.text = slider.value.ToString();
    
        currentValueAbove.gameObject.SetActive(true);  
        currentValueInside.gameObject.SetActive(false);
    }


    IEnumerator RemoveAfterSeconds(int seconds, GameObject obj)
    {
        while(true){
            yield return new WaitForSeconds(seconds);
            dirty = false;
        }
    }
}
