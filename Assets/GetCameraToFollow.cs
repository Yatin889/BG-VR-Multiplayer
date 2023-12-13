using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;

public class GetCameraToFollow : MonoBehaviour
{
    [SerializeField] Transform playerCameraRoot;

    private void Awake()
    {
        
       
        
    }
    private void Start()
    {
        NetworkObject thisObject = GetComponent<NetworkObject>();
        if (thisObject.HasInputAuthority)
        {
            GameObject virtualCamera = GameObject.Find("PlayerFollowCamera");
            virtualCamera.GetComponent<CinemachineVirtualCamera>().Follow = playerCameraRoot;

        }
    }

}
