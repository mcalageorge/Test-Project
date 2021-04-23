using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Movement : MonoBehaviour
{

    public float speed;
    public Animator animController;

    public bool isCarrying = false;
    public string carryType;

    void Start()
    {


        animController = this.gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float delta = Time.deltaTime;
        float horiz = Input.GetAxisRaw("Horizontal") * delta * speed;
        float verti = Input.GetAxisRaw("Vertical") * delta * speed;

        Vector3 movement = new Vector3(horiz, 0, verti);

        gameObject.transform.Translate(movement, Space.Self);


        if (isCarrying == false)
        {
            animController.SetBool("CarryingSwordIdle", false);
            animController.SetBool("CarryingGunIdle", false);

            if (verti > 0)
            {
                GetSpeed();
                animController.SetBool("NW Idle", false);
                animController.SetBool("NW Walking", true);
                Debug.Log("Currently Walking");
            }
            else if (verti < 0)
            {
                SlowDown();
                animController.SetBool("NW Idle", false);
                animController.SetBool("NW Walking Back", true);
                Debug.Log("Currently Walking Backwards");
            }
            else
            {
                animController.SetBool("NW Walking", false);
                animController.SetBool("NW Walking Back", false);
                animController.SetBool("NW Idle", true);
                Debug.Log("Stopped Walking");
            }
        }
        else
        {
            animController.SetBool("NW Idle", false);
            animController.SetBool("NW Walking", false);

            if (carryType == "Gun")
            {


                if (verti > 0)
                {
                    GetSpeed();
                    animController.SetBool("CarryingGunWalk", true);
                    animController.SetBool("CarryingGunBack", false);
                    Debug.Log("Currently Walking With Gun");
                }
                else if (verti < 0)
                {
                    SlowDown();
                    animController.SetBool("CarryingGunBack", true);
                    animController.SetBool("CarryingGunWalk", false);
                    Debug.Log("Currently Walking Backwards With Gun");
                }
                else
                {

                    animController.SetBool("CarryingGunBack", false);
                    animController.SetBool("CarryingGunWalk", false);
                    animController.SetBool("CarryingGunIdle", true);
                    Debug.Log("Stopped Walking With Gun");
                }
            }
            else if (carryType == "Sword")
            {
                if (verti > 0)
                {
                    GetSpeed();
                    animController.SetBool("CarryingSwordBack", false);
                    animController.SetBool("CarryingSwordWalk", true);
                    Debug.Log("Currently Walking With Sword");
                }
                else if (verti < 0)
                {
                    SlowDown();
                    animController.SetBool("CarryingSwordWalk", false);
                    animController.SetBool("CarryingSwordBack", true);

                    Debug.Log("Currently Walking Backwards With Sword");
                }
                else
                {

                    animController.SetBool("CarryingSwordBack", false);
                    animController.SetBool("CarryingSwordWalk", false);
                    animController.SetBool("CarryingSwordIdle", true);
                    Debug.Log("Stopped Walking With Sword");
                }
            }
        }
    }

    void SlowDown()
    {
        speed = 0.9f;
    }

    void GetSpeed()
    {
        speed = 1.7f;
    }
}
