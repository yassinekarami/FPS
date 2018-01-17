using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {


    public int enemyHealth = 4;

    Animator animator;

    private int deathAnimHash = Animator.StringToHash("dead");

    // Use this for initialization
    void Start () {

        animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		
        if (enemyHealth <= 0)
        {
            GetComponent<EnemyIA>().enabled = false;
            animator.SetTrigger(deathAnimHash);
            Destroy(gameObject, 5f);
        }
	}

    public void activationIskinematic()
    {
        GetComponent<Rigidbody>().isKinematic = false;
    }
}
