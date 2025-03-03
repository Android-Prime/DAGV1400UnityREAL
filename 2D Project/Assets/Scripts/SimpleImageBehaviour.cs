using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class SimpleImageBehaviour : MonoBehaviour
{
private Image _imageObj;
public SimpleFloatData dataObj;

private void Start()
{
    _imageObj = GetComponent<Image>();
}

public void Update()
{
    _imageObj.fillAmount = dataObj.value;
    
}


    
}
   
