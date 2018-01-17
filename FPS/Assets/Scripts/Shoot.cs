using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour {

    public int munitionNumber;
    private float timer;
    private bool canShoot = true;

    public int maxMunition;
    public int chargerNumber;
    public float shootingDelay = 0f;
    public int dammage; 

    public AudioClip shootingAudioClip;
    public AudioClip emptyAudioClip;
    public AudioClip reloadAudioClip;
    public GameObject flamme;

    private AudioSource audioSource;
    private Animator animator;

    private int reloadAnimHash = Animator.StringToHash("reload");
    private int fireAnimHash = Animator.StringToHash("fire");




    // Use this for initialization
    void Start () {

        audioSource = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();

        munitionNumber = maxMunition;

        PanelUI.UpdateCharger(chargerNumber);
        PanelUI.UpdateMunition(munitionNumber);
    }
	
	// Update is called once per frame
	void Update () {

        if (canShoot)
        {
            timer += Time.deltaTime;

            if (Input.GetButton("Fire1"))
            {
                if (munitionNumber > 0 && timer > shootingDelay)
                {
                    audioSource.PlayOneShot(shootingAudioClip);

                    munitionNumber--;

                    PanelUI.UpdateMunition(munitionNumber); 

                    animator.SetTrigger(fireAnimHash);

                    timer = 0;
                }

                else if (munitionNumber == 0)
                {    
                    StartCoroutine(Reload());
                }

                else if (munitionNumber == 0 && chargerNumber == 0)
                {
                    audioSource.PlayOneShot(emptyAudioClip);
                }
            }           
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            StartCoroutine(Reload());
        }

        flamme.GetComponentInChildren<Animator>().SetBool("flamme", Input.GetButton("Fire1"));
        //canShoot = !Input.GetKeyDown(KeyCode.LeftShift);     
    }

    IEnumerator Reload()
    {
        if (chargerNumber > 0)
        {
            canShoot = false;

            animator.SetTrigger(reloadAnimHash);

            audioSource.PlayOneShot(reloadAudioClip);
            munitionNumber = maxMunition;
            chargerNumber--;
            munitionNumber = maxMunition;
            PanelUI.UpdateCharger(chargerNumber);
            PanelUI.UpdateMunition(munitionNumber);

            yield return new WaitForSeconds(1);

            canShoot = true;
        }

        else yield break;    
    }


    
}
