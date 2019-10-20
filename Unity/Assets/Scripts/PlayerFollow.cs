using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollow : MonoBehaviour {

    /// <summary>
    /// Object on which camera is pointed
    /// </summary>
    public Transform PlayerTransform;
    [Range(0.01f, 1.0f)]
    public float SmoothFactor = 0.5f;
    public bool LookAtPlayer = true;
    public bool RotateAroundPlayer = true;
    public float RotationsSpeed = 5.0f;

    private Vector3 _cameraOffset;
    private float _cameraAngleX;

    // Use this for initialization
    void Start () {
        _cameraAngleX = transform.eulerAngles.x;
        _cameraOffset = transform.position - PlayerTransform.position;	
	}
	
	// LateUpdate is called after Update methods
	void LateUpdate () {

        if(RotateAroundPlayer)
        {
            Quaternion camTurnAngle = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * RotationsSpeed, Vector3.up);

            _cameraOffset = camTurnAngle * _cameraOffset;
        }

        Vector3 newPos = PlayerTransform.position + _cameraOffset;

        transform.position = Vector3.Slerp(transform.position, newPos, SmoothFactor);
        transform.LookAt(PlayerTransform);

        if (LookAtPlayer && RotateAroundPlayer)
        {
            transform.LookAt(PlayerTransform);
        }
        else if (RotateAroundPlayer)
        {
            transform.LookAt(PlayerTransform);
            transform.eulerAngles = new Vector3(_cameraAngleX, transform.eulerAngles.y, transform.eulerAngles.z);
        }
	}
}
