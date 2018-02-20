using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCamera : MonoBehaviour {
    Vector3 _offset = new Vector3(0, 1.5f, 0);
    public Player _lookTarget;

    float verticalAngle = 10.0f;
    float horizontalAngle = 0.0f;
    float distance = 5.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (_lookTarget != null)
        {
            Vector3 startLookPosition = _lookTarget.GetPosition() + _offset;
            //Vector3 relativePos = Quaternion.Euler(verticalAngle, horizontalAngle, 0) * new Vector3(0, 0, -distance);
            Vector3 relativePos = _lookTarget.GetRotation() * new Vector3(0, 0, -distance);
            transform.position = startLookPosition + relativePos;

            Vector3 endLookPosition = _lookTarget.GetPosition() + _offset;
            transform.LookAt(endLookPosition);
        }
	}
}
