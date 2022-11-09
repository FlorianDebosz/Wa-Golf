using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CameraControl : MonoBehaviour
{
    [SerializeField] private GameObject ball;
    [SerializeField] private float offset = 3.5f;
    [SerializeField] private float x = 0f;
    [SerializeField] private float y = 0f;
    [SerializeField] private Quaternion cameraRotation;
    [SerializeField] private Touch touch;

    void Start()
    {
        x = transform.eulerAngles.y; //Due to the fact that we rotate on 2 axes not 3
        y = transform.eulerAngles.x;
    }

    void LateUpdate()
    {
        //If we are on computer
        #if UNITY_EDITOR || UNITY_STANDALONE
            x += Input.GetAxis("Mouse X") * 3;
        #endif

        //If we are on Mobile
        #if UNITY_ANDROID || UNITY_IPHONE
            if(Input.touches.Length == 1) {
                x += Input.getTouch(0).deltaPosition.x * 0.1f;
            }
        #endif

        if(!EventSystem.current.IsPointerOverGameObject()) {
            cameraRotation = Quaternion.Euler(y,x,0);
        }

        Vector3 cameraPosition = cameraRotation * new Vector3(0f, ball.transform.position.y / 3, -offset) + ball.transform.position;

        transform.position = cameraPosition;
        transform.rotation = cameraRotation; 

        if(transform.position.y < 2.5f) {
            transform.position = new Vector3(transform.position.x,2.5f, transform.position.z);
        }
    }
}
