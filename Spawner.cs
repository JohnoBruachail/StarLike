using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    // Start is called before the first frame update

    int currentAsteroid;
    int yCoordinate = 20;
    int xCoordinate;
    int plusOrMinus;
    Vector3 targetsPosition;

    public int numberOfAsteroids;
    GameObject[] asteroids;
    public GameObject[] asteroidTypes = new GameObject[3];

    //spawn them off screen
    //set them to fly at enemy every x seconds
    //

    void Start(){
        asteroids = new GameObject[numberOfAsteroids];
        currentAsteroid = 0;
        for(int i = 0; i < asteroids.Length; i++){

            asteroids[i] = Instantiate(asteroidTypes[Random.Range(0,asteroidTypes.Length)], new Vector3(0, 30, 0), Quaternion.identity);
            asteroids[i].SetActive(false);

        }

        Invoke("ShootAsteroid", 2);
    }

    // Update is called once per frame
    void Update(){
        
    }

    void ShootAsteroid(){

        Debug.Log("Shooting an Asteroid");

        currentAsteroid = 0;

        while(asteroids[currentAsteroid].activeSelf == true){
            currentAsteroid++;

            if(currentAsteroid >= asteroids.Length){
                currentAsteroid = -1;
                break;
            }
        }

        if(currentAsteroid >= 0){
            yCoordinate = 20;
            xCoordinate = Random.Range(0,20);
            yCoordinate = yCoordinate - xCoordinate;
            xCoordinate = xCoordinate * (Random.Range(0,2) * 2 - 1);

            asteroids[currentAsteroid].transform.position = new Vector3(xCoordinate, yCoordinate, 0);
            asteroids[currentAsteroid].SetActive(true);
            asteroids[currentAsteroid].GetComponent<ProjectileBehavior>().Fire();

        }

        float randomTime = Random.Range(2, 5);
        Invoke("ShootAsteroid", randomTime);
    }
}
