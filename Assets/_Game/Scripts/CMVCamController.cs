using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CMVCamController : MonoBehaviour {

    CinemachineVirtualCamera virtualCamera;
    Transform player;

	// Use this for initialization
	void Start () {
        virtualCamera = GameObject.Find("CM vcam1").GetComponent<CinemachineVirtualCamera>();
        player = GameObject.Find("Player").transform;
        Camera.main.transform.position = player.position;
        virtualCamera.Follow = player;

        GameObject.Find("SceneHandler(Clone)").GetComponent<SceneHandler>().GetCameraPos();

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
