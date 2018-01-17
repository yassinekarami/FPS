using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionScript : MonoBehaviour {

    public GameObject PanelTexte;
    public static bool LockedDoor = true;
	void Start () {
        DesactiveTxt();
       
	}

    private void Update()
    {
        Debug.Log(LockedDoor);
    }

    public void DesactiveTxt () {
        StartCoroutine(DesactivationPanel());

    }

    IEnumerator DesactivationPanel()
    {
        yield return new WaitForSeconds(5f);
        PanelTexte.SetActive(false);
    }
    public void UnlockDoor()
    {
        LockedDoor = false;
    }

    public bool DoorState()
    {
        return LockedDoor;
    }

}
