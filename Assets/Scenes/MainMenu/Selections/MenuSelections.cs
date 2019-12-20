﻿using UnityEngine;
using UnityEngine.UI;

public class MenuSelections : MonoBehaviour
{
    [SerializeField] private Sprite[] selections;

    private int currentIndex = 0;

    private Image image;

    private void Awake() {
        image = GetComponent<Image>();
    }

    private void Update() {
        image.sprite = selections[currentIndex];

        if (Input.GetButtonDown("Up")) {
            currentIndex--;
        }
        if (Input.GetButtonDown("Down")) {
            currentIndex++;
        }

        currentIndex = (4 + currentIndex) % 4;
    }
}
