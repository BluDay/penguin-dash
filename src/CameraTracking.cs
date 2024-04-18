// CameraTracking.cs
// 
// Penguin Dash
// Copyrights @ 2014- Bachir Bouchemla

using UnityEngine;
using System.Collections;

public class CameraTracking : MonoBehaviour
{
    // Variables
    PlayerSettings p;
    public GameObject player;
    public GameObject ground;
    public GameObject SkyBackground;
    public GameObject OuterSpace;
    public Transform target;
    public Vector3 velocity = Vector3.zero;
    public float smoothTime;
    public float verticalMin;
    public bool verticalMinEnabled;
    private bool a16by9, a4by3, a3by2, 
    a16by10, a15by9, aspectUndetected;

    void Start()
    {
        p = player.GetComponent<PlayerSettings>();
    }

    void FixedUpdate() 
    {

        // Follows moving object without smooth damp.
        if (p.Dead == false)
        {
            transform.position = new Vector3(ground.transform.position.x + 0.9f,
            transform.position.y, transform.position.z);
        }
        else
        {
            transform.position = new Vector3(ground.transform.position.x + 0.5f,
                        transform.position.y, transform.position.z);
        }

        // Aspect Ratios
        if (a16by9)
        {
            Camera.main.orthographicSize = 5.3f;
            verticalMin = 0f;
            SkyBackground.transform.localScale = new Vector3(2, 1.7f, 1);
            OuterSpace.transform.localPosition = new Vector3(OuterSpace.transform.localPosition.x,
                55.3f, OuterSpace.transform.localPosition.z);
        }
        if (a16by10)
        {
            Camera.main.orthographicSize = 5.85f;
            verticalMin = 0.5f;
            SkyBackground.transform.localScale = new Vector3(2, 1.95f, 1);
            OuterSpace.transform.localPosition = new Vector3(OuterSpace.transform.localPosition.x,
                55.75f, OuterSpace.transform.localPosition.z);
        }
        if (a15by9)
        {
            Camera.main.orthographicSize = 5.65f;
            verticalMin = 0.25f;
            SkyBackground.transform.localScale = new Vector3(2, 1.95f, 1);
            OuterSpace.transform.localPosition = new Vector3(OuterSpace.transform.localPosition.x,
                55.75f, OuterSpace.transform.localPosition.z);
        }
        if (a4by3)
        {
            Camera.main.orthographicSize = 7f;
            verticalMin = 1.5f;
            SkyBackground.transform.localScale = new Vector3(2, 2.2f, 1);
            OuterSpace.transform.localPosition = new Vector3(OuterSpace.transform.localPosition.x,
                57f, OuterSpace.transform.localPosition.z);
        }
        if (a3by2)
        {
            Camera.main.orthographicSize = 6.25f;
            verticalMin = 1f;
            SkyBackground.transform.localScale = new Vector3(2, 1.95f, 1);
            OuterSpace.transform.localPosition = new Vector3(OuterSpace.transform.localPosition.x,
                56f, OuterSpace.transform.localPosition.z);
        }

        if (a16by9 == false && a16by10 == false && a15by9 == false &&
            a3by2 == false && a4by3 == false)
        {
            aspectUndetected = true;
        }
        else
        {
            aspectUndetected = false;
        }

        /// Aspect Ratio.
        // 16:9
        if (Camera.main.aspect == 16f / 9f || 
            Camera.main.aspect == 16f / 8f)
        {
            a16by9 = true;
        }
        else
        {
            a16by9 = false;
        }
        // 4:3
        if (Camera.main.aspect == 4f / 3f || 
            Camera.main.aspect == 4f / 2f)
        {
            a4by3 = true;
        }
        else
        {
            a4by3 = false;
        }
        // 3:2
        if (Camera.main.aspect == 3f / 2f || 
            Camera.main.aspect == 3f / 1f)
        {
            a3by2 = true;
        }
        else
        {
            a3by2 = false;
        }
        // 16:10
        if (Camera.main.aspect == 16f / 10f || 
            Camera.main.aspect == 16f / 11f || 
            Camera.main.aspect == 15f / 10f)
        {
            a16by10 = true;
        }
        else
        {
            a16by10 = false;
        }
        // 15:9
        if (Camera.main.aspect == 15f / 9f)
        {
            a15by9 = true;
        }
        else
        {
            a15by9 = false;
        }

        if (target)
        {
            // Offset
            Vector3 targetPosition = target.position;
            targetPosition.z = transform.position.z;

            if (verticalMinEnabled)
            { 
                /// Aspect Ratio.
                // 4:3
                if (a4by3)
                {
                    if (target.position.y >= 6f)
                    {
                        targetPosition.y = Mathf.Clamp(target.position.y + 1.5f, 
                            verticalMin, target.position.y);
                    }
                    if (target.position.y <= 4f)
                    {
                        targetPosition.y = Mathf.Clamp(target.position.y, 
                            verticalMin, target.position.y);
                    }
                }
                // 3:2
                if (a3by2)
                {
                    if (target.position.y >= 6f)
                    {
                        targetPosition.y = Mathf.Clamp(target.position.y + 1.25f, 
                            verticalMin, target.position.y);
                    }
                    if (target.position.y <= 4)
                    {
                        targetPosition.y = Mathf.Clamp(target.position.y, 
                            verticalMin, target.position.y);
                    }
                }
                // 16:9
                if (a16by9)
                {
                    if (target.position.y >= 2.2f)
                    {
                        targetPosition.y = Mathf.Clamp(target.position.y - 0.2f, 
                            verticalMin, target.position.y);
                    }
                    if (target.position.y <= 2)
                    {
                        targetPosition.y = Mathf.Clamp(target.position.y, 
                            verticalMin, target.position.y);
                    }
                }
                // 16:10
                if (a16by10)
                {
                    if (target.position.y >= 2.2f)
                    {
                        targetPosition.y = Mathf.Clamp(target.position.y - 0.2f, 
                            verticalMin, target.position.y);
                    }
                    if (target.position.y <= 2)
                    {
                        targetPosition.y = Mathf.Clamp(target.position.y, 
                            verticalMin, target.position.y);
                    }
                }
                // 15:9
                if (a15by9)
                {
                    if (target.position.y >= 2.2f)
                    {
                        targetPosition.y = Mathf.Clamp(target.position.y - 0.2f, 
                            verticalMin, target.position.y);
                    }
                    if (target.position.y <= 2)
                    {
                        targetPosition.y = Mathf.Clamp(target.position.y, 
                            verticalMin, target.position.y);
                    }
                }
                // Aspect Ratio Undetected.
                if (aspectUndetected)
                {
                    if (target.position.y >= 2.2f)
                    {
                        targetPosition.y = Mathf.Clamp(target.position.y - 0.2f, 
                            verticalMin, target.position.y);
                    }
                    if (target.position.y <= 2)
                    {
                        targetPosition.y = Mathf.Clamp(target.position.y, 
                            verticalMin, target.position.y);
                    }
                }
            }

            // Follows player
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);

        }
    }
}
