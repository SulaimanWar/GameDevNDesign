using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : Singleton<LevelManager>
{
    public Transform Boss { get; set; }
    public Transform Player { get; set; }
    
    private void Awake()
    {
        //Boss = GameObject.Find("Enemy Boss/Boss").transform;
	}
}