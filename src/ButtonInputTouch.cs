// ButtonInputTouch.cs
// 
// Penguin Dash
// Copyrights @ Bachir Bouchemla

using UnityEngine;
using System.Collections;

public class ButtonInputTouch : MonoBehaviour 
{
    // Classes.
    Animator anim;
    public bool resumePressed;
    public GUITexture resume;
    public GameObject player;
    public GUITexture Blackrect;
    PlayerSettings p;


    // Use this for initialization
    void Start() 
    {
        Time.timeScale = 1;
        p = player.GetComponent<PlayerSettings>();
        resume.color = new Color32(128, 128, 128, 255);
    }

    // Animation coroutine.
    IEnumerator ResumeIE(float wait)
    {
        resume.color = new Color32(180, 180, 180, 255);
        resumePressed = true;
        yield return new WaitForSeconds(wait);
        p.ApplicationResume();
        resume.color = new Color32(128, 128, 128, 255);
    }

    // Update is called once per frame
    void Update() 
    {
        // Pause Buttons 2D.
        if (Input.touchCount > 0)
        {
            for (int i = 0; i < Input.touchCount; i++)
            {
                Touch t = Input.GetTouch(i);
                if (t.phase == TouchPhase.Began)
                {
                    if(resume.HitTest(t.position, Camera.main))
                    {
                        // Resume Button...
                        print("Resume Pressed");
                    }
                }
            }
        }
        // Mouse Button.
        if (Input.GetMouseButtonDown(0))
        {
            if(resume.HitTest(Input.mousePosition, Camera.main))
            {
                // If button touch phase began.
                Time.timeScale = 1;
                StartCoroutine(ResumeIE(0.1f));
            }
        }
    }
}
    

