using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour {

    [SerializeField] Waypoint startWaypoint, endWaypoint;
    Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();
    Vector2Int[] directions = { Vector2Int.right, Vector2Int.up, Vector2Int.left, Vector2Int.down };
	
    // Use this for initialization
	void Start () {
        
        LoadBlocks();
        ColorStartAndEnd();
        ExplorerNeighbor();
	}

    private void ExplorerNeighbor()
    {
        foreach (Vector2Int direction in directions)
        {
            Vector2Int explorationCoordinates = startWaypoint.GetGridPos() + direction;
            print("Exploring X, Y: " + explorationCoordinates);
            try
            {
                grid[explorationCoordinates].SetTopColor(Color.black);
            }
            catch {
                //do nothing
            }
        }
    }

    private void ColorStartAndEnd()
    {
        startWaypoint.SetTopColor(Color.red);
        endWaypoint.SetTopColor(Color.cyan);
    }

    private void LoadBlocks()
    {
        var waypoints = FindObjectsOfType<Waypoint>();
        foreach (Waypoint waypoint in waypoints)
        {
            var gridPos = waypoint.GetGridPos();
            if (grid.ContainsKey(gridPos))
            {
                Debug.LogWarning("Skipping Overlapping block" + waypoint);
            }
            else {
                grid.Add(gridPos, waypoint);
            }
        }
    }

}
