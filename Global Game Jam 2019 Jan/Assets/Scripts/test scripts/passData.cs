using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class passData : MonoBehaviour {
    public Overlord Overlord;
    public int score = 0;

	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(Overlord);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
