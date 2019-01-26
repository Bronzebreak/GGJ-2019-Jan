using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Final_time_display : MonoBehaviour
{

    public Text finalTimeText;
    public float tiltRate;
    public int finalTime;

	

	void Update ()
    {
        if (tiltRate <= 0)
        {
            finalTimeText.text = "finalTime";
        }

	}
}
