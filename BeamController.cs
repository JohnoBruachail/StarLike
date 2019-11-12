using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeamController : MonoBehaviour
{
    Joystick joystick;

    void Start(){
        joystick = FindObjectOfType<Joystick>();
    }

    // Update is called once per frame
    void Update(){

        //I need the current state of the input to corrispond to the angle of rotation on the beam
        //If the joystick is in X position the rotation should be at X position.

        Vector2 joystickDirection = joystick.Direction;
        //Debug.Log("Current Direction is" + direction);

        this.transform.eulerAngles = new Vector3(0, 0, -joystickDirection.x * 100);
        //Debug.Log("Current Direction is" + joystick.Direction);
        
    }
}
