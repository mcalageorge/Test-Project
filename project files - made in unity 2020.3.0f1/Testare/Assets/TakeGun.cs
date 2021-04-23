using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeGun : MonoBehaviour
{
    public Transform handTransform;

    public bool isHolding = false;

    public RegisterItem items;

    Movement move;

    void Start()
    {
        move = this.gameObject.GetComponent<Movement>();
    }

    GameObject heldItem;


    // pick up weapon or drop it by pressing E or Q. Picking up a weapon while already having one will drop the held one first.
    void Update()
    {
        //pickup item
        if (Input.GetKey(KeyCode.E) && items.itemRegistered == true)
        {
            Drop();
            PickUp(items.lastGunRegistered, items.lastSwordRegistered);  
        }
        //drop item
        if (Input.GetKey(KeyCode.Q) && isHolding == true)
        {
            Drop();
        }
    }

    public Animator animController;

    // pick up weapon from the ground depending if it is a sword or gun, place it differently in character's hand + start animation for specific type of weapon

    void PickUp(GameObject gun, GameObject sword)
    {

        if (gun != null)
        {
            Debug.Log("We Get here Gun");
            gun.GetComponent<BoxCollider>().enabled = false;
            gun.transform.SetParent(handTransform);
            gun.transform.position = handTransform.position;
            gun.transform.rotation = handTransform.rotation;
            gun.transform.Rotate(0, 90, 90);
            gun.GetComponent<Rigidbody>().isKinematic = true;
            gun.GetComponent<Shoot>().enabled = true;
            //gun.GetComponent<Shoot>().muzzleFlash.SetActive(true);

            isHolding = true;
            heldItem = gun.gameObject;
            items.OutPrompt();

            //animation begin
            animController.SetBool("HasGun", true);
            move.carryType = "Gun";
            move.isCarrying = true;
        }
        else if(sword != null)
        {
            Debug.Log("We Get here Sword");
            sword.GetComponent<BoxCollider>().enabled = false;
            sword.transform.SetParent(handTransform);

            sword.transform.position = handTransform.position;
            Vector3 swordPos = handTransform.position;
            swordPos.y -= 0.1f;
            sword.transform.position = swordPos;
            sword.transform.rotation = handTransform.rotation;
            sword.transform.Rotate(0, 90, 90);
            sword.GetComponent<Rigidbody>().isKinematic = true;
            
            isHolding = true;
            heldItem = sword.gameObject;
            items.OutPrompt();

            //animation begin
            animController.SetBool("HasSword", true);
            move.carryType = "Sword";
            move.isCarrying = true;
        }

      
    }

    // drop the weapon in hand by setting parent to null, enabling collision and disabling kinematic state + return to idle animation

    void Drop()
    {
        if (isHolding == true)
        {
            isHolding = false;
            heldItem.transform.parent = null;
            heldItem.GetComponent<Rigidbody>().isKinematic = false;
            heldItem.GetComponent<BoxCollider>().enabled = true;

            //only applies to gun
            if (heldItem.gameObject.tag == "Gun")
            {
                heldItem.GetComponent<Shoot>().enabled = false;
                heldItem.GetComponent<Shoot>().muzzleFlash.SetActive(false);
            }

            //cancel animation
            animController.SetBool("HasGun", false);
            animController.SetBool("HasSword", false);

            move.isCarrying = false;
            move.carryType = "";
        }
    }

}
