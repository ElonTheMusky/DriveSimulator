using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ClimbController : MonoBehaviour
{
    public static GameObject ClimberR, ClimberL;

    public static GameObject level2r, level1r;

    public static GameObject level2l, level1l;

    public static bool climb, allTheWayDown, disableMove, winch;
    public static float currentExtension, targetExtension, maxMovementUp = 10f, maxMovementDown = 5f;

    void Start() {
        climb = false;
        allTheWayDown = true;
        currentExtension = 0.0f;
        targetExtension = 4.0f;
        disableMove = false;
        level1l = GameObject.Find("HangerLevel1L");
        level2l = GameObject.Find("HangerLevel2L");
        level1r = GameObject.Find("HangerLevel1R");
        level2r = GameObject.Find("HangerLevel2R");
        ClimberL = GameObject.Find("ClimberLeft");
        ClimberR = GameObject.Find("ClimberRight");
    }

    void FixedUpdate() {
        if(!disableMove) {
            if(climb && allTheWayDown) {//currentExtension <= 0.2f
                    ClimberR.GetComponent<Animator>().Play("RightRotateOut");
                    ClimberL.GetComponent<Animator>().Play("LeftRotateOut");
                    allTheWayDown = false;
                } else if(!climb && currentExtension <= 0.01f && !allTheWayDown) {
                    ClimberR.GetComponent<Animator>().Play("RightRotateIn");
                    ClimberL.GetComponent<Animator>().Play("LeftRotateIn");
                    allTheWayDown = true;
            }
            if(winch) {
                if(currentExtension > 0.0f) {
                     moveDown();
                }
            } else {
                if(climb) {
                    moveUp();
                } else {
                    moveDown();
                }
            }
        }
    }

    public static void moveUp() {
        float wantedMovement = (targetExtension - currentExtension);
        if(Math.Abs(wantedMovement) > maxMovementUp) {
            wantedMovement = maxMovementUp;
            move(-wantedMovement);
        } else {
            move(-wantedMovement);
        }
    }

    public static void moveDown() {
        float wantedMovement = 0 - currentExtension;
        if(Math.Abs(wantedMovement) > maxMovementDown) {
            wantedMovement = maxMovementDown;
            move(wantedMovement);
        } else {
            move(-wantedMovement);
        }
    }

    public static void move(float amount) {
        amount *=  Time.deltaTime;
        
        Vector3 temp2r = level2r.transform.localPosition;
        temp2r.z += amount;
        level2r.transform.localPosition = temp2r;

        Vector3 temp1r = level1r.transform.localPosition;
        temp1r.z += amount * 1.75f;
        level1r.transform.localPosition = temp1r;

        Vector3 temp2l = level2l.transform.localPosition;
        temp2l.z += amount;
        level2l.transform.localPosition = temp2l;

        Vector3 temp1l = level1l.transform.localPosition;
        temp1l.z += amount * 1.75f;
        level1l.transform.localPosition = temp1l;

        currentExtension -= amount;
    }
}
