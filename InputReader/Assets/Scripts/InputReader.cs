using System;
using System.Collections.Generic;
//using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class InputReader : MonoBehaviour {

	public Text consoleAxis;
    public Text consoleKeys;
    public Text consoleJoysticks;

    public string[] joysticks;
    public List<string> axises = new List<string>();

    List<KeyCode> keys = new List<KeyCode>();

    void Awake()
    {
        //ReadAxes();

        foreach (KeyCode item in Enum.GetValues(typeof(KeyCode)))
        {
            keys.Add(item);
        }
    }

    void Update () 
	{
        string printAxis = "AXIS: " + Environment.NewLine + Environment.NewLine;

        for (int i=0; i<axises.Count; i++)
        {
            printAxis += axises[i] + ": " + Input.GetAxis(axises[i]) + Environment.NewLine;
        }

        consoleAxis.text = printAxis;

        string printKeys = "KEYS: " + Environment.NewLine + Environment.NewLine;

        for (int i = 0; i < keys.Count; i++)
        {
            if (Input.GetKey(keys[i]))
            {
                printKeys += " - " + keys[i].ToString() + " - " + Environment.NewLine;
                Debug.Log(keys[i].ToString());
            }            
        }

        consoleKeys.text = printKeys;

        joysticks = Input.GetJoystickNames();
        string printJoysticks = "Joysticks: " + Environment.NewLine + Environment.NewLine;

        for (int i = 0; i < joysticks.Length; i++)
        {
            printJoysticks += " - " + joysticks[i].ToString() + " - " + Environment.NewLine;
            //Debug.Log(joysticks[i].ToString());
        }

        consoleJoysticks.text = printJoysticks;
    }

    //public void ReadAxes()
    //{
    //    var inputManager = AssetDatabase.LoadAllAssetsAtPath("ProjectSettings/InputManager.asset")[0];

    //    SerializedObject obj = new SerializedObject(inputManager);

    //    SerializedProperty axisArray = obj.FindProperty("m_Axes");

    //    if (axisArray.arraySize == 0)
    //        Debug.Log("No Axes");

    //    for (int i = 0; i < axisArray.arraySize; ++i)
    //    {
    //        var axis = axisArray.GetArrayElementAtIndex(i);

    //        var name = axis.FindPropertyRelative("m_Name").stringValue;
    //        var axisVal = axis.FindPropertyRelative("axis").intValue;
    //        var inputType = (InputType)axis.FindPropertyRelative("type").intValue;

    //        if (!axises.Contains(name))
    //        {
    //            axises.Add(name);
    //        }
            

    //        Debug.Log(name);
    //        Debug.Log(axisVal);
    //        Debug.Log(inputType);
    //    }
    //}

    //public enum InputType
    //{
    //    KeyOrMouseButton,
    //    MouseMovement,
    //    JoystickAxis,
    //};
}
