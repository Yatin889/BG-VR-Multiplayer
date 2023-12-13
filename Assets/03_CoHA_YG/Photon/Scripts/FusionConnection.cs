using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;
using Fusion.Sockets;
using System;

public class FusionConnection : MonoBehaviour, INetworkRunnerCallbacks 
{
    public bool ConnectOnAwake = false;
    [HideInInspector] public NetworkRunner runner;

    [SerializeField] NetworkObject playerPrefab;
    private void Awake()
    {
        if(ConnectOnAwake==true)
        {
            ConnectToRunner();
        }
    }
    public void OnConnectedToServer(NetworkRunner runner)
    {
        Debug.Log("On connected to server");
        NetworkObject playerObject = runner.Spawn(playerPrefab, Vector3.zero);
        runner.SetPlayerObject(runner.LocalPlayer, playerObject);
    }
    public async void ConnectToRunner()
    {
        if(runner==null)
        {
            runner = gameObject.AddComponent<NetworkRunner>();
        }
        await runner.StartGame(new StartGameArgs()
        {
            GameMode = GameMode.Shared,
            SessionName = "test",
            PlayerCount=2,
            SceneManager = gameObject.AddComponent<NetworkSceneManagerDefault>(),
        }) ;   
    }

    public void OnConnectFailed(NetworkRunner runner, NetAddress remoteAddress, NetConnectFailedReason reason)
    {
       // Debug.Log("");
    }

    public void OnConnectRequest(NetworkRunner runner, NetworkRunnerCallbackArgs.ConnectRequest request, byte[] token)
    {
       // Debug.Log("");
    }

    public void OnCustomAuthenticationResponse(NetworkRunner runner, Dictionary<string, object> data)
    {
       // Debug.Log("");
    }

    public void OnDisconnectedFromServer(NetworkRunner runner)
    {
        //Debug.Log("");
    }

    public void OnHostMigration(NetworkRunner runner, HostMigrationToken hostMigrationToken)
    {
        //Debug.Log("");
    }

    public void OnInput(NetworkRunner runner, NetworkInput input)
    {
       // Debug.Log("");
    }

    public void OnInputMissing(NetworkRunner runner, PlayerRef player, NetworkInput input)
    {
      //  Debug.Log("");
    }

    public void OnPlayerJoined(NetworkRunner runner, PlayerRef player)
    {
        Debug.Log("On Player Joined");
    }

    public void OnPlayerLeft(NetworkRunner runner, PlayerRef player)
    {
       // Debug.Log("");
    }

    public void OnReliableDataReceived(NetworkRunner runner, PlayerRef player, ArraySegment<byte> data)
    {
      //  Debug.Log("");
    }

    public void OnSceneLoadDone(NetworkRunner runner)
    {
      //  Debug.Log("");
    }

    public void OnSceneLoadStart(NetworkRunner runner)
    {
      //  Debug.Log("");
    }

    public void OnSessionListUpdated(NetworkRunner runner, List<SessionInfo> sessionList)
    {
       // Debug.Log("");
    }

    public void OnShutdown(NetworkRunner runner, ShutdownReason shutdownReason)
    {
     //   Debug.Log("");
    }

    public void OnUserSimulationMessage(NetworkRunner runner, SimulationMessagePtr message)
    {
       // Debug.Log("");
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
