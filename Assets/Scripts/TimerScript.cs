using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerScript : MonoBehaviour
{

    public static float currentTime = 0f, startingTime = 150f;

    public static float pauseTime;
    public static bool paused, climbPoints = true;
    // Start is called before the first frame update
    void Start()
    {
        currentTime = startingTime;

    }

    // Update is called once per frame
    void FixedUpdate()
    {

        currentTime -= 1 * Time.deltaTime;
        if (paused)
        {
            currentTime = pauseTime;
        }
        if(currentTime <= 0) {
            PauseGame();
            EndScene.showEndScene();
            if(RobotControllerScript.robotYCord > 0.5f && climbPoints) {
                GUIScript.blueScore += 25;
                climbPoints = false;
            }
            ClimbController.disableMove = true;
        }
    }

    public static void PauseGame()
    {
        pauseTime = currentTime;
        PlayerInputScript.locked = true;
        paused = true;
    }
}
