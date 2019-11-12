using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    int health;
    bool iFramesEnabled;
    bool toggleBool = true;
    public MeshRenderer shield;

    int currentShieldMaterial;

    public Material[] shieldMaterial = new Material[3];

    // Start is called before the first frame update
    void Start()
    {
        health = 3;
        currentShieldMaterial = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Vulnerable(){
        iFramesEnabled = false;
        CancelInvoke();
    }

    void FlashShield(){
        toggleBool = !toggleBool;
        shield.enabled = toggleBool;
        Invoke("FlashShield", 0.2f);
    }

    void OnCollisionEnter(Collision other){
        if(other.gameObject.tag.Equals("Rock")){
            
            if(!iFramesEnabled){
                health--;
                if(currentShieldMaterial < 2){
                    currentShieldMaterial++;
                }
                
                shield.material = shieldMaterial[currentShieldMaterial];

                if(health <= 0){
                    this.gameObject.SetActive(false);
                }else{
                    iFramesEnabled = true;
                }

                Invoke("Vulnerable", 2);
                Invoke("FlashShield", 0.2f);
            }
        }
    }
}
