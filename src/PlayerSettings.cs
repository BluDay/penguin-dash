// PlayerSettings.cs
// 
// Penguin Dash
// Copyrights @ 2014-2015 Bachir Bouchemla

using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerSettings : MonoBehaviour 
{
    // Classes
    Animator anim;
    Animator anim2;
    public bool CourseEnd = false;
    public bool End = false;
    public bool Dead;
    public bool Jump;
    public bool FreeFall;
    public bool Pause;
    public float JumpHeight;
    private float jumpRotationSmooth;
    public float rotationS = 2.25f;
    public float PausePosition, HideP;
    public float BGPosition, HideB;
    public float BGPositionZ;
    public float scaleDeath;
    public float scaleXZDeath;
    private float zeroX, zeroY, zeroZ = 0;
    private float timer = 0.0f;
    public float progressTime;
    public AudioClip DeathSound;
    public GameObject player;
    public GameObject musicStop;
    public Image handlerP;
    public Slider progressBar;
    // Penguin Icons.
    public Sprite BP, ZP, SP, HP, NP, CP, GP, AP, PP, AsP, FP, VP, ABP, PuP,
    TP;
    public Sprite DBP, DZP, DSP, DHP, DNP, DCP, DGP, DAP, DPP, DAsP;
    // End.
    private SpriteRenderer myRenderer;
    public GUITexture PauseScreen;
    public GUITexture LevelCScreen;
    public GUITexture blackrect;
    public GUITexture BlackrectFade;  
    public GUITexture Pausebtn;
    //end.

    // Use this for initialization
    public void Start() 
    {
        // Misc Options
        anim = GetComponent<Animator>();
        anim2 = BlackrectFade.GetComponent<Animator>();
        myRenderer = gameObject.GetComponent<SpriteRenderer>();
        transform.eulerAngles = new Vector3(0, 0, 0);
        progressBar.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, 15, 0);
        progressBar.value = 1.5f;


        // Level 4 Option
        if (Application.loadedLevelName == "Level4")
        {
            FreeFall = true;
            Jump = false;
        }
        else
        {
            FreeFall = false;
        }
        //End.
        
        Jump = true;
        Dead = false;
        GetComponent<AudioSource>().Play();

    }


    // Collision Enter.
    void OnCollisionEnter2D(Collision2D col)
    {
        // Player detection.
        if (col.gameObject.name == "BGGround")
        {
            // Ground Collision.
            FreeFall = false; 
            Jump = false;
            rotationS = 2.25f;
        }
        if (col.gameObject.tag == "NotEnemy")
        {
            // Long Box Collision.
            Jump = false;
            rotationS = 2.5f;
        }
        if (col.gameObject.tag == "Tunnel")
        {
            // Long Box Collision.
            Jump = false;
            rotationS = 2.75f;
        }
        // Death Spikes.
        if (col.gameObject.tag == "EnemyS")
        {
            // Death
            AudioSource.PlayClipAtPoint(DeathSound, 
                Vector3.zero, 80);
            Die();
        }
        // Death Box.
        if (col.gameObject.tag == "EnemyB")
        {
            // Death.
            AudioSource.PlayClipAtPoint(DeathSound, 
                Vector3.zero, 80);
            Die();
        }
        // Long Enemy.
        if (col.gameObject.tag == "LongEnemy")
        {
            // Death.
            AudioSource.PlayClipAtPoint(DeathSound, 
                Vector3.zero, 80);
            Die();
        }
        // Edge Box.
        if (col.gameObject.name == "Edge")
        {
            Jump = false;
            rotationS = 2.75f;
        }
        // Super Jump
        if (col.gameObject.name == "SuperJump")
        {
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * 8800f);
        }
        // High Jump
        if (col.gameObject.tag == "HighJumpBox")
        { 
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * 2200f);
        }
        // Entering Igloo...
        if (col.gameObject.name == "ENDINGIgloo")
        {
            End = true;
        }
        if (col.gameObject.tag  == "Ending")
        {
            CourseEnd = true;
            musicStop.GetComponent<Collider2D>().isTrigger = true;
        }

    }

    // Collision Exit.
    void OnCollisionExit2D(Collision2D coll)
    {
        // Spinning
        Jump = true;
        // Ground Detection and exit.
        if (coll.gameObject.name == "BGGround")
        {
            rotationS = (float)2.25f;
        }
        // Long Box Detection and exit.
        if (coll.gameObject.name == "BadBoxLong")
        {
            rotationS = (float)2.25f;
        }
        // Edge Box.
        if (coll.gameObject.name == "Edge")
        {
            rotationS = (float)2.8f;
        }
        if (coll.gameObject.tag == "Tunnel")
        {
            // Long Box Collision.
            rotationS = (float)2.8f;
        }
    }


    // Animation coroutine.
    IEnumerator PDie(float wait)
    {
        Camera.main.orthographicSize = Camera.main.orthographicSize - 0.1f;
        anim2.Play("BlackrectFadeOut");
        yield return new WaitForSeconds(wait);
        Application.LoadLevel(Application.loadedLevel);
    }
 
    // Reloading...
    IEnumerator levelReload(float wait)
    {
         // Reload level.
        GetComponent<AudioSource>().Stop();
        transform.position = new Vector3(transform.position.x, transform.position.y, -13f);

        // Penguins change...
        if (myRenderer.sprite == BP)
        {
            myRenderer.sprite = DBP;
            anim.Play("BDieSplash");
        }
        if (myRenderer.sprite == SP)
        {
            myRenderer.sprite = DSP;
            anim.Play("SDieSplash");
        }
        if (myRenderer.sprite == ZP)
        {
            myRenderer.sprite = DZP;
            anim.Play("ZDieSplash");
        }
        if (myRenderer.sprite == HP)
        {
            myRenderer.sprite = DHP;
            anim.Play("HDieSplash");
        }
        if (myRenderer.sprite == NP)
        {
            myRenderer.sprite = DNP;
            anim.Play("NDieSplash");
        }
        if (myRenderer.sprite == CP)
        {
            myRenderer.sprite = DCP;
            anim.Play("CDieSplash");
        }
        if (myRenderer.sprite == GP)
        {
            myRenderer.sprite = DGP;
            anim.Play("GDieSplash");
        }
        if (myRenderer.sprite == AP)
        {
            myRenderer.sprite = DAP;
            anim.Play("ADieSplash");
        }
        if (myRenderer.sprite == PP)
        {
            myRenderer.sprite = DPP;
            anim.Play("PDieSplash");
        }
        if (myRenderer.sprite == AsP)
        {
            myRenderer.sprite = DAsP;
            anim.Play("AsDieSplash");
        }
        if (myRenderer.sprite == FP)
        {
            myRenderer.sprite = DBP;
            anim.Play("BDieSplash");
        }
        if (myRenderer.sprite == VP)
        {
            myRenderer.sprite = DNP;
            anim.Play("NDieSplash");
        }
        if (myRenderer.sprite == ABP)
        {
            myRenderer.sprite = DBP;
            anim.Play("BDieSplash");
        }
        if (myRenderer.sprite == PuP)
        {
            myRenderer.sprite = DSP;
            anim.Play("SDieSplash");
        }
        if (myRenderer.sprite == TP)
        {
            myRenderer.sprite = DZP;
            anim.Play("ZDieSplash");
        }
        // End.

        // Death Splash Color.
        if (this.anim.GetCurrentAnimatorStateInfo(0).IsName("BDieSplash") || 
            this.anim.GetCurrentAnimatorStateInfo(0).IsName("SDieSplash") || 
            this.anim.GetCurrentAnimatorStateInfo(0).IsName("ZDieSplash") || 
            this.anim.GetCurrentAnimatorStateInfo(0).IsName("HDieSplash") || 
            this.anim.GetCurrentAnimatorStateInfo(0).IsName("NDieSplash") ||
            this.anim.GetCurrentAnimatorStateInfo(0).IsName("CDieSplash") ||
            this.anim.GetCurrentAnimatorStateInfo(0).IsName("GDieSplash") ||
            this.anim.GetCurrentAnimatorStateInfo(0).IsName("ADieSplash") ||
            this.anim.GetCurrentAnimatorStateInfo(0).IsName("PDieSplash") ||
            this.anim.GetCurrentAnimatorStateInfo(0).IsName("AsDieSplash"))
        {
            myRenderer.color = new Color32(255, 255, 255, 255);
        }
        else
        {
            myRenderer.color = new Color32(255, 255, 255, 0);
        }
        // Gettin' to long here...
        // End.

        transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, zeroZ);
        GetComponent<Rigidbody2D>().isKinematic = true;
        yield return new WaitForSeconds(wait);
        Time.timeScale = 1;
        StartCoroutine(PDie(0.2f));
    }

    
    // Death.
    void Die()
    {
        Dead = true;
        GetComponent<AudioSource>().volume = 100;
        GetComponent<Rigidbody2D>().isKinematic = true;
        Jump = false;
    }


    // Back key press.
    void OnBackKeyPress()
    {
        // Touch input.
        if (timer >= 0.9f)
        {
            if (Dead == false)
            {
                if (Pause == false)
                {
                    if (Input.GetKeyDown(KeyCode.Escape))
                    {
                        ApplicationPause();
                    }
                }
            }
        }
    }

    // Game pause.
    public void ApplicationPause()
    {
        // Sets the time scale to 0
        Pause = true;
        Time.timeScale = 0;
        GetComponent<AudioSource>().Pause();
        if(Dead == true)
        {
            GameObject deathSound = GameObject.Find("One shot audio");
            deathSound.GetComponent<AudioSource>().Pause();
        }
        blackrect.transform.position = new Vector3(BGPosition, BGPosition, BGPositionZ);
        PauseScreen.transform.position = new Vector2(PausePosition, PauseScreen.transform.position.y);
        // Pause.
    }

    // Game resume.
    public void ApplicationResume()
    {
        // Sets the time scale to 1
        Pausebtn.color = new Color32(128, 128, 128, 255);
        Pause = false;
        Time.timeScale = 1;
        GetComponent<AudioSource>().Play();
        if(Dead == true)
        {
            GameObject deathSound = GameObject.Find("One shot audio");
            deathSound.GetComponent<AudioSource>().Play();
        }
        blackrect.transform.position = new Vector3(HideB, BGPosition, BGPositionZ);
        PauseScreen.transform.position = new Vector2(HideP, PauseScreen.transform.position.y);
        // Resume.
    }


    // Update is called once per frame
    void Update() 
    {
        // Game settings.
        Application.targetFrameRate = 300;
        QualitySettings.vSyncCount = 0;


        /// -- Changes Penguin Character! -- \\\ 
        var SavedPenguin = PlayerPrefs.GetString("PenguinChanger");
        if (SavedPenguin != null)
        {
            if (SavedPenguin == "BluePenguin")
            {
                myRenderer.sprite = BP;
                handlerP.sprite = BP;
            }
            if (SavedPenguin == "ZombiePenguin")
            {
                myRenderer.sprite = ZP;
                handlerP.sprite = ZP;
            }
            if (SavedPenguin == "SkaterPenguin")
            {
                myRenderer.sprite = SP;
                handlerP.sprite = SP;
            }
            if (SavedPenguin == "HackerPenguin")
            {
                myRenderer.sprite = HP;
                handlerP.sprite = HP;
            }
            if (SavedPenguin == "NinjaPenguin")
            {
                myRenderer.sprite = NP;
                handlerP.sprite = NP;
            }
            if (SavedPenguin == "ClownPenguin")
            {
                myRenderer.sprite = CP;
                handlerP.sprite = CP;
            }
            if (SavedPenguin == "GoldenPenguin")
            {
                myRenderer.sprite = GP;
                handlerP.sprite = GP;
            }
            if (SavedPenguin == "AlienPenguin")
            {
                myRenderer.sprite = AP;
                handlerP.sprite = AP;
            }
            if (SavedPenguin == "PiratePenguin")
            {
                myRenderer.sprite = PP;
                handlerP.sprite = PP;
            }
            if (SavedPenguin == "AstronautPenguin")
            {
                myRenderer.sprite = AsP;
                handlerP.sprite = AsP;
            }
            if (SavedPenguin == "FrostyPenguin")
            {
                myRenderer.sprite = FP;
                handlerP.sprite = FP;
            }
            if (SavedPenguin == "VampirePenguin")
            {
                myRenderer.sprite = VP;
                handlerP.sprite = VP;
            }
            if (SavedPenguin == "BlueAlienPenguin")
            {
                myRenderer.sprite = ABP;
                handlerP.sprite = ABP;
            }
            if (SavedPenguin == "PumpkinPenguin")
            {
                myRenderer.sprite = PuP;
                handlerP.sprite = PuP;
            }
            if (SavedPenguin == "ThunderPenguin")
            {
                myRenderer.sprite = TP;
                handlerP.sprite = TP;
            }
            // End.
        }

        // Pause btn.
        if (Input.touchCount > 0)
        {
            for (int i = 0; i < Input.touchCount; i++)
            {
                Touch t = Input.GetTouch(i);
                print(t);
            }
        }

        if (Input.GetMouseButton(0))
        {
            if (timer >= 0.75f)
            {
                if (Pausebtn.HitTest(Input.mousePosition, Camera.main))
                {
                    Pausebtn.color = new Color32(80, 80, 80, 255);
                    ApplicationPause();
                }
            }
        }
        // end.

        // Progress Bar
        if (End == false)
        {
            if (Dead == false)
            {
                progressBar.value += progressTime;
                if (timer >= 0.5f)
                {
                    if (Pause == false)
                    {
                        progressBar.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, -15, 0);
                    }
                    else
                    {
                        progressBar.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, 15, 0);
                    }
                }
            }
            if (Dead == true)
            {
                progressBar.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, 15, 0);
            }
        }
        else
        {
            progressBar.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, 15, 0);
        }

        // Ending!
        if (End == true)
        {
            blackrect.transform.position = new Vector3(0.5f, 0.5f, -1);
            LevelCScreen.transform.position = new Vector3(0.5f, 0.5f, LevelCScreen.transform.position.z);
        }

        //Timer
        timer += Time.deltaTime;
        if (SceneManager.GetActiveScene().name == "Level1")
        {
            if (timer >= 83f)
            {
                GetComponent<AudioSource>().volume -= 0.45f * Time.deltaTime;
            }
        }
        if (SceneManager.GetActiveScene().name == "Level2")
        {
            if (timer >= 83f)
            {
                GetComponent<AudioSource>().volume -= 0.45f * Time.deltaTime;

            }
        }
        if (SceneManager.GetActiveScene().name == "Level3")
        {
            if (timer >= 82f)
            {
                GetComponent<AudioSource>().volume -= 0.45f * Time.deltaTime;
            }
        }
        if (SceneManager.GetActiveScene().name == "Level4")
        {
            if (timer >= 128f)
            {
                GetComponent<AudioSource>().volume -= 0.45f * Time.deltaTime;
            }
        }
        //end.

        // For Windows Phone & Android...
        OnBackKeyPress();

        // Reload level.
        if (Dead == true)
        {
            Die();
            StartCoroutine(levelReload(0.75f));  
        }

        // If Free Fall Is True.
        if (SceneManager.GetActiveScene().name == "Level4")
        {
            GameObject BluFire = GameObject.Find("BlueFreeFallFire");
            if (FreeFall)
            {
                BluFire.GetComponent<ParticleSystem>().Play();
                transform.position = new Vector3(transform.position.x, transform.position.y, -1f);
                BluFire.transform.position = new Vector3(
                    transform.position.x - 1, transform.position.y + 1.5f, -1.5f);
                transform.eulerAngles = new Vector3(0, 0, 30f);
            }
            else
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, -2.6f);
                BluFire.GetComponent<ParticleSystem>().Stop();
            }
            
            // Free Falling.
            if (timer >= 8f)
            {
                FreeFall = false;
            }
        }

        if (Input.GetButtonDown("XOne_Pause"))
        {
            ApplicationPause();
        }


        // Jump events!
        if (Jump == true)
        {
            jumpRotationSmooth = Mathf.Lerp(0f, -180f, Time.deltaTime * rotationS);
            transform.Rotate(new Vector3(0, 0, jumpRotationSmooth));
            GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;

        }
        if (Jump == false)
        {
            GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;

            if (Input.GetMouseButton(0) 
                || Input.GetKey(KeyCode.Space) 
                || Input.GetKey(KeyCode.UpArrow) 
                || Input.GetButton("XOne_AButton"))
            {
                if (Dead == false)
                {
                    if (Pause == false)
                    {
                        if (CourseEnd == false)
                        {
                            if (Jump == false)
                            {
                                GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                                GetComponent<Rigidbody2D>().AddForce(Vector2.up * JumpHeight, ForceMode2D.Force);
                                Jump = true;
                            }
                        }
                    }
                }
            }
        }
    }
}
