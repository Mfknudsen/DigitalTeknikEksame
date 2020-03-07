#region Systems
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity;
#endregion

public class PauseMenu : MonoBehaviour
{
    #region Public Data
    public GameObject Menu;
    #endregion

    public void PauseGame()
    {
        Menu.SetActive(true);
    }

    public void UnpauseGame()
    {
        Menu.SetActive(false);
    }
}
