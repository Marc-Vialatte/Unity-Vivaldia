using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DallesScriptCarre : MonoBehaviour
{
    //Si le joueur entre dans le collider de la dalle
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Vérifiaction du tag
        if (collision.tag=="Player")
        {
            //va chercher le nombre ordredalle dans le script player invertory, si le joueur passe sur cette dalle en premier alors le nombre diminue
            //Sinon il repasse a trois, le but de ces scripts et de faire baisser a 0 l'orde dalle pour pouvoir valider l'énigme et ainsi récuperer la
            //Baguette
            if (collision.GetComponent<PlayerInventory>().ordredalle == 3)
            {
                collision.GetComponent<PlayerInventory>().ordredalle = 2;
            }
            else
            {
                collision.GetComponent<PlayerInventory>().ordredalle = 3;
            }
            print("Ordre Dalle: " + collision.GetComponent<PlayerInventory>().ordredalle);
        }
    }
}
