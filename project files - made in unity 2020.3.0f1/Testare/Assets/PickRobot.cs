using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickRobot : MonoBehaviour
{
    public GameObject[] bots;
    public Rotation[] rotations;

    public GameObject[] pickUp;



    public ShopUI shop;


    // Start is called before the first frame update
    void Awake()
    {
        

        try
        {

            GameObject undestroyable = GameObject.FindGameObjectWithTag("Undestroyable");
            string characterType = undestroyable.gameObject.GetComponent<IntroScript>().characterType;

            if (characterType == "Y")
            {
                bots[0].SetActive(true);
                shop.rot = rotations[0];
                shop.player = pickUp[0].transform;
            }
            else
            {
                bots[1].SetActive(true);
                shop.rot = rotations[1];
                shop.player = pickUp[1].transform;
            }

            Destroy(undestroyable);
            Destroy(this.gameObject);
        }
        catch
        {
            bots[0].SetActive(true);
            shop.rot = rotations[0];
            shop.player = pickUp[0].transform;
            Destroy(this.gameObject);
        }
        
    }

    
}
