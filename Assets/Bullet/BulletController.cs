using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BulletController : MonoBehaviour {
    private Vector3 Direction;
    public float Speed = 1.0f;
    public int TimeToDie = 2;
    //public int Tempo = 0;
    private DateTime initialTime;
    public void SetDirection(Vector3 vec)
    {
        Direction = vec;
    }
	// Use this for initialization
	void Start () {
        initialTime = DateTime.Now;
	}
	
    private int CalculateLifetime()
    {
        var currentTime = DateTime.Now;
        return (currentTime - initialTime).Seconds;
    }
    // Update is called once per frame
    void Update () {
        transform.position = transform.position + Direction * Time.deltaTime * Speed;
        var life = CalculateLifetime();
        Debug.Log(life);
        if(life > TimeToDie)
        {
            Destroy(gameObject);
        }
	}
}
