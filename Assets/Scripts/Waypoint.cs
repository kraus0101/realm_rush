﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour {

    //public ok here as is a data class
    public bool isExplored = false;
    public Waypoint exploredFrom;

    Vector2Int girdPos;

    const int gridSize = 10;

    public int GetGridSize () {
        
        return gridSize;
    }

    public Vector2Int GetGridPos()
    {
        return new Vector2Int (
            Mathf.RoundToInt(transform.position.x / gridSize),
            Mathf.RoundToInt(transform.position.z / gridSize)
        );
    }
    void OnMouseOver()
    {
        Debug.Log(gameObject.name);
    }
}
