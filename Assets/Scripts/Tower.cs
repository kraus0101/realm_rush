using System;
using UnityEngine;

public class Tower : MonoBehaviour {
    //paremeter
    [SerializeField] Transform objectToPan;
    [SerializeField] ParticleSystem particleProjectile;
    [SerializeField] float attackRange = 10f;

    //state
    Transform targetEnemy;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        SetTargetEnemy();
        if (targetEnemy)
        {
            objectToPan.LookAt(targetEnemy);
            CheckEnemyDistance();
        }
        else {
            SetGunsActive(false);
        }
	}

    private void SetTargetEnemy()
    {
        var sceneEnemies = FindObjectsOfType<EnemyDamage>();
        if (sceneEnemies.Length == 0) { return; }

        Transform closestEnemy = sceneEnemies[0].transform;
        foreach (EnemyDamage testEnemy in sceneEnemies)
        {
            closestEnemy = GetClosest(closestEnemy, testEnemy.transform);
        }
        targetEnemy = closestEnemy;
    }

    private Transform GetClosest(Transform transformA, Transform transformB)
    {
        var distToA = Vector3.Distance(transform.position, transformA.position);
        var distToB = Vector3.Distance(transform.position,transformB.position);

        if (distToA < distToB)
        {
            return transformA;

        }
        return transformB;
    }

    private void CheckEnemyDistance(){
        
        float distanceToEnemy = Vector3.Distance(targetEnemy.position, gameObject.transform.position);
        if (distanceToEnemy <= attackRange) {
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
