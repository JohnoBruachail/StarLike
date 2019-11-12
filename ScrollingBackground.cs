using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBackground : MonoBehaviour
{
    public float scrollSpeed = 0.025f;
    public Transform[] starFields;

	void Start(){
        starFields[1].position = new Vector3 (0, 25, 0);
        starFields[2].position = new Vector3 (0, 50, 0);
	}
	
	void Update(){

        for(int i = 0; i < starFields.Length; i++){
            starFields[i].position = new Vector3 (starFields[i].position.x, starFields[i].position.y - scrollSpeed, starFields[i].position.z);
            if(starFields[i].position.y <= -25){
                starFields[i].position = new Vector3 (starFields[i].position.x, 50, starFields[i].position.z);
            }
        }

	}
}
