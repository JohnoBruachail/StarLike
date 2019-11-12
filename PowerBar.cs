using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CodeMonkey;

public class PowerBar : MonoBehaviour {

    public bool usingPower;

    private float barMaskWidth;
    private float powerAmount;
    private float powerCost;
    private float powerRegenAmount;

    public const int POWER_MAX = 100;

    public RectTransform barMaskRectTransform;
    public RectTransform edgeRectTransform;
    public RawImage barRawImage;
    public ParticleSystem[] repulsorBeamParticleSystems;

    private void Awake() {

        barMaskWidth = barMaskRectTransform.sizeDelta.x;

        powerAmount = 0;
        powerCost = 20f;
        powerRegenAmount = 25f;
    }

    private void Update() {

        if(usingPower){
            powerAmount -= powerCost * Time.deltaTime;
            powerAmount = Mathf.Clamp(powerAmount, 0f, POWER_MAX);

        }else{
            powerAmount += powerRegenAmount * Time.deltaTime;
            powerAmount = Mathf.Clamp(powerAmount, 0f, POWER_MAX);
        }

        Rect uvRect = barRawImage.uvRect;
        uvRect.x += .2f * Time.deltaTime;
        barRawImage.uvRect = uvRect;

        Vector2 barMaskSizeDelta = barMaskRectTransform.sizeDelta;
        barMaskSizeDelta.x = (powerAmount / POWER_MAX) * barMaskWidth;
        barMaskRectTransform.sizeDelta = barMaskSizeDelta;

        edgeRectTransform.anchoredPosition = new Vector2((powerAmount / POWER_MAX) * barMaskWidth, 0);
        edgeRectTransform.gameObject.SetActive((powerAmount / POWER_MAX) < 1f);
    }

    public void UsePower(){
        usingPower = true;

        foreach(ParticleSystem ps in repulsorBeamParticleSystems){
            var main = ps.main;
            main.simulationSpeed = 2;
        }
    }
    public void StopUsingPower(){
        usingPower = false;
        foreach(ParticleSystem ps in repulsorBeamParticleSystems){
            var main = ps.main;
            main.simulationSpeed = 1;
        }
    }

}