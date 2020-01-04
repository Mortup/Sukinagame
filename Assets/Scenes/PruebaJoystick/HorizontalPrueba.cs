using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HorizontalPrueba : MonoBehaviour
{
    [SerializeField] private Text texto;
    
    void Update()
    {
        texto.text = "Horizontal Input\n" + Input.GetAxis("Horizontal").ToString();
    }
}
