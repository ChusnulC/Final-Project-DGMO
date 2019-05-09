using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class UINetwork : MonoBehaviour
{
    GameObject panelKoneksi;

    Button btnHost;
    Button btnJoin;
    Button btnCancel;
    Text txInfo;

    NetworkManager network;

    int status = 0;

    // Start is called before the first frame update
    void Start()
    {
        panelKoneksi = GameObject.Find("PanelKoneksi");
//        panelKoneksi.transform.localPosition = Vector3.zero;

//        btnHost = GameObject.Find("BtnHost").GetComponent<Button>();
  //      btnJoin = GameObject.Find("BtnJoin").GetComponent<Button>();
    //    btnCancel = GameObject.Find("BtnCancel").GetComponent<Button>();
      //  txInfo = GameObject.Find("Info").GetComponent<Text>();

        //btnHost.onClick.AddListener(StartHostGame);
        //btnJoin.onClick.AddListener(StartJoinGame);
        //btnCancel.onClick.AddListener(StartCancelGame);

        //btnCancel.interactable = false;

        network = GameObject.Find("NetworkManager").GetComponent<NetworkManager>();
        txInfo.text = "Info : Server Address " + network.networkAddress + " with posrt " + network.networkPort;
    }

    // Update is called once per frame
    void Update()
    {
        /*if(NetworkClient.active || NetworkServer.active)
        {
            btnHost.interactable = false;
            btnJoin.interactable = false;
            btnCancel.interactable = true;
        }
        else
        {
            btnHost.interactable = true;
            btnJoin.interactable = true;
            btnCancel.interactable = false;
        }*/

        if(NetworkServer.connections.Count == 2 && status == 0)
        {
            status = 1;
            StartGame();
        }
        if(ClientScene.ready && !NetworkServer.active && status == 0)
        {
            status = 1;
            StartGame();
        }
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            BackMenu();
        }
    }

    private void StartHostGame()
    {
        Debug.Log("Dijalankan ketika tombol host ditekan!");
        if (!NetworkServer.active)
        {
            network.StartHost();
        }
        if (NetworkServer.active)
        {
            txInfo.text = "Info : Menunggu Player lain (Jika Server Aktif)";
        }
    }

    private void StartJoinGame()
    {
        Debug.Log("Dijalankan ketika tombol join ditekan!");
        if (!NetworkClient.active)
        {
            network.StartClient();
            network.client.RegisterHandler(MsgType.Disconnect, ConnectionError);
        }
        if (NetworkClient.active)
        {
            txInfo.text = "Info : Terhubung dengan Server";
        }
    }

    private void StartCancelGame()
    {
        Debug.Log("Dijalankan ketika tombol cancel ditekan!");
        network.StopHost();
        btnHost.interactable = true;
        btnJoin.interactable = true;
        btnCancel.interactable = false;
        txInfo.text = "Info : Server Address " + network.networkAddress + " with port " + network.networkPort;
    }

    private void ConnectionError(NetworkMessage netMsg)
    {
        //network.StopClient();
        //txInfo.text = "Info : Koneksi terputus dari sever";
        BackMain();
    }

    public void StartGame()
    {
        panelKoneksi.transform.localPosition = new Vector3(-1500, 0, 0);
    }

    public void BackMain()
    {
        network.StopHost();
        SceneManager.LoadScene("Main");
    } 

    public void BackMenu()
    {
        network.StopHost();
        SceneManager.LoadScene("Menu");
    }
}
