using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Fonction qui permet de ne pas perdre les caractéritique du joueur lorsqu'il change de scène
public class DontDestroyOnload : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }
}
