using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public ParticleSystem particles;
    public GameObject muzzleFlash;

    public int damage = 1;
    public float range = 100f;

    float counter = 0f;
    float fireRate = 0.5f;

    public AudioClip shootSound;
    public AudioList sound;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            if (counter <= 0)
            {
                ShootGun();
                counter = fireRate;
            }
            else
            {
                counter -= Time.deltaTime * 3;
            }
            Debug.Log("Debugging counter: " + counter);
        }
    }

    void ShootGun()
    {
        sound.PlayAudioOneShot(shootSound);

        particles.Play();

        RaycastHit ray;

        Debug.DrawRay(muzzleFlash.transform.position, muzzleFlash.transform.forward * 10, Color.green, 2, false);

        if (Physics.Raycast(muzzleFlash.transform.position, muzzleFlash.transform.forward, out ray, range))
        {
            if (ray.transform.gameObject.tag == "Target") ray.transform.gameObject.GetComponent<TargetScript>().TakeDamage(damage);


            Debug.Log("We hit " + ray.transform.gameObject.name + " at " + ray.transform.position);
        } 
       
    }
}
