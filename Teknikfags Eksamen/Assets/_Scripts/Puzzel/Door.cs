#region Systems
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#endregion

public class Door : MonoBehaviour
{
    //Setting up the public values and input.
    #region public DATA
    [Header("Required Input:")]  //Input that is required for the script to work.
    public bool OpenByRotation;
    public Vector3 OpenValue;  //The position that the door will move to if it is opend.
    public float doorMoveSpeed = 0.25f;  //How fast the door will move when moving to a new position.
    public GameObject ToOpenBy;
    [Header("Optional Input")]  //Input that can be change from the inspector.
    public bool active = true;  //If the door has been activated.
    [HideInInspector]
    public Vector3 OpenTransform;  //Where the door will be when it is opend.
    [HideInInspector]
    public Vector3 ClosedTransform;  //Where the door will be when closed.
    [HideInInspector]
    public Vector3 targetTransform;  //Where the door will be trying to go.
    [HideInInspector]
    public bool byProcent = false;  //If the door will be opening by procent or by active.
    #endregion

    void Start()  //When the script start.
    {
        if (byProcent == false)  //If the door isnt beening opend by procent then it will start either opend or closed.
        {
            //Setting up the positions
            OpenTransform = OpenValue;
            if (!OpenByRotation)
                ClosedTransform = transform.position;
            else
                ClosedTransform = transform.rotation.eulerAngles;

            if (active == true)  //If it is active then it will be opend if not then it will be closed.
            {
                if (!OpenByRotation)
                    transform.position = OpenTransform;
                else
                    transform.rotation = Quaternion.Euler(OpenTransform);

                targetTransform = OpenTransform;
            }
            else
            {
                if (!OpenByRotation)
                    transform.position = ClosedTransform;
                else
                    transform.rotation = Quaternion.Euler(ClosedTransform);

                targetTransform = ClosedTransform;
            }
        }
        else  //If the door is opend by procent then it will always be active.
        {
            active = true;
        }
    }

    void Update()
    {
        CheckActive();
        MoveDoor();  //Move the door.
    }

    public void MoveDoor()  //Will move the door.
    {
        if (!OpenByRotation)
        {
            if (transform.position != targetTransform)  //If the door hasnt reached it new position then it will continue to move towards it.
            {
                transform.position = Vector3.Lerp(transform.position, targetTransform, doorMoveSpeed * Time.deltaTime);  //Moving the door towards the taget location.
            }
        }
        else
        {
            if (transform.eulerAngles != targetTransform)
            {
                transform.rotation = Quaternion.Euler(Vector3.Lerp(transform.rotation.eulerAngles, targetTransform, doorMoveSpeed * Time.deltaTime));
            }
        }
    }

    public void SwitchOpenClosed()  //Will open or close the door based on the value of active.
    {
        if (active == true)  //If it is active then it will open.
        {
            targetTransform = OpenTransform;
        }
        else  //If it isnt active then it will close.
        {
            targetTransform = ClosedTransform;
        }
    }

    void CheckActive()
    {
        if (ToOpenBy.GetComponent<Keyhole>() != null)
        {
            if (ToOpenBy.GetComponent<Keyhole>().active)
                active = true;
            else
                active = false;
        }
        else if (ToOpenBy.GetComponent<Buttom>() != null)
        {
            if (ToOpenBy.GetComponent<Buttom>().active)
                active = true;
            else
                active = false;
        }
        else if (ToOpenBy.GetComponent<Lever>() != null)
        {
            if (ToOpenBy.GetComponent<Lever>().active)
                active = true;
            else
                active = false;
        }
    }
}
