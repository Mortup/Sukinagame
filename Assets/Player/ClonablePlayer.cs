using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClonablePlayer : MonoBehaviour, IClonable {

    [SerializeField] GameObject clonPrefab;

    public GameObject getGameObject() {
        return clonPrefab;
    }

    public string getName() {
        return "Iro";
    }
}
