using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehavior : MonoBehaviour
{
    public bool fired;
    public float speed;
    private PowerBar powerBar;
    private GameObject target;
    private GameObject ship;
    private GameObject beamTarget;
    public Rigidbody rigidbody;

    // Start is called before the first frame update

    void Awake(){
        ship = GameObject.Find("Ship");
        powerBar = GameObject.Find("PowerBar").GetComponent<PowerBar>();
        target = ship;
        beamTarget = GameObject.Find("BeamTarget");
    }

    // Update is called once per frame
    void Update(){

       
    }

    public void Fire(){
        fired = true;
        target = ship;
        speed += Time.deltaTime / 10;
        Vector3 moveDirection = (target.transform.position - transform.position).normalized * speed;
        rigidbody.AddForce(moveDirection, ForceMode.Impulse);

    }

    void OnTriggerEnter(Collider other){
        
    }

    void OnTriggerStay(Collider other){

        if(other.gameObject.tag.Equals("Beam")){

            Debug.Log("beam collision" );

            //Vector3 moveDirection = (beamTarget.transform.position - transform.position).normalized * repulsorStrength;
            
            if(powerBar.usingPower){

                rigidbody.AddForce(beamTarget.transform.position.x * 4, beamTarget.transform.position.y * 4, 0);

            }else{

                rigidbody.AddForce(beamTarget.transform.position.x, beamTarget.transform.position.y, 0);

            }

        }
        
    }

    void OnTriggerExit(Collider other){
        if(other.gameObject.tag.Equals("Spawner")){
            this.gameObject.SetActive(false);
        }
    }

    void OnCollisionEnter(Collision collision){
        if(collision.gameObject.tag.Equals("Shield")){
            //fired = false;
        }
    }
    
}
