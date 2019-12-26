using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SillaClonable : MonoBehaviour, IClonable {
    public GameObject getGameObject() {
        return gameObject;
    }

    public string getName() {
        return "Silla";
    }
}
