using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LoadingZoneScript : MonoBehaviour
{
    // Start is called before the first frame update

    public static int blueBalls;

    public static int currentBlueBalls;

    public static int redBalls;

    public static int currentRedBalls;

    GameObject spawnPoint;

    GameObject prefab;

    void Start()
    {
        prefab = Resources.Load("Ball") as GameObject;
        spawnPoint = GameObject.Find("Spot1");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (blueBalls < 14)
        {
            int addBalls = blueBalls - currentBlueBalls;
            if (addBalls > 0)
            {
                GameObject ball = Instantiate(prefab) as GameObject;
                currentBlueBalls++;
                ball.transform.position = spawnPoint.transform.position;
                int rowNumber = (int)Math.Ceiling(currentBlueBalls / 7.0);
                int columnNumber = currentBlueBalls % 7;
                if (columnNumber == 0)
                {
                    columnNumber = 7;
                }
                Vector3 ballPlacement = ball.transform.position;
                ballPlacement.y = (0.5f * (rowNumber - 1));
                ballPlacement.x = ((columnNumber - 1) * 0.65f);
                ballPlacement.z = 0;
                ball.transform.position -= ballPlacement;
                Debug.Log(ball.transform.position.x);

            }
        }
        else
        {
            BallController.SpawnBall(true);
            blueBalls--;
        }

    }

    public static void addBall(bool blue)
    {
        if (blue)
        {
            blueBalls++;
        }
        else
        {
            redBalls++;
        }
    }

    public static void resetBalls() {
        blueBalls = 0;
        currentBlueBalls = 0;
    }
}
