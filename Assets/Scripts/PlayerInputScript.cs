using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using UnityEngine.InputSystem;

public class PlayerInputScript : MonoBehaviour
{
    public static bool locked = false;

    // Update is called once per frame
    void Update()
    {

        if(!locked) {
            checkControls();
        } else {
            DriveTrainController.yRaw = 0f;
            DriveTrainController.xRaw = 0f;
            DriveTrainController.leftDrive = 0.0f;
            DriveTrainController.rightDrive = 0.0f;
            ShooterController.tracking = false;
            ShooterController.shotBall = false;
            IntakeController.IntakePower = false;
        }
        
    }


    void checkControls() {
        if (Input.GetKey("1"))
        {
            CameraControllerScript.enableCamera1();
        }
        else if (Input.GetKey("2"))
        {
            CameraControllerScript.enableCamera2();
        }
        else if (Input.GetKey("3"))
        {
            CameraControllerScript.enableCamera3();
        }
        else if(Input.GetKeyUp(KeyCode.Space)) {
            PlayerLoadingScript.SpawnBall();
            Debug.Log("Output Ball");
        }

        manageVisionInput();
        manageShootInput();
        manageIntakeInput();
        manageClimbInput();
        manageWinchInput();
        manageTrimIncreaseInput();
        manageTrimDecreaseInput();
        manageIndexerInput();
        manageResetInput();

        if(PlayerPrefs.GetInt("Controller") == 1) {
            if(OptionsMenuScript.driveControls == 1) {
                DriveTrainController.xRaw = Input.GetAxis("HorizontalPs4");
                DriveTrainController.yRaw = Input.GetAxis("VerticalPs4");
            } else if(OptionsMenuScript.driveControls == 2) {
                DriveTrainController.xRaw = Input.GetAxis("ArcadeXAxisPs4");
                DriveTrainController.yRaw = Input.GetAxis("VerticalPs4");
            } else if(OptionsMenuScript.driveControls == 3) {
                DriveTrainController.rightDrive = Input.GetAxis("TankYAxisPs4");
                DriveTrainController.leftDrive = Input.GetAxis("VerticalPs4");
            } 
        } else {
            if(OptionsMenuScript.driveControls == 1) {
                DriveTrainController.xRaw = Input.GetAxis("HorizontalXbox");
                DriveTrainController.yRaw = Input.GetAxis("VerticalXbox");
            } else if(OptionsMenuScript.driveControls == 2) {
                DriveTrainController.xRaw = Input.GetAxis("ArcadeXAxisXbox");
                DriveTrainController.yRaw = Input.GetAxis("VerticalXbox");
            } else if(OptionsMenuScript.driveControls == 3) {
                DriveTrainController.rightDrive = Input.GetAxis("TankYAxisXbox");
                DriveTrainController.leftDrive = Input.GetAxis("VerticalXbox");
            } 
        }
    }


    public void manageVisionInput() {
            if (Input.GetButtonDown(BindControllerScript.buttons["Vision"]))
            {
            ShooterController.tracking = !ShooterController.tracking;
            }
    }

    public void manageShootInput() {
        ShooterController.shootBall = Input.GetButton(BindControllerScript.buttons["Shoot"]);
    }

    public void manageIntakeInput() {
            if (Input.GetAxis(BindControllerScript.buttons["Intake"]) > 0.0f)
            {
            IntakeController.IntakePower = true;
            } else {
                IntakeController.IntakePower = false;
            }
    }

    public void manageClimbInput() {
            if (Input.GetButtonDown(BindControllerScript.buttons["Climb"]))
            {
                ClimbController.climb = !ClimbController.climb;
            }
    }

    public void manageWinchInput() {
            if (Input.GetAxis(BindControllerScript.buttons["Winch"]) > 0.0f)
            {
            ClimbController.winch = true;
            } else {
                ClimbController.winch = false;
            }
    }

    public void manageTrimIncreaseInput() {

            if (Input.GetAxis(BindControllerScript.buttons["TrimIncrease"]) > 0.0f)
            {
           ShooterController.IncreaseTrim();
            }
    }

    public void manageTrimDecreaseInput() {
        if (Input.GetAxis(BindControllerScript.buttons["TrimDecrease"]) < 0.0f)
            {
           ShooterController.DecreaseTrim();
            }
    }

    public void manageIndexerInput() {
        if(Input.GetButtonDown(BindControllerScript.buttons["Index"])) {
            BallController.index = !BallController.index;
        }
    }

    public void manageResetInput() {
            if(Input.GetButtonDown(BindControllerScript.buttons["Reset"])) {
                ShooterController.reset();
            }
    }

}

