using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodeBomb : MonoBehaviour //C'est le script d'une bombe qui explose utilisé pour le Boss
{
    public float timerstart = 0.8f;
    private void Update()
    {
        timerstart -= Time.deltaTime; //timerstart est un timer pour savoir quand sa commence
        Destroy(gameObject, 1.1f);
    }
    private void OnTriggerEnter2D(Collider2D collision) // Si le joueur rentre et que le timer est passer alors on enlève des point de vie au joueur
    {
        if (timerstart <= 0)
        {
            if (collision.tag == "Player")
            {
                collision.GetComponent<PlayerInventory>().RemoveLife(4);
            }
        }
    }
    private void OnTriggerStay2D(Collider2D collision) // Si le joueur est dedans et que le timer est passer alors on enlève des point de vie au joueur
    {
        if (timerstart <= 0)
        {
            if (collision.tag == "Player")
            {
                collision.GetComponent<PlayerInventory>().RemoveLife(4);
            }
        }
    }
}
