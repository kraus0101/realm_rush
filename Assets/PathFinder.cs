using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour {

    Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();
    Queue<Waypoint> queue = new Queue<Waypoint>();

    [SerializeField] Waypoint startWaypoint, endWaypoint;
    Vector2Int[] directions = { Vector2Int.up, Vector2Int.right, Vector2Int.down, Vector2Int.left };
    [SerializeField] bool isRunning = true; //todo private later
	
    // Use this for initialization
	void Start () {
        
        LoadBlocks();
        ColorStartAndEnd();
        PathFind();
        //ExplorerNeighbor();
	}

    private void PathFind()
    {
        queue.Enqueue(startWaypoint);
        while (queue.Count>0)
        {
            var searchCenter = queue.Dequeue();
            print("Center searched from:" + searchCenter);//todo remove log
            HaltInEndFound(searchCenter);
        }
        print("Finished Pathfinding?");
    }

    private void HaltInEndFound(Waypoint searchCenter)
    {
        if (searchCenter == endWaypoint)
        {
            print("Searching from end noded, therefore stopping");//todo remove log
        }
        isRunning = false;
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
