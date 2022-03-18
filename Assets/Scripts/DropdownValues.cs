using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.Events;
using UnityEngine.UI;

public class DropdownValues : MonoBehaviour
{
    const string PrefName = "optionValue";

    public Dropdown dropdownController, dropdownDrive, dropdownGraphics;

    void Awake() {
        dropdownController.onValueChanged.AddListener(new UnityAction<int>(index => {
            PlayerPrefs.SetInt("controllerType", dropdownController.value);
        }));

        dropdownDrive.onValueChanged.AddListener(new UnityAction<int>(index => {
            PlayerPrefs.SetInt("driveType", dropdownDrive.value);
        }));

        dropdownGraphics.onValueChanged.AddListener(new UnityAction<int>(index => {
            PlayerPrefs.SetInt("graphics", dropdownGraphics.value);
        }));
        PlayerPrefs.Save();
    }
    void Start()
    {
        dropdownController.value = PlayerPrefs.GetInt("controllerType", 1);
        dropdownDrive.value = PlayerPrefs.GetInt("driveType", 0);
        dropdownGraphics.value = PlayerPrefs.GetInt("graphics", 0);
    }
}
