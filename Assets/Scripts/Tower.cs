using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour {
    [SerializeField] Transform objectToPan;
    [SerializeField] Transform targetEnemy;
    [SerializeField] ParticleSystem particleProjectile;
    [SerializeField] float attackRange = 10f;


	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        if (targetEnemy)
        {
            objectToPan.LookAt(targetEnemy);
            CheckEnemyDistance();
        }
        else {
            SetGunsActive(false);
        }
	}

    private void CheckEnemyDistance(){
        
        float enemyDistance = Vector3.Distance(targetEnemy.position, gameObject.transform.position);
        if (enemyDistance < attackRange) {
            SetGunsActive(true);
        }
        else {
            SetGunsActive(false);
        }
    }

    private void SetGunsActive(bool isActive){
        var emissionModule = particleProjectile.emission;
        emissionModule.enabled = isActive;
    }
}
