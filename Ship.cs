using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    public GameObject explosion;
    public GameObject deathScreen;
    public MeshRenderer ship;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision other){
        if(other.gameObject.tag.Equals("Rock")){

            explosion.SetActive(true);
            ship.enabled = false;
            Invoke("Dead", 2f);
        }
    }

    void Dead(){
        
        deathScreen.SetActive(true);
        Time.timeScale = 0f;
        //pause game, load death screen, show score ect.
    }
}
