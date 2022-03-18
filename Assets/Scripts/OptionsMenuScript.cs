using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsMenuScript : MonoBehaviour
{
    // Start is called before the first frame update

    public static bool ps4 = true;

    public static int driveControls = 1;


    private void Awake() {
        QualitySettings.SetQualityLevel(PlayerPrefs.GetInt("Graphics"));
        checkController(PlayerPrefs.GetInt("Controller"));
        checkDriveControls(PlayerPrefs.GetInt("Drive"));
    }

    public void changeGraphics(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
        PlayerPrefs.SetInt("Graphics", qualityIndex);
    }

    public void changeController(int controllerIndex)
    {
        PlayerPrefs.SetInt("Controller", controllerIndex);
        checkController(controllerIndex);
        BindControllerScript.refreshControls();
    }

    public void changeRobot(int robotIndex)
    {
        PlayerPrefs.SetInt("Drive", robotIndex);
        checkDriveControls(robotIndex);
    }

    void checkDriveControls(int index) {
        if(index == 0) {
            //Kaj Drive
            driveControls = 1;
        } else if(index == 1) {
            //Arcade Drive
            driveControls = 2;
        } else {
            //Tank Drive
            driveControls = 3;
        }
    }

    void checkController(int index) {
        if(index == 0) {
            ps4 = false;
        } else {
            ps4 = true;
        }
    }

}

