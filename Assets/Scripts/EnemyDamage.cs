using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour {
    [SerializeField] GameObject deathFX;
    [SerializeField] Transform parent;
    [SerializeField] int hitPoints = 10;
    //[SerializeField]Collider collisionMesh;


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
        if (hitPoints < 1)
        {
            KillEnemy();
        }
    }

    private void ProcessHits()
    {
        hitPoints = hitPoints - 1;
    }

    private void KillEnemy()
    {
        GameObject fx = Instantiate(deathFX, transform.position, Quaternion.identity);
        fx.transform.parent = parent;
        Destroy(gameObject);
    }
}
