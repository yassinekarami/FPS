using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {


    public GameObject weapon1;
    public GameObject weapon2;

    public GameObject currentWeapon;

    private int walkAnimHash = Animator.StringToHash("walk");
    private int runAnimHash = Animator.StringToHash("run");

    public static bool isDead = false;

    Animator animator;

	// Use this for initialization  
	void Start () {

        currentWeapon = weapon1;
        animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {

        currentWeapon.GetComponent<Animator>().SetBool(walkAnimHash, Moving(Input.GetAxis("Vertical"), Input.GetAxis("Horizontal")));

        currentWeapon.GetComponent<Animator>().SetBool(runAnimHash, Input.GetKey(KeyCode.LeftShift));

        if (Input.GetKeyDown(KeyCode.F))
        {
            if (currentWeapon == weapon1)
            {
                currentWeapon.SetActive(false);
                currentWeapon = weapon2;
            }

            else if (currentWeapon == weapon2)
            {
                currentWeapon.SetActive(false);
                currentWeapon = weapon1;
            }

            currentWeapon.SetActive(true);

            PanelUI.UpdateMunition(currentWeapon.GetComponent<Shoot>().munitionNumber);
            PanelUI.UpdateCharger(currentWeapon.GetComponent<Shoot>().chargerNumber);
        }

        if (isDead)
        {
            animator.enabled = true;

            EnemyIA.isActive = false;

            currentWeapon.GetComponent<Shoot>().enabled = false;

            GetComponent<Character>().enabled = false;

        }
	}
   
    private bool Moving(float x , float y)
    {
        if (x != 0 || y != 0) return true;

        else return false;
    }
    
}
