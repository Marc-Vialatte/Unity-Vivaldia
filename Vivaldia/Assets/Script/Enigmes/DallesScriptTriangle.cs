using System.Collections;
using System.Collections.Generic;
using UnityEngine;



//CF DallesScriptCarre


public class DallesScriptTriangle : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (collision.GetComponent<PlayerInventory>().ordredalle == 2)
            {
                collision.GetComponent<PlayerInventory>().ordredalle = 1;
            }
            else
            {
                collision.GetComponent<PlayerInventory>().ordredalle = 3;
            }
            print("Ordre Dalle: " + collision.GetComponent<PlayerInventory>().ordredalle);
        }
    }
}
