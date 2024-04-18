using UnityEngine;
using System.Collections;

public class CustomText : MonoBehaviour 
{

    // Custom Text
    public GUIStyle guiStyle;
    public GUIContent cText;

    // Use this for initialization
    void OnGUI() 
    {
        //Text itself.
        GUI.Label(new Rect(10,10, 500, 200), cText, guiStyle);
    }
}
