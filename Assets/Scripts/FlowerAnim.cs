using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerAnim : MonoBehaviour
{

    void Start()
    {
        iTween.PunchScale(gameObject, iTween.Hash(
            "looptype", iTween.LoopType.loop,
            "amount", (new Vector3(transform.localScale.x * 01f,transform.localScale.y * 0.1f,transform.localScale.z * 01f))
        ));
    }
}
