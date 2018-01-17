using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedicBag : MonoBehaviour {

    public AudioClip medicBoxAudioClip;

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
        audioSource.PlayOneShot(medicBoxAudioClip);

        PanelUI.UpdateCharaterHealth();
    }
}
