// LevelSelect.cs
// 
// Penguin Dash
// Copyrights @ 2014-2015 Bachir Bouchemla

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using System.Collections;

public class LevelSelect : MonoBehaviour 
{
    // Classes.
    Animator anim;
    MenuButtonTouch MBTClass;
    public bool levelClicked;
    public GUITexture level1, 
    level2, level3, level4,
    level5, level6;

    public GUITexture Blackrect;

    public GUITexture Level1NCText, 
    Level2NCText, 
    Level3NCText, 
    Level4NCText,
    Level5NCText,
    Level6NCText;


    public Texture2D LevelCText;
    public GUITexture rightArrow, leftArrow;

    public GameObject levelTextObject;
    public Text lvlText;

    public float timer;

    // Use this for initialization
    void Start() 
    {
        Time.timeScale = 1;
        GameObject menuButton = GameObject.Find("MenuButton");
        MBTClass = menuButton.GetComponent<MenuButtonTouch>();
        anim = Blackrect.GetComponent<Animator>();
        lvlText = levelTextObject.GetComponent<Text>();
        levelTextObject.transform.localPosition = new Vector3(levelTextObject.transform.localPosition.x, levelTextObject.transform.localPosition.y, -1f);
        FadeToClear();
    }
    
    // From black to clear.
    void FadeToClear()
    {
        anim.Play("BlackrectFadeIn");
    }

    // From clear to black.
    public IEnumerator LoadL1(float wait)
    {
        level1.color = new Color32(80, 80, 80, 255);
        anim.Play("BlackrectFadeOut");
        yield return new WaitForSeconds(wait);
        Application.LoadLevel(5);
    }
    public IEnumerator LoadL2(float wait)
    {
        level2.color = new Color32(80, 80, 80, 255);
        anim.Play("BlackrectFadeOut");
        yield return new WaitForSeconds(wait);
        Application.LoadLevel(6);
    }
    public IEnumerator LoadL3(float wait)
    {
        level3.color = new Color32(80, 80, 80, 255);
        anim.Play("BlackrectFadeOut");
        yield return new WaitForSeconds(wait);
        Application.LoadLevel(7);
    }
    public IEnumerator LoadL4(float wait)
    {
        level4.color = new Color32(80, 80, 80, 255);
        anim.Play("BlackrectFadeOut");
        yield return new WaitForSeconds(wait);
        Application.LoadLevel(8);
    }
    public IEnumerator LoadL5(float wait)
    {
        level5.color = new Color32(80, 80, 80, 255);
        anim.Play("BlackrectFadeOut");
        yield return new WaitForSeconds(wait);
        Application.LoadLevel(9);
    }
    public IEnumerator LoadL6(float wait)
    {
        level6.color = new Color32(80, 80, 80, 255);
        anim.Play("BlackrectFadeOut");
        yield return new WaitForSeconds(wait);
        Application.LoadLevel(10);
    }

    // Arrows.
    public IEnumerator RightArrow(float wait)
    {
        rightArrow.color = new Color32(70, 70, 70, 255);
        yield return new WaitForSeconds(wait);
        rightArrow.color = new Color32(128, 128, 128, 255);
    }
    public IEnumerator LeftArrow(float wait)
    {
        leftArrow.color = new Color32(70, 70, 70, 255);
        yield return new WaitForSeconds(wait);
        leftArrow.color = new Color32(128, 128, 128, 255);
    }


    // Update is called once per frame
    void Update() 
    {

        // Timer.
        timer += Time.deltaTime;

        // If Clicked
        if (Input.touchCount > 0)
        {
            for (int i = 0; i < Input.touchCount; i++)
            {
                Touch t = Input.GetTouch(i);
                print(t);
            }
        }

        // Level Completed Text, or not.
        var Level1C = PlayerPrefs.GetString("Level1");
        if (Level1C != null)
        {
            if (Level1C == "Level1Completed")
            {
                Level1NCText.GetComponent<GUITexture>().texture = LevelCText;
                Level1NCText.transform.localScale = new Vector3(0.8f, Level1NCText.transform.localScale.y, 1);
                PlayerPrefs.Save();
            }
        }
        var Level2C = PlayerPrefs.GetString("Level2");
        if (Level2C != null)
        {
            if (Level2C == "Level2Completed")
            {
                Level2NCText.GetComponent<GUITexture>().texture = LevelCText;
                Level2NCText.transform.localScale = new Vector3(0.8f, Level2NCText.transform.localScale.y, 1);
                PlayerPrefs.Save();
            }
        }
        var Level3C = PlayerPrefs.GetString("Level3");
        if (Level3C != null)
        {
            if (Level3C == "Level3Completed")
            {
                Level3NCText.GetComponent<GUITexture>().texture = LevelCText;
                Level3NCText.transform.localScale = new Vector3(0.8f, Level3NCText.transform.localScale.y, 1);
                PlayerPrefs.Save();
            }
        }
        var Level4C = PlayerPrefs.GetString("Level4");
        if (Level4C != null)
        {
            if (Level4C == "Level4Completed")
            {
                Level4NCText.GetComponent<GUITexture>().texture = LevelCText;
                Level4NCText.transform.localScale = new Vector3(0.8f, Level4NCText.transform.localScale.y, 1);
                PlayerPrefs.Save();
            }
        }
        var Level5C = PlayerPrefs.GetString("Level5");
        if (Level5C != null)
        {
            if (Level5C == "Level5Completed")
            {
                Level5NCText.GetComponent<GUITexture>().texture = LevelCText;
                Level5NCText.transform.localScale = new Vector3(0.8f, Level5NCText.transform.localScale.y, 1);
                PlayerPrefs.Save();
            }
        }
        var Level6C = PlayerPrefs.GetString("Level6");
        if (Level6C != null)
        {
            if (Level6C == "Level6Completed")
            {
                Level6NCText.GetComponent<GUITexture>().texture = LevelCText;
                Level6NCText.transform.localScale = new Vector3(0.8f, Level6NCText.transform.localScale.y, 1);
                PlayerPrefs.Save();
            }
        }
        // End.


        // Text color timing
        if (levelClicked == false)
        {
            if (timer > 0.45f && MBTClass.menuClicked == false)
            {
                lvlText.color = new Color32(255, 255, 255, 255);
            }
            if (timer < 0.45f || MBTClass.menuClicked == true)
            {
                lvlText.color = new Color32(0, 0, 0, 255);
            }
        }
        else if (levelClicked == true)
        {
            lvlText.color = new Color32(0, 0, 0, 255);
        }


        // Level 1
        if (Camera.main.transform.position == new Vector3(0f, Camera.main.transform.position.y, Camera.main.transform.position.z))
        {
            level1.transform.position = new Vector3(0.5f, level1.transform.position.y, level1.transform.position.z);
            lvlText.text = "1. Heaven";
        }
        else
        {
            level1.transform.position = new Vector3(-1f, level1.transform.position.y, level1.transform.position.z);
        }

        // Level 2
        if (Camera.main.transform.position == new Vector3(20f, Camera.main.transform.position.y, Camera.main.transform.position.z))
        {
            level2.transform.position = new Vector3(0.5f, level2.transform.position.y, level2.transform.position.z);
            lvlText.text = "2. Under \n The Sun";
        }
        else
        {
            level2.transform.position = new Vector3(-2f, level2.transform.position.y, level2.transform.position.z);
        }

        // Level 3
        if (Camera.main.transform.position == new Vector3(40f, Camera.main.transform.position.y, Camera.main.transform.position.z))
        {
            level3.transform.position = new Vector3(0.5f, level3.transform.position.y, level3.transform.position.z);
            lvlText.text = "3. Escapade \n To Mars";
        }
        else
        {
            level3.transform.position = new Vector3(-3f, level3.transform.position.y, level3.transform.position.z);
        }

        // Level 4
        if (Camera.main.transform.position == new Vector3(60f, Camera.main.transform.position.y, Camera.main.transform.position.z))
        {
            level4.transform.position = new Vector3(0.5f, level4.transform.position.y, level4.transform.position.z);
            lvlText.text = "4. Welcome to \n our world";
        }
        else
        {
            level4.transform.position = new Vector3(-4f, level4.transform.position.y, level4.transform.position.z);
        }

        // Level 5
        if (Camera.main.transform.position == new Vector3(80f, Camera.main.transform.position.y, Camera.main.transform.position.z))
        {
            level5.transform.position = new Vector3(0.5f, level5.transform.position.y, level5.transform.position.z);
            lvlText.text = "5. Coldwater";
        }
        else
        {
            level5.transform.position = new Vector3(-4f, level5.transform.position.y, level5.transform.position.z);
        }

        // Level 6
        if (Camera.main.transform.position == new Vector3(100f, Camera.main.transform.position.y, Camera.main.transform.position.z))
        {
            level6.transform.position = new Vector3(0.5f, level6.transform.position.y, level6.transform.position.z);
            lvlText.text = "6. In The \n Distance";
        }
        else
        {
            level6.transform.position = new Vector3(-4f, level6.transform.position.y, level6.transform.position.z);
        }





        /// -- Arrows -- \\\
        if (Camera.main.transform.position == new Vector3(100f, Camera.main.transform.position.y, Camera.main.transform.position.z))
        {
            rightArrow.transform.position = new Vector3(-0.875f, rightArrow.transform.position.y, rightArrow.transform.position.z);
        }
        else
        {
            rightArrow.transform.position = new Vector3(0.875f, rightArrow.transform.position.y, rightArrow.transform.position.z);
        }
        if (Camera.main.transform.position == new Vector3(20f, Camera.main.transform.position.y, Camera.main.transform.position.z) ||
            Camera.main.transform.position == new Vector3(40f, Camera.main.transform.position.y, Camera.main.transform.position.z) ||
            Camera.main.transform.position == new Vector3(60f, Camera.main.transform.position.y, Camera.main.transform.position.z) ||
            Camera.main.transform.position == new Vector3(80f, Camera.main.transform.position.y, Camera.main.transform.position.z) ||
            Camera.main.transform.position == new Vector3(100f, Camera.main.transform.position.y, Camera.main.transform.position.z))
        {
            leftArrow.transform.position = new Vector3(0.125f, leftArrow.transform.position.y, leftArrow.transform.position.z);
        }
        else
        {
            leftArrow.transform.position = new Vector3(-0.125f, leftArrow.transform.position.y, leftArrow.transform.position.z);
        }
        // End.


        // Input Mouse Down.
        if (Input.GetMouseButtonDown(0))
        {
            // Level Select!
            if (level1.HitTest(Input.mousePosition, Camera.main))
            {
                levelClicked = true;
                StartCoroutine(LoadL1(0.45f));
            }
            if (level2.HitTest(Input.mousePosition, Camera.main))
            {
                levelClicked = true;
                StartCoroutine(LoadL2(0.45f));
            }
            if (level3.HitTest(Input.mousePosition, Camera.main))
            {
                levelClicked = true;
                StartCoroutine(LoadL3(0.45f));
            }
            if (level4.HitTest(Input.mousePosition, Camera.main))
            {
                levelClicked = true;
                StartCoroutine(LoadL4(0.45f));
            }
            if (level5.HitTest(Input.mousePosition, Camera.main))
            {
                levelClicked = true;
                StartCoroutine(LoadL5(0.45f));
            }
            if (level6.HitTest(Input.mousePosition, Camera.main))
            {
                levelClicked = true;
                StartCoroutine(LoadL6(0.45f));
            }
            // End.


            // Right Arrow Clicked.
            if (rightArrow.HitTest(Input.mousePosition, Camera.main))
            {
                // Button Highlight
                StartCoroutine(RightArrow(0.15f));
                Camera.main.transform.position = new Vector3(Camera.main.transform.position.x + 20, Camera.main.transform.position.y, Camera.main.transform.position.z);

            }

            // Left Arrow Clicked.
            if (leftArrow.HitTest(Input.mousePosition, Camera.main))
            {
                // Button Highlight
                StartCoroutine(LeftArrow(0.15f));
                Camera.main.transform.position = new Vector3(Camera.main.transform.position.x - 20, Camera.main.transform.position.y, Camera.main.transform.position.z);

            }
        }
    }
}
