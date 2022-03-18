using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DriveTrainController : MonoBehaviour
{
    // Start is called before the first frame update
    public List<DriveSide> DriveSides; // the information about each individual axle
    public float maxMotorTorque;
    
    public static float xRaw, yRaw, leftDrive, rightDrive;

    // Update is called once per frame
    public void FixedUpdate()
    {
        // Debug.Log(transform.localEulerAngles.y);
        List<float> power = new List<float>();


        if(OptionsMenuScript.driveControls != 3) {
            float yPower = (yRaw * yRaw * yRaw) * -1;
            float xPower = (xRaw * xRaw * xRaw) * -1;
            if (Math.Abs(yPower) < 0.1f)
            {
                yPower = 0.0f;
            }
            if (Math.Abs(xPower) < 0.1f)
            {
                xPower = 0.0f;
            }
            if(OptionsMenuScript.driveControls == 1) {
                float leftSidePower = maxMotorTorque * (yPower - xPower);
                float rightSidePower = maxMotorTorque * (yPower + xPower);
                power.Add(leftSidePower);
                power.Add(rightSidePower);
            } else {
                float leftSidePower = maxMotorTorque * (yPower + xPower);
                float rightSidePower = maxMotorTorque * (yPower - xPower);
                power.Add(leftSidePower);
                power.Add(rightSidePower);
            }
            // Debug.Log(xPower);
        } else {
            float leftPower = (leftDrive * leftDrive * leftDrive) * -1;
            float rightPower = (rightDrive * rightDrive * rightDrive) * -1;
            if (Math.Abs(leftPower) < 0.1f)
            {
                leftPower = 0.0f;
            }
            if (Math.Abs(rightDrive) < 0.1f)
            {
                rightPower = 0.0f;
            }
            float leftSidePower = maxMotorTorque * leftPower;
            float rightSidePower = maxMotorTorque * rightPower;
            power.Add(leftSidePower);
            power.Add(rightSidePower);

        }

        int index = 0;

        foreach (DriveSide driveSide in DriveSides)
        {
            if (driveSide.motor)
            {
                driveSide.frontWheelCol.motorTorque = power[index];
                driveSide.middleWheelCol.motorTorque = power[index];
                driveSide.backWheelCol.motorTorque = power[index];
            }
            index++;
        }
    }

}



[System.Serializable]
public class DriveSide
{
    public WheelCollider frontWheelCol;
    public WheelCollider middleWheelCol;

    public WheelCollider backWheelCol;
    public bool motor; // is this wheel attached to motor?
}