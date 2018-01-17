using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastShoot : MonoBehaviour {


    Vector3 viewFinder;
    RaycastHit hit;
    Ray ray;

    public GameObject bulletImpact;


	// Use this for initialization
	void Start () {

        viewFinder = new Vector3(Screen.width / 2, Screen.height / 2, 0);
       
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetButton("Fire1"))
        {
            ray = Camera.main.ScreenPointToRay(viewFinder);

            if (Physics.Raycast(ray, out hit , Camera.main.farClipPlane))
            {
                if (hit.collider.tag == "ennemi")
                {
                    hit.collider.GetComponent<Enemy>().enemyHealth -=  GetComponent<Shoot>().dammage;
                }

                else
                {
                    GameObject toInstantiate = Instantiate(bulletImpact, hit.point, hit.transform.rotation);
                    Destroy(toInstantiate, 5);
                }
                
            }

            
        }
        
		
	}
}
