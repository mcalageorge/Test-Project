using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RegisterItem : MonoBehaviour
{
    public GameObject lastGunRegistered;
    public GameObject lastSwordRegistered;
    public bool itemRegistered;

    public Image interactionPrompt;

    // when a collision with a weapon is done, it is recorded thorough this

    void OnTriggerEnter(Collider weapon)
    {
        Debug.Log("Triggered weapon, tag of it is " + weapon.gameObject.tag);
        

        if (lastGunRegistered == null && lastSwordRegistered == null && weapon.gameObject.tag != "target")
        {
            InPrompt();
            itemRegistered = true;

            if (weapon.gameObject.tag == "Gun")
            {
                lastGunRegistered = weapon.gameObject;       
            }
            else if (weapon.gameObject.tag == "Sword")
            {                
                lastSwordRegistered = weapon.gameObject;
            }
        }
    }

   
    // releases reference to weapon encountered on the ground

    void OnTriggerExit(Collider col)
    {
        OutPrompt();
        lastGunRegistered = null;
        lastSwordRegistered = null;
        itemRegistered = false;
        Debug.Log("Denounced all registrations, through trigger");
    }

    // enables pick up prompt on screen

    public void InPrompt()
    {
        interactionPrompt.gameObject.SetActive(true);

    }

    // disables pick up prompt on screen

    public void OutPrompt()
    {
        interactionPrompt.gameObject.SetActive(false);

    }

}
