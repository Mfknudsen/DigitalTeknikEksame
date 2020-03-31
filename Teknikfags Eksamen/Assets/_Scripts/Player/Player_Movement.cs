#region Systems
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
#endregion

public class Player_Movement : MonoBehaviour
{
    #region public DATA
    [Header("Required Input:")]
    public GameObject VR_Object;
    public float moveSpeed = 5;
    [Tooltip("Used to determin which hand is used")]
    public SteamVR_Input_Sources LeftHand;
    [Tooltip("Used to determin which hand is used")]
    public SteamVR_Input_Sources RightHand;
    public bool TrackPadMovementActive = true;
    #endregion

    #region private DATA
    Vector3 Move;
    SteamVR_Action_Vector2 Trackpad;
    #endregion

    private void Awake()
    {
        if (!VR_Object.activeSelf)
        {
            Trackpad = SteamVR_Input.GetVector2Action("TrackPad");
        }
    }

    private void FixedUpdate()
    {
        if (!VR_Object.activeSelf && Trackpad != null)
        {
            Move = new Vector3(Trackpad.axis.x, 0, Trackpad.axis.y) * moveSpeed * Time.deltaTime;
            transform.position += Move;
        }
    }
}
