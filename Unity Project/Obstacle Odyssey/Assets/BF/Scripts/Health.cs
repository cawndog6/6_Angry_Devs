﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public Text healthText;
    private float healthStart; // starting ship health
    private static float maxHealth; // creates max ship health
    private float oldHealth;
    private float updatedHealth;
    private bool flag = false;
    private bool accessed = false; // will check to make sure method is accessed

    // this will initialize the health hud to the max health value
    void Start()
    {
        Debug.Log("made it here-1");
        if (!accessed)
        {
            
            Debug.Log("made it here");
            healthStart = 100;
            maxHealth = 100;
        }
        else
        {
            healthStart = maxHealth;
        }

        oldHealth = healthStart; // sets old health to starting health
        Debug.Log("value of health = " + healthStart);
        string newHealth = healthStart.ToString(); // converts the float values to a string
        Debug.Log(newHealth + "jfdkslj");
        healthText.text = "Health: " + newHealth + " / " + maxHealth; // alters the text that is displayed to the screen
    }

    // this can be called to decrease health when damage is applied from obstacle
    public virtual void HealthChangeDamage(float healthChange)
    {
        Debug.Log("made it here-3");
        if (flag == false)
        {
            updatedHealth = oldHealth - healthChange; // figures out new health value

            if (updatedHealth <= 0) // checks to make sure health doesn't go over max
            {
                if(flag == false)
                {
                    flag = true;
                }

                updatedHealth = 0; 
                oldHealth = 0;
                healthText.color = Color.red;
                healthText.text = ("You Died!!"); // alters the text that is displayed to the screen
                return;
            }

            string newHealth = (updatedHealth).ToString(); // converts the float values to a string
            oldHealth = oldHealth - healthChange; // changes oldHealth to updated version after being used
            healthText.text = "Health: " + newHealth + " / " + maxHealth; // alters the text that is displayed to the screen
        }
    }

    // this can be called to increase health when a bonus is picked up
    public virtual void HealthChangeBonus(float healthChange)
    {
        updatedHealth = oldHealth - healthChange; // figures out new health value

        if(updatedHealth > maxHealth) // checks to make sure health doesn't go over max
        {
            updatedHealth = maxHealth;
        }

        string newHealth = (updatedHealth).ToString(); // converts the float values to a string
        oldHealth = oldHealth - healthChange; // changes oldHealth to updated version after being used
        healthText.text = "Health: " + newHealth + " / " + maxHealth; // alters the text that is displayed to the screen
    }

    // this can be called to change the MaxHealth value
    public void MaxHealthChange(float newMax) 
    {
        if (newMax > 100)
        {
            maxHealth = newMax;
        }

        else maxHealth = 100;

        accessed = true;
    }

    // this will return the current health value
    public float ReturnHealth()
    {
        return updatedHealth;
    }
}

    
    
