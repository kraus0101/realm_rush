using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour {
    [SerializeField] Transform objectToPan;
    [SerializeField] Transform targetEnemy;
    [SerializeField] GameObject gun; 

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        objectToPan.LookAt(targetEnemy);
	}

    private void SetGunsActive(bool isActive){
        var emissionModule = gun.GetComponent<ParticleSystem>().emission;
        emissionModule.enabled = isActive;
    }
}
