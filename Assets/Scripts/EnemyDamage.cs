using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour {
    //[SerializeField] Transform parent;
    [SerializeField] int hitPoints = 10;
    [SerializeField] ParticleSystem hitParticlePrefab;
    [SerializeField] ParticleSystem deathFX;


	// Use this for initialization
	void Start () {
        AddBoxCollider();
        OnParticleCollision(gameObject);
		
	}


    private void AddBoxCollider()
    {
        Collider boxCollider = gameObject.AddComponent<BoxCollider>();
        boxCollider.isTrigger = false;
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
        var fx = Instantiate(deathFX, transform.position, Quaternion.identity);
        fx.Play();
        //fx.transform.parent = parent;
        Destroy(gameObject);
    }
}
