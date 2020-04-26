using System.Collections;
using System.Collections.Generic;
using UnityEngine;



//CF DallesScriptCarre


public class DallesScriptCercle : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (collision.GetComponent<PlayerInventory>().ordredalle == 1)
            {
                collision.GetComponent<PlayerInventory>().ordredalle = 0 ;
            }
            else
            {
                collision.GetComponent<PlayerInventory>().ordredalle = 3;
            }
            print("Ordre Dalle: " + collision.GetComponent<PlayerInventory>().ordredalle);
        }
    }
}
