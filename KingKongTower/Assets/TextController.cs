using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextController : MonoBehaviour {

    private int score = 0;

	// Use this for initialization
	void Start () {
        GetComponent<Text>().text = "Heigth: 0";

    }
	
	// Update is called once per frame
	void Update () {
        foreach (var touch in Input.touches)
        {
            if (touch.phase == TouchPhase.Ended)
            {
                GetComponent<Text>().text = string.Format("Heigth: {0}", score++);
            }
        }
    }
}
