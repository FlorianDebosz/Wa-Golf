using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shot : MonoBehaviour
{
    [SerializeField] private RectTransform powerBar;
    [SerializeField] private bool powerActivate  = false;
    [SerializeField] private float value = 0.1f;
    [SerializeField] private float multiplicatedStrength = 100;
    [SerializeField] private GameObject ball;
    [SerializeField] private bool canShot = true;
    [SerializeField] private GameObject shotButton;
    [SerializeField] private GameObject GuideLine;

    private bool checkSpeed = false;
    
    private void Awake() {
        #if (UNITY_EDITOR || UNITY_STANDALONE)
            shotButton.SetActive(false);
        #endif
    }
    private void Update() {
        if(Input.GetMouseButtonUp(1)){
            HandleShot();
        }
    }

    private void FixedUpdate() {
        if(ball.GetComponent<Rigidbody>().velocity.magnitude <= 0.2f && checkSpeed){
            canShot = true;
        }    
    }

    public void HandleShot() {
        if(canShot) {
            if(!powerActivate) {
                GuideLine.SetActive(true);
                ActivatePowerBar();
            }else {
                canShot = false;
                ShotBall();
                GuideLine.SetActive(false);
            }
        }

    }
    public void ActivatePowerBar() {
        powerActivate = true;
        StartCoroutine("AnimatePowerBar");
    }

    public void ShotBall() {
        powerActivate = false;
        StopAllCoroutines();
        float shotPower = powerBar.localScale.x * multiplicatedStrength;
        ball.GetComponent<Rigidbody>().AddForce(Camera.main.transform.forward * shotPower);
        StartCoroutine("ActivateCheckSpeed");
    }

    IEnumerator ActivateCheckSpeed(){
        yield return new WaitForSeconds(1);
        checkSpeed = true;
    }

    IEnumerator AnimatePowerBar() {
        while (powerActivate) {
            yield return new WaitForSeconds(0.1f);
            powerBar.localScale = new Vector3(powerBar.localScale.x - value,powerBar.localScale.y,powerBar.localScale.z);
            if (powerBar.localScale.x <= 0.1f) {
                value = -0.1f;
            }else if(powerBar.localScale.x >= 1f){
                value = 0.1f;
            }
        }
    }
}
