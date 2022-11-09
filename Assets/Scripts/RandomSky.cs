using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSky : MonoBehaviour
{
    [SerializeField] private Material[] materials;

    void Start() {
           int random = Random.Range(0, materials.Length);
           RenderSettings.skybox = materials[random];
    }

    void Update() {
        RenderSettings.skybox.SetFloat("_Rotation", 0.8f * Time.time);
    }
}
