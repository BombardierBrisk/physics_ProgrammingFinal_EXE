using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {
    public float targetTime = 0.0f;
    public Text set_Time;// Use this for initialization
    void Start () {

        set_Time.text = targetTime.ToString();
    }
	
	// Update is called once per frame
	void Update () {
        targetTime += Time.deltaTime;
        set_Time.text = targetTime.ToString();
    }
}
