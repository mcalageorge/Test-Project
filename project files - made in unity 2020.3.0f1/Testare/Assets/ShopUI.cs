using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopUI : MonoBehaviour
{
    public Transform player;

    public GameObject[] itemsSold;

    public Image shop;

    public Rotation rot;

    bool pressed = false;

    int nWeapons = 0;
    int weaponLimit = 50;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pressed == false)
            {
                rot.allowedRotation = false;
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                pressed = true;
                shop.gameObject.SetActive(true);
            }
            else
            {
                rot.allowedRotation = true;
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
                pressed = false;
                shop.gameObject.SetActive(false);
            }
        }
    }

    public void BuyRifle()
    {
        PurchaseItem(itemsSold[0]);     
    }

    public void BuySword()
    {
        PurchaseItem(itemsSold[1]);
    }

    public void BuyHammer()
    {
        PurchaseItem(itemsSold[3]);
    }

    public void BuyHAMMER()
    {
        PurchaseItem(itemsSold[2]);
    }

    void PurchaseItem(GameObject itemChosen)
    {
        if (CheckWeaponLimit(nWeapons, weaponLimit))
        {
            Instantiate(itemChosen, player.position, Quaternion.identity);
            nWeapons++;
        }
        else Debug.Log("Too many items, please remove them");
        
    }

    public void FindAndDestroy()
    {
        GameObject[] items;


        //find and destroy swords and hammers
        items = GameObject.FindGameObjectsWithTag("Sword");
        foreach (GameObject item in items) 
        
            if (item.gameObject.name != "Sword Handle Important" && item.gameObject.name != "Hammer Handle Important" && item.gameObject.name != "Small Hammer Handle Important") 
                Destroy(item.gameObject); 
        

        items = null;

        //find and destroy guns
        items = GameObject.FindGameObjectsWithTag("Gun");
        
        foreach (GameObject item in items)
        
            if (item.gameObject.name != "Gun Handle Rifle Important")
                Destroy(item.gameObject);


    }

    bool CheckWeaponLimit(int weapons, int limit)
    {
        if (weapons < limit) return true;
        else return false;
    }

    public void CloseGame()
    {
        Application.Quit();
    }
}
