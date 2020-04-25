#region Systems
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
#endregion

public class WireCutter : MonoBehaviour
{
    #region Public Data
    [Header("VR Resources")]
    public SteamVR_Input_Sources currentHand;
    public SteamVR_Input_Sources LeftHand;
    public SteamVR_Input_Sources RightHand;
    public SteamVR_Behaviour_Pose trackedHandLeft;
    public SteamVR_Behaviour_Pose trackedHandRight;
    public bool VR = false;
    public int Show = 0;
    #endregion

    #region Private Data
    private List<Wire> WiresInRange = new List<Wire>();
    private bool IsInHand = false;
    [Header("VR Resources")]
    private SteamVR_Action_Boolean Trigger;
    #endregion

    private void Start()
    {
        Trigger = SteamVR_Input.GetBooleanAction("Trigger");
    }

    private void Update()
    {
        Show = WiresInRange.Count;

        if (IsInHand)
        {
            if (Trigger.GetActive(currentHand))
            {
                Wire W = WiresInRange[0];
                float Dist = Vector3.Distance(transform.position, W.transform.position);

                foreach (Wire w in WiresInRange)
                {
                    float dist = Vector3.Distance(transform.position, w.transform.position);

                    if (Dist > dist)
                    {
                        W = w;
                        Dist = dist;
                    }
                }

                CutWire(W);
            }
            else if (!VR)
            {
                if (Input.GetKeyDown(KeyCode.Alpha1))
                {
                    Wire W = WiresInRange[0];
                    float Dist = Vector3.Distance(transform.position, W.transform.position);

                    foreach (Wire w in WiresInRange)
                    {
                        float dist = Vector3.Distance(transform.position, w.transform.position);

                        if (Dist > dist)
                        {
                            W = w;
                            Dist = dist;
                        }
                    }

                    W.CutWire();
                }
            }
        }

        if (!IsInHand && WiresInRange.Count > 0)
        {
            foreach (Wire W in WiresInRange)
                W.InRange = 0;

            WiresInRange = new List<Wire>();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Wire W = other.GetComponentInParent(typeof(Wire)) as Wire;

        if (W != null)
        {
            if (!W.CanBeFixed && W.Active)
            {
                W.InRange++;
                WiresInRange.Add(W);
            }
            else if (W.CanBeFixed)
            {
                W.InRange++;
                WiresInRange.Add(W);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Wire W = other.GetComponentInParent(typeof(Wire)) as Wire;

        if (W != null)
        {
            W.InRange--;
            WiresInRange.Remove(W);
        }
    }

    private void CutWire(Wire W)
    {
        W.CutWire();
    }

    void OnDetachedFromHand()
    {
        IsInHand = false;
    }

    void OnAttachedToHand()
    {
        if (trackedHandLeft != null)
        {
            if (Vector3.Distance(transform.position, trackedHandLeft.transform.position) < Vector3.Distance(transform.position, trackedHandRight.transform.position))
            {
                currentHand = LeftHand;
            }
            else
            {
                currentHand = RightHand;
            }
        }

        IsInHand = true;
    }
}
