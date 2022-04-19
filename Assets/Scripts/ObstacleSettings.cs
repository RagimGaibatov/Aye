using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSettings : MonoBehaviour
{
    public static ObstacleSettings Instance;
    private float superDashSpeed = 1.3f;

    private void Awake()
    {
        Instance = this;
    }

    public float SuperDashSpeed
    {
        get { return superDashSpeed; }
        private set { superDashSpeed = value; }
    }


    void Update()
    {
        if (Input.GetKey(KeyCode.R))
        {
            SuperDashSpeed += 0.04f * Time.deltaTime;
        }
    }
}