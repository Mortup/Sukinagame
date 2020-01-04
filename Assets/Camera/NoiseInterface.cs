using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class NoiseInterface : MonoBehaviour
{
    CinemachineBasicMultiChannelPerlin perlinNoise;
    private float targetGain;

    private void Awake() {
        perlinNoise = GetComponent<CinemachineVirtualCamera>().GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        targetGain = perlinNoise.m_AmplitudeGain;
    }

    public void SetNoise(float gain) {
        perlinNoise.m_AmplitudeGain = gain;
        targetGain = gain;
    }

    public void MoveNoise(float targetGain) {
        this.targetGain = targetGain;
    }

    private void Update() {
        perlinNoise.m_AmplitudeGain = Mathf.MoveTowards(perlinNoise.m_AmplitudeGain, targetGain, Time.deltaTime);
    }
}
