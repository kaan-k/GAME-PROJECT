﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
public class cameraController : MonoBehaviour
{
    public Transform target;
    public Tilemap theMap;
    private Vector3 bottomLeftLimit;
    private Vector3 topRightLimit;

    private float halfHeight;
    private float halfWidth;
    void Start()
    {
        //Script execution order.
        //---target = characterScript.instance.transform;
        target = FindObjectOfType<characterScript>().transform;
        halfHeight = Camera.main.orthographicSize;
        halfWidth = halfHeight*Camera.main.aspect;

        bottomLeftLimit = theMap.localBounds.min + new Vector3(halfWidth,halfHeight,0f);
        topRightLimit = theMap.localBounds.max + new Vector3(-halfWidth,-halfHeight,0f);
        characterScript.instance.SetBounds(theMap.localBounds.min,theMap.localBounds.max);
    }
    void LateUpdate()
    {
        transform.position = new Vector3(target.position.x,target.position.y,transform.position.z);

        //Keep the camera inbounds.

        transform.position = new Vector3(Mathf.Clamp(transform.position.x,bottomLeftLimit.x,topRightLimit.x),Mathf.Clamp(transform.position.y,bottomLeftLimit.y,topRightLimit.y),transform.position.z);
    }
}
