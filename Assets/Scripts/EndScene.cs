using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndScene : MonoBehaviour
{
    
    // Start is called before the first frame update
    static GameObject endScene;

    void Start() {
        endScene = GameObject.Find("EndScene");
        endScene.SetActive(false);
    }
    public static void showEndScene() {
        endScene.SetActive(true);
    }

    public static void hideEndScene() {
        endScene.SetActive(false);
    }
}
