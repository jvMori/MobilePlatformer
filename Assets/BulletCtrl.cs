using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCtrl : MonoBehaviour {

    public Vector2 velocity;

    Rigidbody2D rbd;

    void Start () {

        rbd = GetComponent<Rigidbody2D>();
	}
	
	
	void FixedUpdate () {

        rbd.velocity = velocity;
	}
}
