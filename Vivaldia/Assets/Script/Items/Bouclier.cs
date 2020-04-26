using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bouclier : MonoBehaviour
{
    //Script qui permet de récuperer le bouclier
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<PlayerInventory>().HaveShield = true; // On envoie la valeur "true" pour dire qu'il a le bouclier
            Destroy(gameObject); //On détruit l'objet
        }
    }
}
