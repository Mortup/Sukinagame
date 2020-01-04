using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Swirler : MonoBehaviour
{
    [SerializeField] float swirlSpeed;
    [SerializeField] Material material;

    float targetSwirl;

    private void Awake() {
        material = Instantiate(GetComponent<RawImage>().material);
        GetComponent<RawImage>().material = material;
    }

    private void Start() {
        targetSwirl = 0f;
    }

    public void Swirl() {
        targetSwirl = 30f;
    }

    private void Update() {
        material.SetFloat("_Strength", Mathf.Lerp(material.GetFloat("_Strength"), targetSwirl, swirlSpeed));
    }
}
