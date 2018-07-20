﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

	// Use this for initialization
	void Start () {
        PathFinder pathFinder = FindObjectOfType<PathFinder>();
        var path = pathFinder.GetPath();
        StartCoroutine(FollowPath(path));

	}

    IEnumerator FollowPath(List<Waypoint> path)
    {
        print("Starting Patrol...");
        foreach (Waypoint waypoint in path) {
            transform.position = waypoint.transform.position;           
            yield return new WaitForSeconds(1f);
        }
        print("Ending patrol");
    }

}
