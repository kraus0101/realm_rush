using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour {
    [SerializeField] GameObject deathFX;
    [SerializeField] Transform parent;
    [SerializeField] int hits = 10;
    //[SerializeField]Collider collisionMesh;


	// Use this for initialization
	void Start () {
        AddBoxCollider();
        OnParticleCollision(gameObject);
		
	}

    //void OnCollisionEnter() {
    //  print("I am hit!");
    //}

    private void AddBoxCollider()
    {
        Collider boxCollider = gameObject.AddComponent<BoxCollider>();
        boxCollider.isTrigger = false;
    }

    private void OnParticleCollision(GameObject other)
    {
        //print("I am hit!");
        hits = hits - 1;
        if (hits<1) {
            KillEnemy();
        }

    }

    private void KillEnemy()
    {
        GameObject fx = Instantiate(deathFX, transform.position, Quaternion.identity);
        fx.transform.parent = parent;
        Destroy(gameObject);
        print("Enemy is killed");//todo remove log
    }
}
