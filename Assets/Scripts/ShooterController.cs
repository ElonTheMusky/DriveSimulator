using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class ShooterController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject blueGoal;
    // public GameObject redGoal;
    public Material[] materials;
    public static float maxDegreesRotation = 1.0f, maxDegreesHoodRotation = 3.0f;
    public static GameObject shooterAssem, hood, robot;
    GameObject prefab;

    Renderer rend;

    static Camera visionCamera;

    public static bool readyToShoot = false, shotBall = false, tracking = false, lastGoalBlue = false;

    public static double angleToTarget, lastAngleToTarget = 0;
    public static float currentTurretRotation = 0, currentHoodAngle = 0.0f, Trim = 0.0f, MaxTrim = 3.0f, MinTrim = -3.0f;

    static float maxTurretRotation = 20, minTurretRotation = -20, shotPower, maxPower = 75;

    public static bool shootBall;
    void Start()
    {
        prefab = Resources.Load("Ball") as GameObject;
        visionCamera = GameObject.Find("VisionCamera").GetComponent<Camera>();
        rend = GameObject.Find("LimeLight").GetComponent<Renderer>();
        rend.sharedMaterial = materials[0];
        shooterAssem = GameObject.Find("Shooter");
        hood = GameObject.Find("Hood");
        robot = GameObject.Find("V4Robot");
    }

    void FixedUpdate()
    {
        if (shootBall && readyToShoot)
        {
            GameObject projectile = Instantiate(prefab) as GameObject;
            projectile.transform.position = transform.position + visionCamera.transform.forward * 2;
            Vector3 projectilePos = projectile.transform.position;
            projectilePos.y += 0.6f;
            projectile.transform.position = projectilePos;
            Rigidbody rb = projectile.GetComponent<Rigidbody>();
            if (tracking)
            {
                rb.velocity = visionCamera.transform.forward * shotPower;
            }
            else
            {
                rb.velocity = visionCamera.transform.forward * 40;
            }
            shotBall = true;
            Destroy(BallController.currentFeederBall);
        }

        if (tracking)
        {
            calculateDegreesToGoal();
            calculateDistanceToGoal();
            float wantedDegrees = (float)(angleToTarget - lastAngleToTarget);
            rotateShooterAssem(wantedDegrees);
            Debug.Log("Deg:" + angleToTarget);
            rend.sharedMaterial = materials[0];
            GameObject.Find("Vision Light").GetComponent<Light>().enabled = true;
        }
        else
        {
            rotateHoodTo(0);
            rotateShooterAssem(-currentTurretRotation);
            lastAngleToTarget = 0.0f;
            Trim = 0.0f;
            rend.sharedMaterial = materials[1];
            GameObject.Find("Vision Light").GetComponent<Light>().enabled = false;
        }
    }

    void calculateDegreesToGoal()
    {
        angleToTarget = Math.Atan((blueGoal.transform.position.z - RobotControllerScript.robotZCord) / (blueGoal.transform.position.x - RobotControllerScript.robotXCord)) * (180.0f / Math.PI);
        if (blueGoal.transform.position.x - RobotControllerScript.robotXCord < 0)
        {
            angleToTarget = 90 + angleToTarget;
            angleToTarget *= -1;
        }
        else
        {
            angleToTarget = 90 - angleToTarget;
        }

        if (RobotControllerScript.robotWorldHeading > 270)
        {
            angleToTarget += (360 - RobotControllerScript.robotWorldHeading);
        }
        else if (RobotControllerScript.robotWorldHeading < 90)
        {
            angleToTarget -= RobotControllerScript.robotWorldHeading;
        }
    }

    static void rotateShooterAssem(float wantedDegrees) {
        if (currentTurretRotation + wantedDegrees < maxTurretRotation && currentTurretRotation + wantedDegrees > minTurretRotation)
            {
                if (Math.Abs(wantedDegrees) > maxDegreesRotation)
                {
                    shooterAssem.transform.Rotate(0, maxDegreesRotation * Math.Sign(wantedDegrees), 0);
                    lastAngleToTarget += maxDegreesRotation * Math.Sign(wantedDegrees);
                    currentTurretRotation += maxDegreesRotation * Math.Sign(wantedDegrees);
                }
                else
                {
                    shooterAssem.transform.Rotate(0, wantedDegrees, 0);
                    lastAngleToTarget = angleToTarget;
                    currentTurretRotation += wantedDegrees;
                }
            }
    }

    void calculateDistanceToGoal()
    {
        // float distance = (float)Math.Sqrt(Math.Pow(robot.transform.position.x - blueGoal.transform.position.x, 2) + Math.Pow(robot.transform.position.y - blueGoal.transform.position.y, 2) + Math.Pow(robot.transform.position.z - blueGoal.transform.position.z, 2));
        float distance = (float)Math.Sqrt(Math.Pow(robot.transform.position.x - 5.1f, 2) + Math.Pow(robot.transform.position.y - 7.2f, 2) + Math.Pow(robot.transform.position.z - 24f, 2));
        float deltaY = blueGoal.transform.position.y - transform.position.y;
        float angle = (float)(Math.Asin(deltaY / distance) * (180 / Math.PI) - 15f);
        float addition = (48 - distance)/48f * 3f;
        // Debug.Log("D:" + distance);
        rotateHoodTo(angle + addition);
        shotPower = (distance / 40) * maxPower + Trim;
    }

    static void rotateHoodTo(float angle)
    {
        float deltaAngle = angle - currentHoodAngle;
        if (Math.Abs(deltaAngle) > maxDegreesHoodRotation)
        {
            hood.transform.Rotate(-maxDegreesHoodRotation * Math.Sign(deltaAngle), 0, 0);
            currentHoodAngle += maxDegreesHoodRotation * Math.Sign(deltaAngle);
        }
        else
        {
            hood.transform.Rotate(-deltaAngle, 0, 0);
            currentHoodAngle += deltaAngle;
        }
    }

    public static void reset() {
        tracking = false;
        Trim = 0.0f;
    }

    public static void IncreaseTrim() {
        if(Trim < MaxTrim) {
            Trim += 0.1f;
        }
    }

    public static void DecreaseTrim() {
        if(Trim > MinTrim) {
            Trim -= 0.1f;
        }
    }
}
