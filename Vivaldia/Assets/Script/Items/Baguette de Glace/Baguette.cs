using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Baguette : MonoBehaviour
{
    //Script qui permet de récuperer la Bagette de de Glace
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Si le joueur passe sur la baguette alors on la détruit de la scène et on récupère alors la baguette
        if(collision.tag == "Player")
        {
            collision.GetComponent<PlayerInventory>().HaveBaguetteEau = true; // On envoie la valeur "true" pour dire qu'il a la baguette d'eau
            Destroy(gameObject); //On détruit l'objet
        }
    }
}
