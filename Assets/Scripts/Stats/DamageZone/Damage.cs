using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    public Transform target;

    private string playerTag = "Player";

    public int damage = 17;
    void OnTriggerEnter(Collider other)
    {
        print("Work00");
        if(other.tag == playerTag)
        {
            print("Work01");
            //equal to the HealthBarScript script component
            HealthBarScript health = other.GetComponent<HealthBarScript>();
            //if health is not equal to null
            if (health!= null)
            {
                print("Work02");
                //Takes damage
                health.TakeDamage(damage);
            }
        }
    }
}
