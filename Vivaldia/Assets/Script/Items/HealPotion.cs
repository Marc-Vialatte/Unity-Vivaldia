using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealPotion : MonoBehaviour
{
    //Script qui permet de récuperer un potion et de rendre 1 PV si le joueur passe dessus
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<PlayerInventory>().AddLife(1);
            Destroy(gameObject);
        }
    }
}
