using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CamController : MonoBehaviour
{
    //Definitions
    [Header("Internal stuff")]
    public GameObject Cam;
    public Camera Cam2;
    public float Force;
    public bool IsFollowing = false;

    [Header("Level Bounds")]
    public float LeftX = -3.41f;
    public float RightX = 124.8f;
    public float BottomY = -4.09f;
    public float TopY = 67.6f;
    public float ResetAmmount = 0.1f;

    [Header("Zooming")]
    public float ZoomSensitivity = 0.5f;
    public float ZoomLimitIn = 0.0f;
    public float ZoomLimitOut = 20.0f;

    Vector3 _mousePositionInWorld;


    // Update is called once per frame
    void Update()
    {
        _mousePositionInWorld = Cam2.ScreenToWorldPoint(Input.mousePosition);
        if (!IsFollowing)
        {
                    if (Input.GetKey(KeyCode.W))
                    {
                        Cam.transform.position = new Vector3(Cam.transform.position.x, Cam.transform.position.y + (Force * (Cam2.orthographicSize / 8)), -10);
                    }
                    else if (Input.GetKey(KeyCode.S))
                    {
                        Cam.transform.position = new Vector3(Cam.transform.position.x, Cam.transform.position.y - (Force * (Cam2.orthographicSize / 8)), -10);
                    }
                    if (Input.GetKey(KeyCode.A))
                    {
                        Cam.transform.position = new Vector3(Cam.transform.position.x - (Force * (Cam2.orthographicSize / 8)), Cam.transform.position.y, -10);
                    }
                    else if (Input.GetKey(KeyCode.D))
                    {
                        Cam.transform.position = new Vector3(Cam.transform.position.x + (Force * (Cam2.orthographicSize / 8)), Cam.transform.position.y, -10);
                    }
                    /* if (Input.GetMouseButton(2)) {
                        Cam.transform.position = new Vector3(Cam.transform.position.x, Cam.transform.position.y, -10) + _mousePositionInWorld;
                    } */
            if (Cam.transform.position.x < LeftX)
            {
                Cam.transform.position = new Vector3(LeftX + ResetAmmount, Cam.transform.position.y, -10);
            }
            if (Cam.transform.position.x > RightX)
            {
                Cam.transform.position = new Vector3(RightX - ResetAmmount, Cam.transform.position.y, -10);
            }
            if (Cam.transform.position.y < BottomY)
            {
                Cam.transform.position = new Vector3(Cam.transform.position.x, BottomY + ResetAmmount, -10);
            }
            if (Cam.transform.position.y > TopY)
            {
                Cam.transform.position = new Vector3(Cam.transform.position.x, TopY - ResetAmmount, -10);
            }
            
        }
        Cam2.orthographicSize += -Input.GetAxis("Mouse ScrollWheel") * (ZoomSensitivity * Cam2.orthographicSize);
        if (Cam2.orthographicSize > ZoomLimitOut)
        {
            Cam2.orthographicSize = ZoomLimitOut - ResetAmmount;
        }
        if (Cam2.orthographicSize < ZoomLimitIn)
        {
            Cam2.orthographicSize = ZoomLimitIn + ResetAmmount;
        }
    }

    
}