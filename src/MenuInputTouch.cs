// MenuInputTouch.cs
// 
// Penguin Dash
// Copyrights @ Bachir Bouchemla

using UnityEngine;
using System.Collections;

public class MenuInputTouch : MonoBehaviour 
{
    // Classes.
    Animator anim;
    PenguinChange pc;
    public bool clicked;
    public bool Facebook;
    public bool Twitter;
    public bool BluDayGames;
    public GUITexture play;
    public GUITexture icons;
    public GUITexture htp;
    public GUITexture facebook;
    public GUITexture twitter;
    public GUITexture bludaygames;
    public GUITexture Blackrect;

    // Use this for initilization.
    void Start()
    {
        clicked = false;
        Time.timeScale = 1;
        anim = Blackrect.GetComponent<Animator>();
        FadeToClear();
    }

    // From black to clear.
    void FadeToClear()
    {
        anim.Play("BlackrectFadeIn");
    }

    // From clear to black.
    public IEnumerator Play(float wait)
    {
        play.color = new Color32(180, 180, 180, 255);
        anim.Play("BlackrectFadeOut");
        yield return new WaitForSeconds(wait);
        Application.LoadLevel(4);
    }
    // From clear to black.
    public IEnumerator Icons(float wait)
    {
        icons.color = new Color32(180, 180, 180, 255);
        anim.Play("BlackrectFadeOut");
        yield return new WaitForSeconds(wait);
        Application.LoadLevel(2);
    }
    // From clear to black.
    public IEnumerator HTP(float wait)
    {
        htp.color = new Color32(180, 180, 180, 255);
        anim.Play("BlackrectFadeOut");
        yield return new WaitForSeconds(wait);
        Application.LoadLevel(3);
    }


    // Ninja Penguin.
    void SaveFB(string unlockedFB)
    {
        PlayerPrefs.SetString("UnlockedFB", unlockedFB);
        PlayerPrefs.Save();
        print(unlockedFB);
    }

    // Clown Penguin.
    void SaveT(string unlockedT)
    {
        PlayerPrefs.SetString("UnlockedT", unlockedT);
        PlayerPrefs.Save();
        print(unlockedT);
    }

    // Pumpkin Penguin (Halloween).
    void SaveBDG(string unlockedBDG)
    {
        PlayerPrefs.SetString("UnlockedBDG", unlockedBDG);
        PlayerPrefs.Save();
        print(unlockedBDG);
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
                print(t);
            }
        }
       
        // Mouse Button.
        if (Input.GetMouseButtonDown(0))
        {
            if(play.HitTest(Input.mousePosition, Camera.main))
            {
                // If button touch phase began.
                clicked = true;
                StartCoroutine(Play(0.45f));
            }
            if(icons.HitTest(Input.mousePosition, Camera.main))
            {
                // If button touch phase began.
                clicked = true;
                StartCoroutine(Icons(0.45f));
            }
            if(htp.HitTest(Input.mousePosition, Camera.main))
            {
                // If button touch phase began.
                clicked = true;
                StartCoroutine(HTP(0.45f));
            }

            // Miscellaneous buttons.
            if(facebook.HitTest(Input.mousePosition, Camera.main))
            {
                clicked = true;
                Facebook = true;
                Application.OpenURL("http://facebook.com/ThePenguinDash");
                SaveFB("Ninja Penguin");
            }
            if(twitter.HitTest(Input.mousePosition, Camera.main))
            {
                clicked = true;
                Twitter = true;
                Application.OpenURL("http://twitter.com/ThePenguinDash");
                SaveT("Clown Penguin");
            }
            if (bludaygames.HitTest(Input.mousePosition, Camera.main))
            {
                clicked = true;
                BluDayGames = true;
                Application.OpenURL("http://bludaygames.com/");
                SaveBDG("Pumpkin Penguin");
            }
        }
        // Quit...
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PlayerPrefs.Save();
            Application.Quit();
        }
    }
}
    

