using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    [SerializeField] float enemyMovement = .5f;
    [SerializeField] ParticleSystem goalParticlePrefab;

	// Use this for initialization
	void Start () {
        PathFinder pathFinder = FindObjectOfType<PathFinder>();
            var path = pathFinder.GetPath();
            StartCoroutine(FollowPath(path));
	}

    IEnumerator FollowPath(List<Waypoint> path)
    {
        foreach (Waypoint waypoint in path) {
            transform.position = waypoint.transform.position;           
            yield return new WaitForSeconds(enemyMovement);
        }
        SelfDestructor();
    }

    private void SelfDestructor()
    {
        var vfx = Instantiate(goalParticlePrefab, transform.position, Quaternion.identity);
        vfx.Play();

        Destroy(vfx.gameObject, vfx.main.duration);
        Destroy(gameObject);
    }

}
