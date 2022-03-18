using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BindControllerScript : MonoBehaviour
{

    public static Dictionary<string, string> buttons = new Dictionary<string, string>();

    public static string[] defaultBinds = new string[9];


    /*
    CORE BINDS:
    Toggle Vision
    Shoot Balls
    Intake
    Toggle Climb
    Winch
    */

    /*

    PS4 Buttons
    Square  = 0
    X       = 1
    Circle  = 2
    Triangle = 3
    L1      = 4
    R1      = 5
    L2      = 6
    R2      = 7
    Share	= 8
    Options = 9
    L3      = 10
    R3      = 11
    PS      = 12
    PadPress = 13

    Xbox Buttons
    A = 0
    B = 1
    X = 2
    Y = 3
    LB = 4
    RB = 5
    Back = 6
    Start = 7
    L3 = 8
    R3 = 9
    L2 = 10
    R2 = 11
    XPress = 12
    */


    // Start is called before the first frame update
    private void Awake() 
    {
        buttons.Add("Vision", "");
        buttons.Add("Shoot", "");
        buttons.Add("Intake", "");
        buttons.Add("Climb", "");
        buttons.Add("Winch", "");   
        buttons.Add("TrimIncrease", "");
        buttons.Add("TrimDecrease", "");
        buttons.Add("Index", "");
        buttons.Add("Reset", "");
        refreshControls();
    }

    // Update is called once per frame

    // public void getTextInputFIeld(string text) {
    //     Debug.Log(text);
    // }

    // public void ChangeVisionBind(string buttonNum) {
    //     int number = int.Parse(buttonNum);
    //     buttons["Vision"] = findBindName(number);
    //     Debug.Log("Vision Bind: " + buttons["Vision"]);
    //     PlayerPrefs.SetString("Vision", buttons["Vision"]);
    //     refreshControls();
    // }

    // public void ChangeShootBind(string buttonNum) {
    //     int number = int.Parse(buttonNum);
    //     buttons["Shoot"] = findBindName(number);
    //     PlayerPrefs.SetString("Shoot", buttons["Shoot"]);
    //     refreshControls();
    // }

    // public void ChangeIntakeBind(string buttonNum) {
    //     int number = int.Parse(buttonNum);
    //     buttons["Intake"] = findBindName(number);
    //     PlayerPrefs.SetString("Intake", buttons["Intake"]);
    //     refreshControls();
    // }


    // public void ChangeClimbBind(string buttonNum) {
    //     int number = int.Parse(buttonNum);
    //     buttons["Climb"] = findBindName(number);
    //     PlayerPrefs.SetString("Climb", buttons["Climb"]);
    //     refreshControls();
    // }

    // public void ChangeWinchBind(string buttonNum) {
    //     int number = int.Parse(buttonNum);
    //     buttons["Winch"] = findBindName(number);
    //     PlayerPrefs.SetString("Winch", buttons["Winch"]);
    //     refreshControls();
    // }

    // public void ChangeTrimIncreaseBind(string buttonNum) {
    //     int number = int.Parse(buttonNum);
    //     buttons["TrimIncrease"] = findBindName(number);
    //     PlayerPrefs.SetString("TrimIncrease", buttons["TrimIncrease"]);
    //     refreshControls();
    // }

    // public void ChangeTrimDecreaseBind(string buttonNum) {
    //     int number = int.Parse(buttonNum);
    //     buttons["TrimDecrease"] = findBindName(number);
    //     PlayerPrefs.SetString("TrimDecrease", buttons["TrimDecrease"]);
    //     refreshControls();
    // }

    // public void ChangeIndexBind(string buttonNum) {
    //     int number = int.Parse(buttonNum);
    //     buttons["Index"] = findBindName(number);
    //     PlayerPrefs.SetString("Index", buttons["Index"]);
    //     refreshControls();
    // }

    // public void ChangeResetBind(string buttonNum) {
    //     int number = int.Parse(buttonNum);
    //     buttons["Reset"] = findBindName(number);
    //     PlayerPrefs.SetString("Reset", buttons["Reset"]);
    //     refreshControls();
    // }

    // public string findBindName(int buttonNum) {
    //     if(OptionsMenuScript.ps4) {
    //         switch(buttonNum) {
    //             case 0:
    //                 return "SquarePS4";
    //             case 1:
    //                 return "XPS4";
    //             case 2:
    //                 return "CirclePS4";
    //             case 3:
    //                 return "TrianglePS4";
    //             case 4:
    //                 return "L1PS4";  
    //             case 5:
    //                 return "R1PS4";
    //             case 6:
    //                 return "L2PS4";
    //             case 7:
    //                 return "R2PS4";
    //             case 8:
    //                 return "SharePS4";
    //             case 9:
    //                 return "OptionsPS4";
    //             case 10:
    //                 return "L3PS4";
    //             case 11:
    //                 return "R3PS4";
    //             case 12:
    //                 return "PSPS4";
    //             case 13:
    //                 return "PadPressPS4";
    //             case 14:
    //                 return "DpadYPS4";
    //             default:
    //                 return "Invalid";                                          
    //         }
    //     } else {
    //         switch(buttonNum) {
    //             case 0:
    //                 return "AXbox";
    //             case 1:
    //                 return "BXbox";
    //             case 2:
    //                 return "XXbox";
    //             case 3:
    //                 return "YXbox";
    //             case 4:
    //                 return "LBXbox";  
    //             case 5:
    //                 return "RBXbox";
    //             case 6:
    //                 return "BackXbox";
    //             case 7:
    //                 return "StartXbox";
    //             case 8:
    //                 return "L3Xbox";
    //             case 9:
    //                 return "R3Xbox";
    //             case 10:
    //                 return "L2Xbox";
    //             case 11:
    //                 return "R2Xbox";
    //             case 12:
    //                 return "XPressXbox";
    //             case 13:
    //                 return "DpadYXbox";
    //             default:
    //                 return "Invalid";                                          
    //         }
    //     }
    // }

    public static void refreshControls() {
        if(PlayerPrefs.GetInt("Controller") == 1) {
            Debug.Log("PS4 Controls");
            defaultBinds[0] = "TrianglePS4";
            defaultBinds[1] = "R1PS4";
            defaultBinds[2] = "R2PS4";
            defaultBinds[3] = "L1PS4";
            defaultBinds[4] = "L2PS4";
            defaultBinds[5] = "DpadYPS4";
            defaultBinds[6] = "DpadYPS4";
            defaultBinds[7] = "SquarePS4";
            defaultBinds[8] = "CirclePS4";
        } else {
            Debug.Log("XBOX Controls");
            defaultBinds[0] = "YXbox";
            defaultBinds[1] = "RBXbox";
            defaultBinds[2] = "R2Xbox";
            defaultBinds[3] = "LBXbox";
            defaultBinds[4] = "L2Xbox";
            defaultBinds[5] = "DpadYXbox";
            defaultBinds[6] = "DpadYXbox";
            defaultBinds[7] = "AXbox";
            defaultBinds[8] = "XXbox";
        }

        if(PlayerPrefs.GetString("Vision") != "") {
            defaultBinds[0] = PlayerPrefs.GetString("Vision");
        }
        if(PlayerPrefs.GetString("Shoot") != "") {
            defaultBinds[1] = PlayerPrefs.GetString("Shoot");   
        }
        if(PlayerPrefs.GetString("Intake") != "") {
            defaultBinds[2] = PlayerPrefs.GetString("Intake");    
        }
        if(PlayerPrefs.GetString("Climb") != "") {
            defaultBinds[3] = PlayerPrefs.GetString("Climb");
        }
        if(PlayerPrefs.GetString("Winch") != ""){
            defaultBinds[4] = PlayerPrefs.GetString("Winch");    
        }
        if(PlayerPrefs.GetString("TrimIncrease") != ""){
            defaultBinds[5] = PlayerPrefs.GetString("TrimIncrease");    
        }
        if(PlayerPrefs.GetString("TrimDecrease") != ""){
            defaultBinds[6] = PlayerPrefs.GetString("TrimDecrease");    
        }
        if(PlayerPrefs.GetString("Index") != ""){
            defaultBinds[7] = PlayerPrefs.GetString("Index");    
        }
        if(PlayerPrefs.GetString("Reset") != ""){
            defaultBinds[8] = PlayerPrefs.GetString("Reset");    
        }

        buttons["Vision"] = defaultBinds[0];
        buttons["Shoot"] = defaultBinds[1];
        buttons["Intake"] = defaultBinds[2];
        buttons["Climb"] = defaultBinds[3];
        buttons["Winch"] = defaultBinds[4];
        buttons["TrimIncrease"] = defaultBinds[5];
        buttons["TrimDecrease"] = defaultBinds[6];
        buttons["Index"] = defaultBinds[7];
        buttons["Reset"] = defaultBinds[8];
    }
}
