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
    public Buttom B;
    #endregion

    #region Private Data
    private List<Wire> WiresInRange = new List<Wire>();
    private bool IsInHand = false;
    [Header("VR Resources")]
    private SteamVR_Action_Boolean Trigger;
    private Wire closestWire;
    private bool ReadyToCut = true;
    private RotateTowardsCamera RTC;
    #endregion

    private void Start()
    {
        Trigger = SteamVR_Input.GetBooleanAction("Trigger");
        RTC = GetComponentInChildren<RotateTowardsCamera>();
    }

    private void Update()
    {
        Show = WiresInRange.Count;

        if (IsInHand && ReadyToCut)
        {
            if (Trigger.GetActive(currentHand))
            {
                CutWire(closestWire);
                StartCoroutine(DelayNextCut());
            }
            else if (!VR)
            {
                if (Input.GetKeyDown(KeyCode.Alpha1))
                {
                    CutWire(closestWire);
                    StartCoroutine(DelayNextCut());
                }
            }
        }

        if (WiresInRange.Count > 0)
        {
            Wire W = WiresInRange[0];
            float Dist = Vector3.Distance(transform.position, W.transform.position);

            foreach (Wire w in WiresInRange)
            {
                float dist = Vector3.Distance(transform.position, w.transform.position);
                w.InRange.Remove(this);

                if (Dist > dist && (w.CanBeFixed && !w.active || w.active))
                {
                    W = w;
                    Dist = dist;
                }
            }

            closestWire = W;

            closestWire.InRange.Add(this);
        }

        if (!IsInHand && WiresInRange.Count > 0)
        {
            foreach (Wire w in WiresInRange)
                w.InRange.Remove(this);

            WiresInRange = new List<Wire>();
        }

        if (B != null)
        {
            if (ReadyToCut && B.active)
            {
                CutWire(closestWire);

                ReadyToCut = false;
            }
            else if (!B.active)
            {
                ReadyToCut = true;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Wire W = other.GetComponentInParent(typeof(Wire)) as Wire;

        if (W != null)
        {
            if (!W.CanBeFixed && W.active)
            {
                WiresInRange.Add(W);
            }
            else if (W.CanBeFixed)
            {
                WiresInRange.Add(W);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Wire W = other.GetComponentInParent(typeof(Wire)) as Wire;

        if (W != null)
        {
            W.InRange.Remove(this);
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

        RTC.EndNow();
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

        RTC.StartNow();
    }

    IEnumerator DelayNextCut()
    {
        ReadyToCut = false;

        yield return new WaitForSeconds(0.2f);

        ReadyToCut = true;
    }
}
