using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour {
    //[SerializeField] Transform parent;
    [SerializeField] Collider collisionMesh;
    [SerializeField] int hitPoints = 10;
    [SerializeField] ParticleSystem hitParticlePrefab;
    [SerializeField] ParticleSystem deathParticlePrefab;


	// Use this for initialization
	void Start () {
		
	}

    private void OnParticleCollision(GameObject other)
    {
        ProcessHits();
        if (hitPoints <= 1)
        {
            KillEnemy();
        }
    }

    private void ProcessHits()
    {
        hitPoints = hitPoints - 1;
        hitParticlePrefab.Play();
    }

    private void KillEnemy()
    {
        var vfx = Instantiate(deathParticlePrefab, transform.position, Quaternion.identity);
        vfx.Play();
        //fx.transform.parent = parent;
        Destroy(gameObject);
    }
}
