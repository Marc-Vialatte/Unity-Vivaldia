using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotScript : MonoBehaviour //L'objet est détruit avec un temps donné (au cas ou il ne rentre pas d'objet qu'il soit quand meme détruit)
{
    public bool isEnemyShot = false; //Si c'est un tire ennemis
    public int timeLifeBullet = 5; // Son Temps de vie en seconde

    void Start()
    {
        Destroy(gameObject, timeLifeBullet); //On détruit l'objet qui contient ce script avec un temps donné
    }
}
