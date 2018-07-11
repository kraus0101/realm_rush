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
	}

    private void PathFind()
    {
        queue.Enqueue(startWaypoint);
        while (queue.Count>0 && isRunning == true)
        {
            var searchCenter = queue.Dequeue();
            print("Searching from:" + searchCenter);//todo remove log
            HaltInEndFound(searchCenter);
            ExplorerNeighbor(searchCenter);
            searchCenter.isExplored = true;
        }
        //todo work out path!
        print("Finished Pathfinding?");
    }

    private void HaltInEndFound(Waypoint searchCenter)
    {
        if (searchCenter == endWaypoint)
        {
            print("Searching from end noded, therefore stopping");//todo remove log
            isRunning = false;
        }
    }

    private void ExplorerNeighbor(Waypoint from)
    {
        if (!isRunning) { return; }
        foreach (Vector2Int direction in directions)
        {
            Vector2Int neighborCoordinates = from.GetGridPos() + direction;
            try
            {
                QueNewNeighbors(neighborCoordinates);
            }
            catch {
                //do nothing
            }
        }
    }

    private void QueNewNeighbors(Vector2Int neighborCoordinates)
    {
        Waypoint neighbor = grid[neighborCoordinates];
        if (neighbor.isExplored)
        {   
            //do nothing
        }
        else{
            neighbor.SetTopColor(Color.black);
            queue.Enqueue(neighbor);
            print("Queuing" + neighbor);
            neighbor.isExplored = true;
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
