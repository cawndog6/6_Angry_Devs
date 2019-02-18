﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Control : MonoBehaviour
{
    public float Max_Speed;
    public float Accel_Rate = 1000;
    public float Decel_Rate = 1000;
    public float Turn_Rate  = 250;
    public float Turn_Speed = 5.0f;
    public float Bank_Scale = 8.0f; 
    public Rigidbody rigid;
    private KeyCode Accelerate = KeyCode.W;
    private KeyCode Port = KeyCode.A;
    private KeyCode Starboard = KeyCode.D;
    private KeyCode Decelerate = KeyCode.S;
    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(Accelerate))
        {
            Debug.Log("Speeding up");
            rigid.AddForce(Accel_Rate, 0.0f, 0.0f);
        }
        if(Input.GetKey(Port))
        {
            Debug.Log("Turning Left");
            rigid.AddForce(0.0f, 0.0f, Turn_Rate);
            //transform.Rotate(Vector3.left * Time.deltaTime * 10.0f);

        }
        if (Input.GetKey(Starboard))
        {
            Debug.Log("Turning Right");
            rigid.AddForce(0.0f, 0.0f, -Turn_Rate);
            //transform.Rotate(Vector3.right * Time.deltaTime * 10.0f);
        }
        if (Input.GetKey(Decelerate))
        {
            Debug.Log("Slowing Down");
            rigid.AddForce(-Decel_Rate, 0.0f, 0.0f);
        }
    }
}
