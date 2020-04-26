using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public bool DoAttack = false;
    public int Degat;
    float timer = 0.9f;

    /*private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")// && CanAttack)
        {
            DoAttack = true;
            collision.GetComponent<PlayerInventory>().RemoveLife(Degat);
        }
    }*/
    private void OnTriggerStay2D(Collider2D collision)
    {
        timer -= Time.deltaTime; //On enlève a la variable timer le temps écoulé
        if (collision.tag == "Player" && timer <=0)//Si le joueur sort il fait l'attaque
        {
            DoAttack = true; 
            collision.GetComponent<PlayerInventory>().RemoveLife(Degat); // On enlève au joueur les Degat passer en paramètre
        }

        if (timer <= 0)//On réinitialise la variable timer
        {
            timer = 0.9f;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")//Si le joueur sort il ne fait plus l'attaque
        {
            DoAttack = false;
        }
    }
}
