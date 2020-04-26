#region Systems
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon;
using Photon.Pun;
using Photon.Realtime;
#endregion

public class MP : MonoBehaviourPunCallbacks
{
    #region Private Data
    Login L = null;
    bool GameIsReady = false;
    #endregion

    #region Public Data
    public bool CheckForVR = true;
    public GameObject VR_Checker;
    public GameObject Player1, Player2;
    #endregion

    private void Start()
    {
        PhotonNetwork.OfflineMode = false;
        PhotonNetwork.AutomaticallySyncScene = true;
        PhotonNetwork.ConnectUsingSettings();

        if (L == null)
        {
            L = GetComponent<Login>();
        }

        StartCoroutine(CheckVR());
    }

    public void StartConnection()
    {
        if (GameIsReady)
        {
            PhotonNetwork.JoinRandomRoom();
        }
        else
        {
            StartCoroutine(TryConnectAgain());
        }
    }

    public override void OnConnectedToMaster()
    {
        GameIsReady = true;
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        RoomOptions Options = new RoomOptions { MaxPlayers = 2, IsOpen = true, IsVisible = true };
        PhotonNetwork.CreateRoom("Main", Options, TypedLobby.Default);
    }

    public override void OnJoinedRoom()
    {
        if (!L.MPLoadComplete)
        {
            Debug.Log("Player has joined a room");
            Debug.Log("There is currently " + PhotonNetwork.CountOfPlayers + " in this room.");
            L.MPLoadComplete = true;
        }
    }

    private IEnumerator TryConnectAgain()
    {
        yield return new WaitForSeconds(5f);

        if (!GameIsReady)
        {
            PhotonNetwork.ConnectUsingSettings();
        }
    }

    private IEnumerator CheckVR()
    {
        yield return new WaitForSeconds(1f);

        if (CheckForVR)
            if (!VR_Checker.activeSelf)
            {
                Player2.SetActive(false);
            }
            else
            {
                Player1.SetActive(false);
                Player2.SetActive(true);
            }
    }
}
