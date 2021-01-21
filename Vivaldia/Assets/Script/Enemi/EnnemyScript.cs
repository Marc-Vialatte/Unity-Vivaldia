using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemyScript : MonoBehaviour {
    private WeaponScriptEnnemis weapon;

    void Awake()
    {
        // Récupération de l'arme au démarrage
        weapon = GetComponent<WeaponScriptEnnemis>(); //Onrécupère le script
    }

    void Update()
    {
        // Tir auto
        if (weapon != null && weapon.CanAttack1) //Si on peut récupéré le script et qu'il ne fait pas d'attaque alors
        {
            weapon.Attack1(true); // On initialise la variable Attack1 a vrai dans le script weapon
        }
    }
}
