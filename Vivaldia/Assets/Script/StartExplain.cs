using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartExplain : MonoBehaviour
{
    //Canvas d'éxplication de départ
    public GameObject Page1;
    public GameObject Page2;
    public GameObject Page3;
    public GameObject Page4;
    PlayerInventory playerI;

    private void Start() //On affiche la 1er page et on désactive les autres
    {
        playerI = GameObject.FindWithTag("Player").GetComponent<PlayerInventory>();
        playerI.HaveBaguetteEau = false;
        playerI.HaveBaguetteFeu = false;
        playerI.HaveShield = false;
        playerI.life = 10;
        playerI.nbBomb = 0;
        playerI.ordredalle = 3;
        playerI.AnimPlayed = false;
        Page1.SetActive(true);
        Page2.SetActive(false);
        Page3.SetActive(false);
        Page4.SetActive(false);
    }

    //Les fonctions pour l'appui des boutons
    public void Page1a2() //On désactive la page 1 et on affiche la page 2
    {
        Page1.SetActive(false);
        Page2.SetActive(true);
    }
    public void Page2a3() //On désactive la page 2 et on affiche la page 3
    {
        Page2.SetActive(false);
        Page3.SetActive(true);
    }
    public void Page3a4() //On désactive la page 3 et on affiche la page 4
    {
        Page3.SetActive(false);
        Page4.SetActive(true);
    }
    public void Page4aR() //On désactive la page 4
    {
        Page4.SetActive(false);
    }
}
