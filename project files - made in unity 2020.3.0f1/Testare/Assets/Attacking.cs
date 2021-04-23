using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacking : MonoBehaviour
{
    Animator animController;
    Movement move;

    void Start()
    {
        animController = this.gameObject.GetComponent<Animator>();
        move = this.gameObject.GetComponent<Movement>();
        
    }



    // Update is called once per frame
    void Update()
    {

        if(move.isCarrying == true && Input.GetMouseButton(0))
        {
            if(move.carryType == "Gun")
            {
                move.animController.SetBool("Shooting", true);
            }
            else if(move.carryType == "Sword")
            {
                move.animController.SetBool("Slashing", true);
            }
        }
        else
        {
            move.animController.SetBool("Shooting", false);
            move.animController.SetBool("Slashing", false);
        }
    }
}
