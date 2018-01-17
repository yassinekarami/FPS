using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoBox : MonoBehaviour {

    public AudioClip ammoBoxAudioClip;

    private AudioSource audioSource;
	// Use this for initialization
	void Start () {

        audioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {

            audioSource.PlayOneShot(ammoBoxAudioClip);

            other.gameObject.GetComponentInChildren<Character>().weapon1.GetComponent<Shoot>().chargerNumber++;
            other.gameObject.GetComponentInChildren<Character>().weapon2.GetComponent<Shoot>().chargerNumber++;

            PanelUI.UpdateCharger(other.gameObject.GetComponentInChildren<Character>().currentWeapon.GetComponent<Shoot>().chargerNumber);

            Destroy(this);  


        }
    }
}
