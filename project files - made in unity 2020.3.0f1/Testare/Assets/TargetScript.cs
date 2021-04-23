using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetScript : MonoBehaviour
{

    [SerializeField]
    int HP;

    public void TakeDamage(int dmg)
    {
        HP -= dmg;
        if (HP <= 0) Destroy(gameObject);
    }
}
