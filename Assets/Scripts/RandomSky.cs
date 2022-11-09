using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSky : MonoBehaviour
{
    [SerializeField] private Material[] materials;
    // Start is called before the first frame update
    void Start()
    {
           int random = Random.Range(0, materials.Length);
           RenderSettings.skybox = materials[random];
    }
}
