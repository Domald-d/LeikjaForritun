using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHealthBar : MonoBehaviour
{
    //breytur fyrir líf bar á player
    public static UIHealthBar instance { get; private set; }
    public Image mask;
    float originalSize;
    // Start is called before the first frame update

    //awake fall
    void Awake()
    {
        //notum instance aðferð
        instance = this;
    }
    void Start()
    {
        //setjum maskan
        originalSize = mask.rectTransform.rect.width;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //fall til að setja maskan á 
    public void SetValue(float value)
    {
        mask.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, originalSize * value);
    }
}
