// BackgroundAudio.cs
// 
// Penguin Dash
// Copyrights @ Bachir Bouchemla

using UnityEngine;
using System.Collections;

public class BackgroundAudio : MonoBehaviour 
{

    // Music Manager
    private static BackgroundAudio instance = null;

    public GameObject song;

    public static BackgroundAudio Instance
    {
        get { return instance; }
    }

    // Use this for initialization
    void Awake() 
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
    }

    public void OnLevelWasLoaded(int level)
    {
        // If level was loaded.
        if (level >= 5)
        {
            Destroy(song);
        }
    }
}
