using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLoadingScript : MonoBehaviour
{

    public static GameObject ballSpawn;
    public static GameObject prefab;
    // Start is called before the first frame update
    void Start()
    {
        prefab = Resources.Load("Ball") as GameObject;
        ballSpawn = GameObject.Find("RBSpawn");
    }

    public static void SpawnBall() {
        GameObject spawnBall = Instantiate(prefab) as GameObject;
        spawnBall.transform.position = ballSpawn.transform.position;
    }
}
