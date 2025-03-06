using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Globalization;

[RequireComponent(typeof(TextMeshProUGUI))]
public class SimpleBehaviourScript : MonoBehaviour
{
    private TextMeshProUGUI textObj;
    public SimpleIntData dataObj;
    
    //Start is called before the first fram update
    void Start()
    {
        textObj = GetComponent<TextMeshProUGUI>();
        UpdateWithIntData();
    }
    //Update is called once per frame
    void UpdateWithIntData()
    {
        textObj.text = dataObj.value.ToString(CultureInfo.InvariantCulture);
    }
    
}
