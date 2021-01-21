using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealtScriptEnnemis : MonoBehaviour {
    public int hp;//Nombre de point de vie
    public bool isEnemy = true;//Si c'est un ennemis
    public bool IsBoss;

    void OnTriggerEnter2D(Collider2D collider)
    {
        /*ShotScript shot = collider.gameObject.GetComponent<ShotScript>();
        if (shot != null)
        {
            // Tir allié
            if (shot.isEnemyShot != isEnemy)
            {
                hp -= shot.damage;
                Destroy(shot.gameObject);

                if (hp <= 0)
                {
                    Destroy(gameObject);
                }
            }
        }*/
    }

    public void Removelife(int nb)//Fonction pour lui enlevé un nombre de point d vie passer en paramètre
    {
        hp -= nb; // c'est Point de vie moins le nombre passer en paramètre
    }

    private void Update()
    {
        if(hp <= 0)//Si l'objet n'a plus de vie
        {
            Destroy(gameObject); //Alors il est détruit
        }
    }
}
