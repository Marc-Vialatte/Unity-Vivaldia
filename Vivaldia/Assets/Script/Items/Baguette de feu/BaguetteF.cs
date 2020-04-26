using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaguetteF : MonoBehaviour
{
    //Script qui permet de récuperer la Bagette de Feu 

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<PlayerInventory>().HaveBaguetteFeu = true; // On envoie la valeur "true" pour dire qu'il a la baguette de feu
            Destroy(gameObject); //On détruit l'objet
        }
    }
}
