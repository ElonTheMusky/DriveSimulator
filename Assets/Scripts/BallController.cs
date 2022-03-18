using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BallController : MonoBehaviour
{  

    // Start is called before the first frame update
    public static GameObject prefab;
    public static Vector3 blueBallSpawn;
    public static Vector3 redBallSpawn;

    public static GameObject currentFeederBall;

    public static Vector3 endPoint;
    public static float speed = 3f;

    public static bool index = true;


    void Start()
    {
        prefab = Resources.Load("Ball") as GameObject;
        blueBallSpawn = GameObject.Find("BBSpawn").transform.position;
        redBallSpawn = GameObject.Find("RBSpawn").transform.position;
        endPoint = GameObject.Find("ConveyorTarget").transform.position;
    }

    void FixedUpdate()
    {
        if (ShooterController.shotBall)
        {
            ShooterController.readyToShoot = false;
            ShooterController.shotBall = false;
        }
    }
    public void OnTriggerEnter(Collider other)
    {

        if (!IntakeController.stowed && other.GetComponent<Collider>().name == "IntakeHitbox")
        {
            Vector3 ballPos;
            float random = UnityEngine.Random.Range(0.0f, 3.0f);
            if (random <= 1)
            {
                ballPos = GameObject.Find("IntakeBallSpawn1").transform.position;
            }
            else if (random <= 2)
            {
                ballPos = GameObject.Find("IntakeBallSpawn2").transform.position;
            }
            else
            {
                ballPos = GameObject.Find("IntakeBallSpawn3").transform.position;
            }
            transform.position = ballPos;
        }
        else if (other.GetComponent<Collider>().name == "IndexerHitBox")
        {
            ShooterController.readyToShoot = true;
            currentFeederBall = gameObject;
        }
        else if (other.GetComponent<Collider>().name == "BlueInnerGoalHitBox")
        {
            if(TimerScript.currentTime > 130) {
                GUIScript.blueScore += 6;
            } else {
                GUIScript.blueScore += 3;
            }
            Destroy(gameObject);
            LoadingZoneScript.addBall(true);
        }
        else if (other.GetComponent<Collider>().name == "RedInnerGoalHitBox")
        {
            if(TimerScript.currentTime > 130) {
                GUIScript.redScore += 6;
            } else {
                GUIScript.redScore += 3;
            }
            Destroy(gameObject);
            LoadingZoneScript.addBall(false);
        }
        else if (other.GetComponent<Collider>().name == "BlueOuterGoalHitBox")
        {
            if(TimerScript.currentTime > 130) {
                GUIScript.blueScore += 4;
            } else {
                GUIScript.blueScore += 2;
            }
            Destroy(gameObject);
            LoadingZoneScript.addBall(true);
        }
        else if (other.GetComponent<Collider>().name == "RedOuterGoalHitBox")
        {
            if(TimerScript.currentTime > 130) {
                GUIScript.redScore += 4;
            } else {
                GUIScript.redScore += 2;
            }
            Destroy(gameObject);
            LoadingZoneScript.addBall(false);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Collider>().name == "IndexerHitbox")
        {
            ShooterController.readyToShoot = false;
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<Collider>().name == "Conveyor")//&& !ShooterController.readyToShoot
        {
            if(index) {
                // Debug.Log("INDEXING");
                transform.position = Vector3.MoveTowards(transform.position, endPoint, speed * Time.deltaTime);
            }
        }
    }

    public static void SpawnBall(bool blue)
    {
        // Debug.Log("Created New Ball");
        GameObject projectile = Instantiate(prefab) as GameObject;
        if (blue)
        {
            projectile.transform.position = blueBallSpawn;
        }
        else
        {
            projectile.transform.position = redBallSpawn;
        }
    }
}
