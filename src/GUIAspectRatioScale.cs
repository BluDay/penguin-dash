// GUIAspectRatioScale.cs
// 
// Penguin Dash
// Copyrights @ 2014-2015 Bachir Bouchemla

using UnityEngine;
using System.Collections;

public class GUIAspectRatioScale : MonoBehaviour 
{

    public Vector2 scaleOnRatio1 = new Vector2(0.05f, 0.05f);
    private Transform myTransform;
    private float widthHeightR;

    // Use this for initialization
    void Start() 
    {
        myTransform = transform;
        SetScale();
    }
    
    // Update is called once per frame
    void Update() 
    {
        SetScale();
    }

    // Use this for settings custom GUI scale.
    void SetScale()
    {
        // Finding the aspect ratio.
        widthHeightR = (float)Screen.width/Screen.height;

        myTransform.localScale = new Vector3(scaleOnRatio1.x, widthHeightR * scaleOnRatio1.y, 1);
    }
}
