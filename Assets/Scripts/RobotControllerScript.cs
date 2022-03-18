using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotControllerScript : MonoBehaviour
{

    public static float robotWorldHeading;
    public static float robotXCord;
    public static float robotZCord;
    public static float robotYCord;
    // Start is called before the first frame update

    // Update is called once per frame
    void FixedUpdate()
    {
        robotWorldHeading = transform.localEulerAngles.y;
        robotXCord = transform.position.x;
        robotZCord = transform.position.z;
        robotYCord = transform.position.y;
    }
}
