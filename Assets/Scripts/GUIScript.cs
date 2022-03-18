using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUIScript : MonoBehaviour
{
    // Start is called before the first frame update

    public static int blueScore;

    public static int redScore;

    public int minutes, seconds;

    public Font myFont;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnGUI()
    {
        GUI.skin.font = myFont;
        GUI.Label(new Rect(Screen.width * 0.9f, 0, Screen.width * 0.1f, Screen.height * 0.05f), ("Blue Score: " + blueScore));
        GUI.Label(new Rect(Screen.width * 0.9f, Screen.height * 0.05f, Screen.width * 0.1f, Screen.height * 0.05f), getTime());
        if(TimerScript.currentTime > 135) {
            GUI.Label(new Rect(Screen.width * 0.95f, Screen.height * 0.05f, Screen.width * 0.1f, Screen.height * 0.05f), "AUTO");
        } else {
            GUI.Label(new Rect(Screen.width * 0.95f, Screen.height * 0.05f, Screen.width * 0.1f, Screen.height * 0.05f), "TELE");
        }
    }

    string getTime()
    {
        int time = (int)TimerScript.currentTime;
        minutes = time / 60;
        seconds = time % 60;
        string timeString;
        if (seconds < 10)
        {
            timeString = "" + minutes + ":0" + seconds;
        }
        else
        {
            timeString = "" + minutes + ":" + seconds;
        }

        return timeString;
    }
}
