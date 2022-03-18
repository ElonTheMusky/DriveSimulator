using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControllerScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject blue1Camera, blue2Camera, blue3Camera;

    public static GameObject blueCam2, blueCam1, blueCam3;

    void Start()
    {
        blueCam1 = blue1Camera;
        blueCam2 = blue2Camera;
        blueCam3 = blue3Camera;
        enableCamera2();
    }

    // Update is called once per frame

    public static void enableCamera1()
    {
        blueCam2.SetActive(false);
        blueCam1.SetActive(true);
        blueCam3.SetActive(false);
    }

    public static void enableCamera2()
    {
        blueCam2.SetActive(true);
        blueCam1.SetActive(false);
        blueCam3.SetActive(false);
    }

    public static void enableCamera3()
    {
        blueCam2.SetActive(false);
        blueCam1.SetActive(false);
        blueCam3.SetActive(true);
    }
}
