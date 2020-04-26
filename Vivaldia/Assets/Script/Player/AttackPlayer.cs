using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPlayer : MonoBehaviour
{
    
    public bool PlayerAttack = false;//Création d'un booléen pour faire attaquer le joueur
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Si un ennims rentre dans le collider et que le joueur attack alors l'ennemis perd de la vie
        if (collision.tag == "Ennemis" && PlayerAttack)
        {
            collision.GetComponent<HealtScriptEnnemis>().Removelife(1);
        }
    }
    //Si un ennims reste dans le collider et que le joueur attack alors l'ennemis perd de la vie
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Ennemis" && PlayerAttack)
        {
            collision.GetComponent<HealtScriptEnnemis>().Removelife(1);
        }
    }
}
