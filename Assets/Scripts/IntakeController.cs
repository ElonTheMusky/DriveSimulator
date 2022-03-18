using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntakeController : MonoBehaviour
{

    public static bool stowed = true;

    public static GameObject Intake;

    public static bool IntakePower;
    // Start is called before the first frame update

    // Update is called once per frame

    void Start() {
        Intake = gameObject;
    }
    void FixedUpdate()
    {

        if (IntakePower)
        {
            if (stowed)
            {
                Intake.GetComponent<Animator>().Play("IntakeOut");
            }
            stowed = false;
        }
        else
        {
            if (!stowed)
            {
                Intake.GetComponent<Animator>().Play("IntakeIn");
            }
            stowed = true;
        }
    }
}