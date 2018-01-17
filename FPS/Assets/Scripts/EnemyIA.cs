using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyIA : MonoBehaviour {

    NavMeshAgent agent;
    Animator animator;

    private GameObject target;

    private int walkAnimHash = Animator.StringToHash("walk");
    private int attackAnimHash = Animator.StringToHash("attack");

    public static bool isActive = true;

	// Use this for initialization
	void Start () {

        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();

        target = GameObject.FindGameObjectWithTag("Player");
		
	}
	
	// Update is called once per frame
	void Update () {

        if (isActive)
        {
            if (Vector3.Distance(target.transform.position, agent.transform.position) <= 10 && Vector3.Distance(target.transform.position, agent.transform.position) > 3)
            {
                agent.SetDestination(target.transform.position);

                animator.SetBool(walkAnimHash, true);

            }

            else if (Vector3.Distance(target.transform.position, agent.transform.position) <= 1.5f)
            {
                animator.SetBool(walkAnimHash, false);

                animator.SetBool(attackAnimHash, true);
            }

            else
            {
                animator.SetBool(walkAnimHash, false);

                animator.SetBool(attackAnimHash, false);
            }   
        }
       
	}

    public void damageToPlayer()
    {
        PanelUI.DecreaseCharacterHealth();
    } 
}
