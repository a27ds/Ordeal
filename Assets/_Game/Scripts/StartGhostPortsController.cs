using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGhostPortsController : MonoBehaviour {

    public List<GameObject> ghostPorts;
    GameObject player;

	// Use this for initialization
	void Start () {
        player = GameObject.Find("Player");
        foreach (var ghostPort in ghostPorts)
        {
            ghostPort.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals(player.name))
        {
            foreach (var ghostPort in ghostPorts)
            {
                ghostPort.SetActive(true);
            }
        }
    }
}
