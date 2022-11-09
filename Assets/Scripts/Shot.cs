using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shot : MonoBehaviour
{
    [SerializeField] private RectTransform powerBar;
    [SerializeField] private bool powerActivate  = false;
    [SerializeField] private float time = 0.1f;

    public void ActivatePowerBar() {
        powerActivate = true;
        StartCoroutine("AnimatePowerBar");
    }

    IEnumerator AnimatePowerBar() {
        while (powerActivate == true) {
            yield return new WaitForSeconds(0.1f);
            powerBar.localScale = new Vector3(powerBar.localScale.x - time,powerBar.localScale.y,powerBar.localScale.z);
            if (powerBar.localScale.x < 0.1f) {
                time = -time;
            }else if(powerBar.localScale.x > 0.9f){
                time = -time;
            }
            }
    }
}
