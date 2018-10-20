using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartController : MonoBehaviour {

    public Button startButton;

	// Use this for initialization
	void Start () {
        Button startBtn = startButton.GetComponent<Button>();

        startBtn.onClick.AddListener(TaskOnClick);
		
	}

    void TaskOnClick()
    {
        Debug.Log("Click");
    }
}
