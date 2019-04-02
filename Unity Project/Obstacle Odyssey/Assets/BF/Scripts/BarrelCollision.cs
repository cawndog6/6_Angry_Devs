﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelCollision : MonoBehaviour
{
    // bind audio
    AudioHandler audioHandler;
    void Start() {
        audioHandler = AudioHandler.instance;
    }

    private float damage = 25;

    private void OnTriggerEnter(Collider other)
    {
        GameObject.Find("Scripts").SendMessage("HealthChangeDamage", damage);
        audioHandler.PlayAudio("barrel impact");
        Destroy(gameObject);
    }
}

