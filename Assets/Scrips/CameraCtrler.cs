using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCtrler : MonoBehaviour {
	private Camera camera;
	private float mSpeed = 50;

	private Vector2 BroderX = new Vector2(-100,100);
	private Vector2 BroderZ = new Vector2(-100,100);

	// Use this for initialization
	void Start () {
		camera = GetComponent<Camera>();
	}
	
	// Update is called once per frame
	void Update () {
		Move();
	}

    private void Move()
    {
		float h = Input.GetAxis("Horizontal");
		float v = Input.GetAxis("Vertical");
		Vector3 dir = new Vector3(h,0,v);
        if (Input.GetKey(KeyCode.LeftShift)){
			dir *= 3;
        }
		transform.position += dir * Time.deltaTime*mSpeed;
		if (transform.position.x>BroderX.y) {
			transform.position = new Vector3(BroderX.y,transform.position.y,transform.position.z);
		}
		else if (transform.position.x < BroderX.x)
		{
			transform.position = new Vector3(BroderX.x, transform.position.y, transform.position.z);
		}
		else if(transform.position.z > BroderZ.y)
		{
			transform.position = new Vector3(transform.position.x, transform.position.y, BroderZ.y );
		}
		else if(transform.position.z < BroderZ.x)
		{
			transform.position = new Vector3(transform.position.x, transform.position.y, BroderZ.x);
		}

		float mouseScrollWheel = Input.GetAxis("Mouse ScrollWheel");
        if (mouseScrollWheel > 0&&camera.fieldOfView<60)
        {
			camera.fieldOfView += mouseScrollWheel * 10 * 5;
        }
		else if (mouseScrollWheel < 0 & camera.fieldOfView > 10)
        {
			camera.fieldOfView -= mouseScrollWheel * -10 * 5;
        }


	}
}
