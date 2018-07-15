using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    [SerializeField] GameObject deathFX;
    [SerializeField] Transform parent;
    [SerializeField]int hits = 10;

	// Use this for initialization
	void Start () {
        AddBoxCollider();
        OnParticleCollision(gameObject);
        PathFinder pathFinder = FindObjectOfType<PathFinder>();
        var path = pathFinder.GetPath();
        StartCoroutine(FollowPath(path));

	}

    private void AddBoxCollider()
    {
        Collider boxCollider = gameObject.AddComponent<BoxCollider>();
        boxCollider.isTrigger = false;
        print("BoxCollide");//todo remove log
    }

    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();
        if (hits < 1)
        {
            KillEnemy();
        }
    }

    private void ProcessHit(){
        hits = hits - 1;
    }

    private void KillEnemy()
    {
        GameObject fx = Instantiate(deathFX, transform.position, Quaternion.identity);
        fx.transform.parent = parent;
        Destroy(gameObject);
        print("enemiy is killed");//todo remove log
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
