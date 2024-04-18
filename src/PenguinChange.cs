/// PenguinChange.cs
// 
// Penguin Dash
// Copyrights @ 2014-2015 Bachir Bouchemla

using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class PenguinChange : MonoBehaviour 
{
    // Variables
    public bool NLocked, 
        CLocked, GLocked, ALocked, 
        PLocked, AsLocked, FLocked,
        VLocked, BaPLocked, PuPLocked,
        TPLocked;

    public bool BluePenguinS, ZombiePenguinS,
        SkaterPenguinS, HackerPenguinS, NinjaPenguinS,
        ClownPenguinS, GoldenPenguinS, AlienPenguinS,
        PiratePenguinS, AstronautPenguinS, VampirePenguinS,
        FrostyPenguinS, BlueAlienPenguinS, PumpkinPenguinS,
        ThunderPenguinS;

    private float c1 = 0.23f;
    private float c2 = 0.365f;
    private float c3 = 0.5f;
    private float c4 = 0.635f;
    private float c5 = 0.77f;

    public GUITexture unlockPenguins, hideBtn, blackRect;

    public GUITexture BP, SP, ZP, HP, NP, CP, GP, AP, 
        PP, AsP, FP, VP, BaP, PuP, TP;

    public GUITexture NPText, CPText, 
        GPText, APText, PPText, AsPText, FPText, VPText, BaPText,
        PuPText, TPText;

    public GUITexture NLockedIcon, CLockedIcon, GLockedIcon,
        ALockedIcon, PLockedIcon, AsLockedIcon, FLockedIcon, 
        VLockedIcon, BaPLockedIcon, PuPLockedIcon, TPLockedIcon;

    public Texture2D NPu, CPu, GPu, APu, PPu, AsPu, FPu, 
        VPu, BaPu, PuPu, TPu, locked;

    public Transform charGrid;

    public GameObject menu;

    // Use this for initialization
    public void Start() 
    {
        // Intializing the scene!
        Time.timeScale = 1;

        // BluDay Games
        var CharUnlockedBDG = PlayerPrefs.GetString("UnlockedBDG");
        if (CharUnlockedBDG != null)
        {
            if (CharUnlockedBDG == "Pumpkin Penguin") 
            {
                PuPLocked = false;
                PuP.color = new Color32(128, 128, 128, 255);
                PuPText.transform.localScale = new Vector3(1f, PuPText.transform.localScale.y, 
                    PuPText.transform.localScale.z);
                PuPText.GetComponent<GUITexture>().texture = PuPu;

                TPLocked = false;
                TP.color = new Color32(128, 128, 128, 255);
                TPText.transform.localScale = new Vector3(1f, TPText.transform.localScale.y, 
                    TPText.transform.localScale.z);
                TPText.GetComponent<GUITexture>().texture = TPu;

                PlayerPrefs.Save();
            }
            else
            {
                PuPLocked = true;
                PuP.color = Color.black;

                TPLocked = true;
                TP.color = Color.black;
            }
        }

        // Facebook.
        var CharUnlockedFB = PlayerPrefs.GetString("UnlockedFB");
        if (CharUnlockedFB != null)
        {
            if (CharUnlockedFB == "Ninja Penguin")
            {
                NLocked = false;
                NP.color = new Color32(128, 128, 128, 255);
                NPText.transform.localScale = new Vector3(1f, NPText.transform.localScale.y, 
                    NPText.transform.localScale.z);
                NPText.GetComponent<GUITexture>().texture = NPu;
                PlayerPrefs.Save();
            }
        }
        else
        {
            NLocked = true;
            NP.color = Color.black;
        }

        // Twitter Penguin.
        var CharUnlockedT = PlayerPrefs.GetString("UnlockedT");
        if (CharUnlockedT != null)
        {
            if (CharUnlockedT == "Clown Penguin")
            {
                CLocked = false;
                CP.color = new Color32(128, 128, 128, 255);
                CPText.transform.localScale = new Vector3(1f, CPText.transform.localScale.y, 
                    CPText.transform.localScale.z);
                CPText.GetComponent<GUITexture>().texture = CPu;
                PlayerPrefs.Save();
            }
            else
            {
                CLocked = true;
                CP.color = Color.black;
            }
        }

        // Level 1
        var CharUnlockedLevel1 = PlayerPrefs.GetString("Level1");
        if (CharUnlockedLevel1 != null)
        {
            if (CharUnlockedLevel1 == "Level1Completed")
            {
                FLocked = false;
                FP.color = new Color32(128, 128, 128, 255);
                FPText.transform.localScale = new Vector3(1f, FPText.transform.localScale.y, 
                    FPText.transform.localScale.z);
                FPText.GetComponent<GUITexture>().texture = FPu;
                PlayerPrefs.Save();
            }
            else
            {
                FLocked = true;
                FP.color = Color.black;
            }
        }

        // Level 2
        var CharUnlockedLevel2 = PlayerPrefs.GetString("Level2");
        if (CharUnlockedLevel2 != null)
        {
            if (CharUnlockedLevel2 == "Level2Completed")
            {
                GLocked = false;
                GP.color = new Color32(128, 128, 128, 255);
                GPText.transform.localScale = new Vector3(1f, GPText.transform.localScale.y, 
                    GPText.transform.localScale.z);
                GPText.GetComponent<GUITexture>().texture = GPu;
                PlayerPrefs.Save();

                PLocked = false;
                PP.color = new Color32(128, 128, 128, 255);
                PPText.transform.localScale = new Vector3(1f, PPText.transform.localScale.y, 
                    PPText.transform.localScale.z);
                PPText.GetComponent<GUITexture>().texture = PPu;
                PlayerPrefs.Save();
            }
            else
            {
                GLocked = true;
                GP.color = Color.black;

                PLocked = true;
                PP.color = Color.black;
            }
        }

        // Level 3
        var CharUnlockedLevel3 = PlayerPrefs.GetString("Level3");
        if (CharUnlockedLevel3 != null)
        {
            if (CharUnlockedLevel3 == "Level3Completed")
            {
                ALocked = false;
                AP.color = new Color32(128, 128, 128, 255);
                APText.transform.localScale = new Vector3(1f, APText.transform.localScale.y, 
                    APText.transform.localScale.z);
                APText.GetComponent<GUITexture>().texture = APu;
                PlayerPrefs.Save();
            }
            else
            {
                ALocked = true;
                AP.color = Color.black;
            }
        }

        // Level 4 Astronaut Penguin.
        var CharUnlockedLevel4 = PlayerPrefs.GetString("Level4");
        if (CharUnlockedLevel4 != null)
        {
            if (CharUnlockedLevel4 == "Level4Completed")
            {
                AsLocked = false;
                AsP.color = new Color32(128, 128, 128, 255);
                AsPText.transform.localScale = new Vector3(1f, PPText.transform.localScale.y, 
                    PPText.transform.localScale.z);
                AsPText.GetComponent<GUITexture>().texture = AsPu;
                PlayerPrefs.Save();
            }
            else
            {
                AsLocked = true;
                AsP.color = Color.black;
            }
        }

        // Level 5 Vampire Penguin.
        var CharUnlockedLevel5 = PlayerPrefs.GetString("Level5");
        if (CharUnlockedLevel5 != null)
        {
            if (CharUnlockedLevel5 == "Level5Completed")
            {
                VLocked = false;
                VP.color = new Color32(128, 128, 128, 255);
                VPText.transform.localScale = new Vector3(1f, VPText.transform.localScale.y, 
                    VPText.transform.localScale.z);
                VPText.GetComponent<GUITexture>().texture = VPu;
                PlayerPrefs.Save();
            }
            else
            {
                VLocked = true;
                VP.color = Color.black;
            }
        }

        // Level 5 Blue Alien Penguin.
        var CharUnlockedLevel6 = PlayerPrefs.GetString("Level6");
        if (CharUnlockedLevel6 != null)
        {
            if (CharUnlockedLevel6 == "Level6Completed")
            {
                TPLocked = false;
                TP.color = new Color32(128, 128, 128, 255);
                TPText.transform.position = new Vector3(TPText.transform.position.x,
                    TPText.transform.position.y, TPText.transform.position.z);

                TPText.transform.localScale = new Vector3(0.75f, 
                    TPText.transform.localScale.y, TPText.transform.localScale.z);

                TPText.GetComponent<GUITexture>().texture = TPu;

                BaPLocked = false;
                BaP.color = new Color32(128, 128, 128, 255);
                BaPText.transform.position = new Vector3(BaPText.transform.position.x, 
                    BaPText.transform.position.y, BaPText.transform.position.z);

                BaPText.transform.localScale = new Vector3(0.75f, 0.225f, 
                    BaPText.transform.localScale.z);

                BaPText.GetComponent<GUITexture>().texture = BaPu;
                PlayerPrefs.Save();
            }
            else
            {
                BaPLocked = true;
                BaP.color = Color.black;

                TPLocked = true;
                TP.color = Color.black;
            }
        }


        // Regular Penguins.
        var SavedPenguin = PlayerPrefs.GetString("PenguinChanger");
        if (SavedPenguin != null)
        {
            if (SavedPenguin == "BluePenguin")
            {
                BluePenguinS = true;
                PlayerPrefs.Save();
            }
            if (SavedPenguin == "ZombiePenguin")
            {
                ZombiePenguinS = true;
                PlayerPrefs.Save();
            }
            if (SavedPenguin == "SkaterPenguin")
            {
                SkaterPenguinS = true;
                PlayerPrefs.Save();
            }
            if (SavedPenguin == "HackerPenguin")
            {
                HackerPenguinS = true;
                PlayerPrefs.Save();
            }
            if (SavedPenguin == "NinjaPenguin")
            {
                NinjaPenguinS = true;
                PlayerPrefs.Save();
            }
            if (SavedPenguin == "ClownPenguin")
            {
                ClownPenguinS = true;
                PlayerPrefs.Save();
            }
            if (SavedPenguin == "AlienPenguin")
            {
                AlienPenguinS = true;
                PlayerPrefs.Save();
            }
            if (SavedPenguin == "GoldenPenguin")
            {
                GoldenPenguinS = true;
                PlayerPrefs.Save();
            }
            if (SavedPenguin == "PiratePenguin")
            {
                PiratePenguinS = true;
                PlayerPrefs.Save();
            }
            if (SavedPenguin == "AstronautPenguin")
            {
                AstronautPenguinS = true;
                PlayerPrefs.Save();
            }
                if (SavedPenguin == "FrostyPenguin")
            {
                FrostyPenguinS = true;
                PlayerPrefs.Save();
            }
            if (SavedPenguin == "VampirePenguin")
            {
                VampirePenguinS = true;
                PlayerPrefs.Save();
            }
            if (SavedPenguin == "BlueAlienPenguin")
            {
                BlueAlienPenguinS = true;
                PlayerPrefs.Save();
            }
            if (SavedPenguin == "PumpkinPenguin")
            {
                PumpkinPenguinS = true;
                PlayerPrefs.Save();
            }
            if (SavedPenguin == "ThunderPenguin")
            {
                ThunderPenguinS = true;
                PlayerPrefs.Save();
            }
        }
        else if (SavedPenguin == null)
        {
            SavedPenguin = "Blue Penguin";
        }
    }

    // Save
    public void Save(string penguin)
    {
        PlayerPrefs.SetString("PenguinChanger", penguin);
        PlayerPrefs.Save();
        print(penguin);
    }

    // Update is called once per frame
    public void Update() 
    {
        // Tocuh settings.
        if (Input.touchCount > 0)
        {
            for (int i = 0; i < Input.touchCount; i++)
            {
                Touch t = Input.GetTouch(i);
                print(t);
            }
        }

        Vector2 charGridDisap = new Vector2(-4f, 4f);

        if (unlockPenguins.transform.position != new Vector3(0.5f, unlockPenguins.transform.position.y, 
            unlockPenguins.transform.position.z))
        {
            menu.transform.position = new Vector3(0.925f, menu.transform.position.y, 
                menu.transform.position.z);
        }
        else if (unlockPenguins.transform.position == new Vector3(0.5f, unlockPenguins.transform.position.y, 
            unlockPenguins.transform.position.z))
        {
            menu.transform.position = new Vector3(4f, menu.transform.position.y, 
                menu.transform.position.z);
        }

        /// -- If Locked Is True! -- \\\
        //
        /// Ninja Penguin.
        if (NLocked == true)
        {
            NLockedIcon.transform.position = new Vector3(c5, NLockedIcon.transform.position.y,
                NLockedIcon.transform.position.z);
        }
        else
        {
            NLockedIcon.transform.position = new Vector3(-2, NLockedIcon.transform.position.y, 
                NLockedIcon.transform.position.z);
        }

        /// Clown Penguin.
        if (CLocked == true)
        {
            CLockedIcon.transform.position = new Vector3(c1, CLockedIcon.transform.position.y, 
                CLockedIcon.transform.position.z);
        }
        else
        {
            CLockedIcon.transform.position = new Vector3(-3, CLockedIcon.transform.position.y, 
                CLockedIcon.transform.position.z);
        }

        /// Golden Penguin.
        if (GLocked == true)
        {
            GLockedIcon.transform.position = new Vector3(c3, GLockedIcon.transform.position.y,
                GLockedIcon.transform.position.z);
        }
        else
        {
            GLockedIcon.transform.position = new Vector3(-4, GLockedIcon.transform.position.y, 
                GLockedIcon.transform.position.z);
        }

        /// Alien Penguin.
        if (ALocked == true)
        {
            ALockedIcon.transform.position = new Vector3(c2, ALockedIcon.transform.position.y,
                ALockedIcon.transform.position.z);
        }
        else
        {
            ALockedIcon.transform.position = new Vector3(-4, ALockedIcon.transform.position.y, 
                ALockedIcon.transform.position.z);
        }

        /// Pirate Penguin.
        if (PLocked == true)
        {
            PLockedIcon.transform.position = new Vector3(c4, PLockedIcon.transform.position.y,
                PLockedIcon.transform.position.z);
        }
        else
        {
            PLockedIcon.transform.position = new Vector3(-4, PLockedIcon.transform.position.y, 
                PLockedIcon.transform.position.z);
        }

        /// Astronaut Penguin.
        if (AsLocked == true)
        {
            AsLockedIcon.transform.position = new Vector3(c5, AsLockedIcon.transform.position.y, 
                AsLockedIcon.transform.position.z);
        }
        else
        {
            AsLockedIcon.transform.position = new Vector3(-4, AsLockedIcon.transform.position.y, 
                AsLockedIcon.transform.position.z);
        }

        /// Frosty Penguin.
        if (FLocked == true)
        {
            FLockedIcon.transform.position = new Vector3(c1, FLockedIcon.transform.position.y, 
                FLockedIcon.transform.position.z);
        }
        else
        {
            FLockedIcon.transform.position = new Vector3(-4, FLockedIcon.transform.position.y, 
                FLockedIcon.transform.position.z);
        }

        /// Vampire Penguin.
        if (VLocked == true)
        {
            VLockedIcon.transform.position = new Vector3(c2, VLockedIcon.transform.position.y,
                VLockedIcon.transform.position.z);
        }
        else
        {
            VLockedIcon.transform.position = new Vector3(-4, VLockedIcon.transform.position.y, 
                VLockedIcon.transform.position.z);
        }

        /// Blue Alien Penguin.
        if (BaPLocked == true)
        {
            BaPLockedIcon.transform.position = new Vector3(c3, BaPLockedIcon.transform.position.y, 
                BaPLockedIcon.transform.position.z);
        }
        else
        {
            BaPLockedIcon.transform.position = new Vector3(-4, BaPLockedIcon.transform.position.y,
                BaPLockedIcon.transform.position.z);
        }

        /// Pumpkin Penguin
        if (PuPLocked == true)
        {
            PuPLockedIcon.transform.position = new Vector3(c4, PuPLockedIcon.transform.position.y,
                PuPLockedIcon.transform.position.z);
        }
        else
        {
            PuPLockedIcon.transform.position = new Vector3(-4, PuPLockedIcon.transform.position.y,
                PuPLockedIcon.transform.position.z);
        }

        /// Thunder Penguin
        if (TPLocked == true)
        {
            TPLockedIcon.transform.position = new Vector3(c5, TPLockedIcon.transform.position.y, 
                TPLockedIcon.transform.position.z);
        }
        else
        {
            TPLockedIcon.transform.position = new Vector3(-2, TPLockedIcon.transform.position.y, 
                TPLockedIcon.transform.position.z);
        }

        // End.


        // Saving.
        if (BluePenguinS == true)
        {
            Save("BluePenguin");
            BP.GetComponent<GUITexture>().color = new Color32(200, 200, 200, 128);
        }
        else
        {
            BP.GetComponent<GUITexture>().color = new Color32(128, 128, 128, 128);
        }

        if (ZombiePenguinS == true)
        {
            Save("ZombiePenguin");
            ZP.GetComponent<GUITexture>().color = new Color32(200, 200, 200, 128);
        }
        else
        {
            ZP.GetComponent<GUITexture>().color = new Color32(128, 128, 128, 128);
        }

        if (SkaterPenguinS == true)
        {
            Save("SkaterPenguin");
            SP.GetComponent<GUITexture>().color = new Color32(200, 200, 200, 128);
        }
        else
        {
            SP.GetComponent<GUITexture>().color = new Color32(128, 128, 128, 128);
        }

        if (HackerPenguinS == true)
        {
            Save("HackerPenguin");
            HP.GetComponent<GUITexture>().color = new Color32(200, 200, 200, 128);
        }
        else
        {
            HP.GetComponent<GUITexture>().color = new Color32(128, 128, 128, 128);
        }

        if (NinjaPenguinS)
        {
            Save("NinjaPenguin");
            NP.GetComponent<GUITexture>().color = new Color32(200, 200, 200, 128);
        }
        else
        {
            NP.GetComponent<GUITexture>().color = new Color32(128, 128, 128, 128);
            if (NLocked)
            {
                NP.GetComponent<GUITexture>().color = new Color32(0, 0, 0, 255);
                NPText.transform.localScale = new Vector3(0.6f, NPText.transform.localScale.y, 
                    NPText.transform.localScale.z);
                NPText.GetComponent<GUITexture>().texture = locked;
            }
            else
            {
                NP.color = new Color32(128, 128, 128, 255);
                NPText.transform.localScale = new Vector3(1f, NPText.transform.localScale.y, 
                    NPText.transform.localScale.z);
                NPText.GetComponent<GUITexture>().texture = NPu;
            }
        }

        if (ClownPenguinS)
        {
            Save("ClownPenguin");
            CP.GetComponent<GUITexture>().color = new Color32(200, 200, 200, 128);
        }
        else
        {
            CP.GetComponent<GUITexture>().color = new Color32(128, 128, 128, 128);
            if (CLocked)
            {
                CP.GetComponent<GUITexture>().color = new Color32(0, 0, 0, 255);
                CPText.transform.localScale = new Vector3(0.6f, CPText.transform.localScale.y, 
                    CPText.transform.localScale.z);
                CPText.GetComponent<GUITexture>().texture = locked;
            }
            else
            {
                CP.color = new Color32(128, 128, 128, 255);
                CPText.transform.localScale = new Vector3(1f, CPText.transform.localScale.y,
                    CPText.transform.localScale.z);
                CPText.GetComponent<GUITexture>().texture = CPu;
            }
        }

        if (AlienPenguinS)
        {
            Save("AlienPenguin");
            AP.GetComponent<GUITexture>().color = new Color32(200, 200, 200, 128);
        }
        else
        {
            AP.GetComponent<GUITexture>().color = new Color32(128, 128, 128, 128);
            if (ALocked)
            {
                AP.GetComponent<GUITexture>().color = new Color32(0, 0, 0, 255);
                APText.transform.localScale = new Vector3(0.6f, APText.transform.localScale.y,
                    APText.transform.localScale.z);
                APText.GetComponent<GUITexture>().texture = locked;
            }
            else
            {
                AP.color = new Color32(128, 128, 128, 255);
                APText.transform.localScale = new Vector3(1f, APText.transform.localScale.y, 
                    APText.transform.localScale.z);
                APText.GetComponent<GUITexture>().texture = APu;
            }
        }


        if (GoldenPenguinS)
        {
            Save("GoldenPenguin");
            GP.GetComponent<GUITexture>().color = new Color32(200, 200, 200, 128);
        }
        else
        {
            GP.GetComponent<GUITexture>().color = new Color32(128, 128, 128, 128);
            if (GLocked)
            {
                GP.GetComponent<GUITexture>().color = new Color32(0, 0, 0, 255);
                GPText.transform.localScale = new Vector3(0.6f, GPText.transform.localScale.y, 
                    GPText.transform.localScale.z);
                GPText.GetComponent<GUITexture>().texture = locked;
            }
            else
            {
                GP.GetComponent<GUITexture>().color = new Color32(128, 128, 128, 255);
                GPText.transform.localScale = new Vector3(1f, GPText.transform.localScale.y, 
                    GPText.transform.localScale.z);
                GPText.GetComponent<GUITexture>().texture = GPu;
            }
        }

        if (PiratePenguinS)
        {
            Save("PiratePenguin");
            PP.GetComponent<GUITexture>().color = new Color32(200, 200, 200, 128);
        }
        else
        {
            PP.GetComponent<GUITexture>().color = new Color32(128, 128, 128, 128);
            if (PLocked)
            {
                PP.GetComponent<GUITexture>().color = new Color32(0, 0, 0, 255);
                PPText.transform.localScale = new Vector3(0.6f, PPText.transform.localScale.y, 
                    PPText.transform.localScale.z);
                PPText.GetComponent<GUITexture>().texture = locked;
            }
            else
            {
                PP.color = new Color32(128, 128, 128, 255);
                PPText.transform.localScale = new Vector3(1f, PPText.transform.localScale.y, 
                    PPText.transform.localScale.z);
                PPText.GetComponent<GUITexture>().texture = PPu;
            }
        }

        if (AstronautPenguinS)
        {
            Save("AstronautPenguin");
            AsP.GetComponent<GUITexture>().color = new Color32(200, 200, 200, 128);
        }
        else
        {
            AsP.GetComponent<GUITexture>().color = new Color32(128, 128, 128, 128);
            if (AsLocked)
            {
                AsP.GetComponent<GUITexture>().color = new Color32(0, 0, 0, 255);
                AsPText.transform.localScale = new Vector3(0.6f, AsPText.transform.localScale.y,
                    AsPText.transform.localScale.z);
                AsPText.GetComponent<GUITexture>().texture = locked;
            }
            else
            {
                AsP.color = new Color32(128, 128, 128, 255);
                AsPText.transform.localScale = new Vector3(1f, AsPText.transform.localScale.y, 
                    AsPText.transform.localScale.z);
                AsPText.GetComponent<GUITexture>().texture = AsPu;
            }
        }

        if (FrostyPenguinS)
        {
            Save("FrostyPenguin");
            FP.GetComponent<GUITexture>().color = new Color32(200, 200, 200, 128);
        }
        else
        {
            FP.GetComponent<GUITexture>().color = new Color32(128, 128, 128, 128);
            if (FLocked)
            {
                FP.GetComponent<GUITexture>().color = new Color32(0, 0, 0, 255);
                FPText.transform.localScale = new Vector3(0.6f, FPText.transform.localScale.y, 
                    FPText.transform.localScale.z);
                FPText.GetComponent<GUITexture>().texture = locked;
            }
            else
            {
                FP.color = new Color32(128, 128, 128, 255);
                FPText.transform.localScale = new Vector3(1f, FPText.transform.localScale.y, 
                    FPText.transform.localScale.z);
                FPText.GetComponent<GUITexture>().texture = FPu;
            }
        }

        if (VampirePenguinS)
        {
            Save("VampirePenguin");
            VP.GetComponent<GUITexture>().color = new Color32(200, 200, 200, 128);
        }
        else
        {
            VP.GetComponent<GUITexture>().color = new Color32(128, 128, 128, 128);
            if (VLocked)
            {
                VP.GetComponent<GUITexture>().color = new Color32(0, 0, 0, 255);
                VPText.transform.localScale = new Vector3(0.6f, VPText.transform.localScale.y, 
                    VPText.transform.localScale.z);
                VPText.GetComponent<GUITexture>().texture = locked;
            }
            else
            {
                VP.color = new Color32(128, 128, 128, 255);
                VPText.transform.localScale = new Vector3(1f, VPText.transform.localScale.y, 
                    VPText.transform.localScale.z);
                VPText.GetComponent<GUITexture>().texture = VPu;
            }
        }

        if (BlueAlienPenguinS)
        {
            Save("BlueAlienPenguin");
            BaP.GetComponent<GUITexture>().color = new Color32(200, 200, 200, 128);
        }
        else
        {
            BaP.GetComponent<GUITexture>().color = new Color32(128, 128, 128, 128);
            if (BaPLocked)
            {
                BaP.GetComponent<GUITexture>().color = new Color32(0, 0, 0, 255);
                BaPText.transform.localScale = new Vector3(0.6f, 0.15f, BaPText.transform.localScale.z);
                BaPText.GetComponent<GUITexture>().texture = locked;
            }
            else
            {
                BaP.color = new Color32(128, 128, 128, 255);
                BaPText.transform.localScale = new Vector3(0.75f, 0.225f, BaPText.transform.localScale.z);
                BaPText.GetComponent<GUITexture>().texture = BaPu;
            }
        }

        if (PumpkinPenguinS)
        {
            Save("PumpkinPenguin");
            PuP.GetComponent<GUITexture>().color = new Color32(200, 200, 200, 128);
        }
        else
        {
            PuP.GetComponent<GUITexture>().color = new Color32(128, 128, 128, 128);
            if (PuPLocked)
            {
                PuP.GetComponent<GUITexture>().color = new Color32(0, 0, 0, 255);
                PuPText.transform.localScale = new Vector3(0.6f, PuPText.transform.localScale.y, 
                    PuPText.transform.localScale.z);
                PuPText.GetComponent<GUITexture>().texture = locked;
            }
            else
            {
                PuP.color = new Color32(128, 128, 128, 255);
                PuPText.transform.localScale = new Vector3(1f, PuPText.transform.localScale.y, 
                    PuPText.transform.localScale.z);
                PuPText.GetComponent<GUITexture>().texture = PuPu;
            }
        }

        if (ThunderPenguinS)
        {
            Save("ThunderPenguin");
            TP.GetComponent<GUITexture>().color = new Color32(200, 200, 200, 128);
        }
        else
        {
            TP.GetComponent<GUITexture>().color = new Color32(128, 128, 128, 128);
            if (TPLocked)
            {
                TP.GetComponent<GUITexture>().color = new Color32(0, 0, 0, 255);
                TPText.transform.localScale = new Vector3(0.6f, TPText.transform.localScale.y, 
                    TPText.transform.localScale.z);
                TPText.GetComponent<GUITexture>().texture = locked;
            }
            else
            {
                TP.color = new Color32(128, 128, 128, 255);
                TPText.transform.localScale = new Vector3(1f, TPText.transform.localScale.y, 
                    TPText.transform.localScale.z);
                TPText.GetComponent<GUITexture>().texture = TPu;
            }
        }
        // End.

        // On Touch
        if (Input.GetMouseButtonDown(0))
        {
            // Blue Penguin.
            if (BP.HitTest(Input.mousePosition, Camera.main))
            {
                BluePenguinS = true;
                SkaterPenguinS = ZombiePenguinS = HackerPenguinS = NinjaPenguinS = false;
                ClownPenguinS = AlienPenguinS = GoldenPenguinS = PiratePenguinS = AstronautPenguinS = false;
                FrostyPenguinS = VampirePenguinS = BlueAlienPenguinS = PumpkinPenguinS = ThunderPenguinS = false;
            }

            // Zombie Penguin.
            if (ZP.HitTest(Input.mousePosition, Camera.main))
            {
                ZombiePenguinS = true;
                SkaterPenguinS = BluePenguinS = HackerPenguinS = NinjaPenguinS = false;
                ClownPenguinS = AlienPenguinS = GoldenPenguinS = PiratePenguinS = AstronautPenguinS = false;
                FrostyPenguinS = VampirePenguinS = BlueAlienPenguinS = PumpkinPenguinS = ThunderPenguinS = false;
            }

            // Skater Penguin.
            if (SP.HitTest(Input.mousePosition, Camera.main))
            {
                SkaterPenguinS = true;
                BluePenguinS = ZombiePenguinS = HackerPenguinS = NinjaPenguinS = false;
                ClownPenguinS = AlienPenguinS = GoldenPenguinS = PiratePenguinS = AstronautPenguinS = false;
                FrostyPenguinS = VampirePenguinS = BlueAlienPenguinS = PumpkinPenguinS = ThunderPenguinS = false;
            }

            //Hacker Penguin.
            if (HP.HitTest(Input.mousePosition, Camera.main))
            {
                HackerPenguinS = true;
                SkaterPenguinS = ZombiePenguinS = BluePenguinS = NinjaPenguinS = false;
                ClownPenguinS = AlienPenguinS = GoldenPenguinS = PiratePenguinS = AstronautPenguinS = false;
                FrostyPenguinS = VampirePenguinS = BlueAlienPenguinS = PumpkinPenguinS = ThunderPenguinS = false;
            }




            // Hide Button, Penguins Unlock.
            if (hideBtn.HitTest(Input.mousePosition, Camera.main))
            {
                unlockPenguins.transform.position = new Vector3(-2f, unlockPenguins.transform.position.y, 
                    unlockPenguins.transform.position.z);
                blackRect.color = new Color32(0, 0, 0, 0);
                charGrid.transform.position = new Vector2(0.5f, 0.5f);
            }


            

            //Ninja Penguin.
            if (NLocked == false)
            {
                if (NP.HitTest(Input.mousePosition, Camera.main))
                {
                    NinjaPenguinS = true;
                    SkaterPenguinS = ZombiePenguinS = HackerPenguinS = BluePenguinS = false;
                    ClownPenguinS = AlienPenguinS = GoldenPenguinS = PiratePenguinS = AstronautPenguinS = false;
                    FrostyPenguinS = VampirePenguinS = BlueAlienPenguinS = PumpkinPenguinS = ThunderPenguinS = false;
                }
            }
            else
            {
                NP.GetComponent<GUITexture>().color = new Color32(0, 0, 0, 255);
                if (NP.HitTest(Input.mousePosition, Camera.main))
                {
                    unlockPenguins.transform.position = new Vector3(0.5f, unlockPenguins.transform.position.y, 
                        unlockPenguins.transform.position.z);
                    blackRect.color = new Color32(0, 0, 0, 50);
                    charGrid.transform.position = new Vector2(-4f, charGrid.transform.position.y);
                }
            }


            // Clown Penguin.
            if (CLocked == false)
            {
                if (CP.HitTest(Input.mousePosition, Camera.main))
                {
                    ClownPenguinS = true;
                    SkaterPenguinS = ZombiePenguinS = HackerPenguinS = NinjaPenguinS = false;
                    BluePenguinS = AlienPenguinS = GoldenPenguinS = PiratePenguinS = AstronautPenguinS = false;
                    FrostyPenguinS = VampirePenguinS = BlueAlienPenguinS = PumpkinPenguinS = ThunderPenguinS = false;
                }
            }
            else
            {
                CP.GetComponent<GUITexture>().color = new Color32(0, 0, 0, 255);
                if (CP.HitTest(Input.mousePosition, Camera.main))
                {
                    unlockPenguins.transform.position = new Vector3(0.5f, unlockPenguins.transform.position.y, 
                        unlockPenguins.transform.position.z);
                    blackRect.color = new Color32(0, 0, 0, 50);
                    charGrid.transform.position = new Vector2(-4f, charGrid.transform.position.y);
                }
            }

            // Golden Penguin.
            if (GLocked == false)
            {
                if (GP.HitTest(Input.mousePosition, Camera.main))
                {
                    GoldenPenguinS = true;
                    SkaterPenguinS = ZombiePenguinS = HackerPenguinS = NinjaPenguinS = false;
                    ClownPenguinS = AlienPenguinS = BluePenguinS = PiratePenguinS = AstronautPenguinS = false;
                    FrostyPenguinS = VampirePenguinS = BlueAlienPenguinS = PumpkinPenguinS = ThunderPenguinS = false;
                }
            }
            else
            {
                GP.GetComponent<GUITexture>().color = new Color32(0, 0, 0, 255);
                if (GP.HitTest(Input.mousePosition, Camera.main))
                {
                    unlockPenguins.transform.position = new Vector3(0.5f, unlockPenguins.transform.position.y, 
                        unlockPenguins.transform.position.z);
                    blackRect.color = new Color32(0, 0, 0, 50);
                    charGrid.transform.position = new Vector2(-4f, charGrid.transform.position.y);
                }
            }

            // Alien Penguin.
            if (ALocked == false)
            {
                if (AP.HitTest(Input.mousePosition, Camera.main))
                {
                    AlienPenguinS = true;
                    SkaterPenguinS = ZombiePenguinS = HackerPenguinS = NinjaPenguinS = false;
                    ClownPenguinS = BluePenguinS = GoldenPenguinS = PiratePenguinS = AstronautPenguinS = false;
                    FrostyPenguinS = VampirePenguinS = BlueAlienPenguinS = PumpkinPenguinS = ThunderPenguinS = false;
                }
            }
            else
            {
                AP.GetComponent<GUITexture>().color = new Color32(0, 0, 0, 255);
                if (AP.HitTest(Input.mousePosition, Camera.main))
                {
                    unlockPenguins.transform.position = new Vector3(0.5f, unlockPenguins.transform.position.y, 
                        unlockPenguins.transform.position.z);
                    blackRect.color = new Color32(0, 0, 0, 50);
                    charGrid.transform.position = new Vector2(-4f, charGrid.transform.position.y);
                }
            }

            // Pirate Penguin.
            if (PLocked == false)
            {
                if (PP.HitTest(Input.mousePosition, Camera.main))
                {
                    PiratePenguinS = true;
                    SkaterPenguinS = ZombiePenguinS = HackerPenguinS = NinjaPenguinS = false;
                    ClownPenguinS = AlienPenguinS = GoldenPenguinS = BluePenguinS = AstronautPenguinS = false;
                    FrostyPenguinS = VampirePenguinS = BlueAlienPenguinS = PumpkinPenguinS = ThunderPenguinS = false;
                }
            }
            else
            {
                PP.GetComponent<GUITexture>().color = new Color32(0, 0, 0, 255);
                if (PP.HitTest(Input.mousePosition, Camera.main))
                {
                    unlockPenguins.transform.position = new Vector3(0.5f, unlockPenguins.transform.position.y, 
                        unlockPenguins.transform.position.z);
                    blackRect.color = new Color32(0, 0, 0, 50);
                    charGrid.transform.position = new Vector2(-4f, charGrid.transform.position.y);
                }
            }

            // Astronaut Penguin.
            if (AsLocked == false)
            {
                if (AsP.HitTest(Input.mousePosition, Camera.main))
                {
                    AstronautPenguinS = true;
                    SkaterPenguinS = ZombiePenguinS = HackerPenguinS = NinjaPenguinS = false;
                    ClownPenguinS = AlienPenguinS = GoldenPenguinS = PiratePenguinS = BluePenguinS = false;
                    FrostyPenguinS = VampirePenguinS = BlueAlienPenguinS = PumpkinPenguinS = ThunderPenguinS = false;
                }
            }
            else
            {
                AsP.GetComponent<GUITexture>().color = new Color32(0, 0, 0, 255);
                if (AsP.HitTest(Input.mousePosition, Camera.main))
                {
                    unlockPenguins.transform.position = new Vector3(0.5f, unlockPenguins.transform.position.y, 
                        unlockPenguins.transform.position.z);
                    blackRect.color = new Color32(0, 0, 0, 50);
                    charGrid.transform.position = new Vector2(-4f, charGrid.transform.position.y);
                }
            }

            // Astronaut Penguin.
            if (FLocked == false)
            {
                if (FP.HitTest(Input.mousePosition, Camera.main))
                {
                    FrostyPenguinS = true;
                    SkaterPenguinS = ZombiePenguinS = HackerPenguinS = NinjaPenguinS = false;
                    ClownPenguinS = AlienPenguinS = GoldenPenguinS = PiratePenguinS = AstronautPenguinS = false;
                    BluePenguinS = VampirePenguinS = BlueAlienPenguinS = PumpkinPenguinS = ThunderPenguinS = false;
                }
            }
            else
            {
                FP.GetComponent<GUITexture>().color = new Color32(0, 0, 0, 255);
                if (FP.HitTest(Input.mousePosition, Camera.main))
                {
                    unlockPenguins.transform.position = new Vector3(0.5f, unlockPenguins.transform.position.y, 
                        unlockPenguins.transform.position.z);
                    blackRect.color = new Color32(0, 0, 0, 50);
                    charGrid.transform.position = new Vector2(-4f, charGrid.transform.position.y);
                }
            }

            // Vampire Penguin.
            if (VLocked == false)
            {
                if (VP.HitTest(Input.mousePosition, Camera.main))
                {
                    VampirePenguinS = true;
                    SkaterPenguinS = ZombiePenguinS = HackerPenguinS = NinjaPenguinS = false;
                    ClownPenguinS = AlienPenguinS = GoldenPenguinS = PiratePenguinS = AstronautPenguinS = false;
                    FrostyPenguinS = BluePenguinS = BlueAlienPenguinS = PumpkinPenguinS = ThunderPenguinS = false;
                }
            }
            else
            {
                VP.GetComponent<GUITexture>().color = new Color32(0, 0, 0, 255);
                if (VP.HitTest(Input.mousePosition, Camera.main))
                {
                    unlockPenguins.transform.position = new Vector3(0.5f, unlockPenguins.transform.position.y, 
                        unlockPenguins.transform.position.z);
                    blackRect.color = new Color32(0, 0, 0, 50);
                    charGrid.transform.position = new Vector2(-4f, charGrid.transform.position.y);
                }
            }

            // Blue Alien Penguin.
            if (BaPLocked == false)
            {
                if (BaP.HitTest(Input.mousePosition, Camera.main))
                {
                    BlueAlienPenguinS = true;
                    SkaterPenguinS = ZombiePenguinS = HackerPenguinS = NinjaPenguinS = false;
                    ClownPenguinS = AlienPenguinS = GoldenPenguinS = PiratePenguinS = AstronautPenguinS = false;
                    FrostyPenguinS = BluePenguinS = VampirePenguinS = PumpkinPenguinS = ThunderPenguinS = false;
                }
            }
            else
            {
                BaP.GetComponent<GUITexture>().color = new Color32(0, 0, 0, 255);
                if (BaP.HitTest(Input.mousePosition, Camera.main))
                {
                    unlockPenguins.transform.position = new Vector3(0.5f, unlockPenguins.transform.position.y, 
                        unlockPenguins.transform.position.z);
                    blackRect.color = new Color32(0, 0, 0, 50);
                    charGrid.transform.position = new Vector2(-4f, charGrid.transform.position.y);
                }
            }

            // Pumpkin Penguin.
            if (PuPLocked == false)
            {
                if (PuP.HitTest(Input.mousePosition, Camera.main))
                {
                    PumpkinPenguinS = true;
                    SkaterPenguinS = ZombiePenguinS = HackerPenguinS = NinjaPenguinS = false;
                    ClownPenguinS = AlienPenguinS = GoldenPenguinS = PiratePenguinS = AstronautPenguinS = false;
                    FrostyPenguinS = BluePenguinS = VampirePenguinS = BlueAlienPenguinS = ThunderPenguinS = false;
                }
            }
            else
            {
                PuP.GetComponent<GUITexture>().color = new Color32(0, 0, 0, 255);
                if (PuP.HitTest(Input.mousePosition, Camera.main))
                {
                    unlockPenguins.transform.position = new Vector3(0.5f, unlockPenguins.transform.position.y, 
                        unlockPenguins.transform.position.z);
                    blackRect.color = new Color32(0, 0, 0, 50);
                    charGrid.transform.position = new Vector2(-4f, charGrid.transform.position.y);
                }
            }

            // Thunder Penguin.
            if (TPLocked == false)
            {
                if (TP.HitTest(Input.mousePosition, Camera.main))
                {
                    ThunderPenguinS = true;
                    SkaterPenguinS = ZombiePenguinS = HackerPenguinS = NinjaPenguinS = false;
                    ClownPenguinS = AlienPenguinS = GoldenPenguinS = PiratePenguinS = AstronautPenguinS = false;
                    FrostyPenguinS = BluePenguinS = VampirePenguinS = BlueAlienPenguinS = PumpkinPenguinS = false;
                }
            }
            else
            {
                TP.GetComponent<GUITexture>().color = new Color32(0, 0, 0, 255);
                if (TP.HitTest(Input.mousePosition, Camera.main))
                {
                    unlockPenguins.transform.position = new Vector3(0.5f, unlockPenguins.transform.position.y, 
                        unlockPenguins.transform.position.z);
                    blackRect.color = new Color32(0, 0, 0, 50);
                    charGrid.transform.position = new Vector2(-4f, charGrid.transform.position.y);
                }
            }
        }
    }
}

