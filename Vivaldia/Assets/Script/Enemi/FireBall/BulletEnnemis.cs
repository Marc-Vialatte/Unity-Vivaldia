using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnnemis : MonoBehaviour //Script du l'utilité de l'objet tiré
{
    int rlife = 1; //nombre de vie a enlevé

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")  //Si l'objet rentre en collision avec le joueur
            collision.GetComponent<PlayerInventory>().RemoveLife(rlife); //On enlève ici 1 PV au joueur
        if (collision.tag == "Player" || collision.tag == "Ground") //Si l'objet rentre en collision avec le joueur ou un Objet avec le tag "Ground"
        {
            Destroy(gameObject, 0); //Cette Objet ce détruit avec effet immédiat (temps 0s)
        }
    }
}
