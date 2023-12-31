using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ConnectToServer : MonoBehaviourPunCallbacks
{
    public InputField NickNameGrabber;
    public Text ButtonText;

    public void OnClickConnect()
    {
        if (NickNameGrabber.text.Length >= 1)
        { 
            PhotonNetwork.NickName = NickNameGrabber.text;
            ButtonText.text = "Connecting...";
            PhotonNetwork.ConnectUsingSettings();
        }
    }

    public override void OnConnectedToMaster()
    {
        SceneManager.LoadScene("Lobby");
    }
}
