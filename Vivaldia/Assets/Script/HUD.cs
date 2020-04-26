using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{

    public Sprite[] HeartSprites;
    public Image HeartUI;
    public Image HaveBaguetteEau;
    public Image HaveBaguetteFeu;
    public Image Sword;
    public Image HaveShield;
    public Image SelectBaguetteEau;
    public Image SelectBaguetteFeu;
    public Image SelectSword;
    public Image SelectShield;

    PlayerInventory playerI;
    PlayerController playerC;
    void Start()
    {
        //playerI = GameObject.Find("playerI").GetComponent<playerIInventory>().life;
    }

    void Update()
    {
        playerI = GameObject.FindWithTag("Player").GetComponent<PlayerInventory>();
        playerC = GameObject.FindWithTag("Player").GetComponent<PlayerController>();

        //Affichage des 5 coeurs mais le joueur a 10 point de vie pour plus de liberté sur les dégat reçu
        int life = playerI.life / 2;
        if (playerI.life >= 0 && playerI.life <= 10)
            HeartUI.sprite = HeartSprites[life];//le sprite a la position life est affiché (tableau de sprite)

        if (playerI.life < 0) //Si un ennemis fait trop de dégat alors sa risque de sortir du tableau
            HeartUI.sprite = HeartSprites[0];

        Sword.enabled = true;
        HaveShield.enabled = false;
        HaveBaguetteEau.enabled = false;
        HaveBaguetteFeu.enabled = false;
        SelectBaguetteEau.enabled = false;
        SelectBaguetteFeu.enabled = false;
        SelectShield.enabled = false;

        if (playerI.HaveBaguetteEau) // Si on a la baguette alors on affiche l'image de la baguette
            HaveBaguetteEau.enabled = true;
        if (playerI.HaveBaguetteFeu) // Si on a la baguette alors on affiche l'image de la baguette
            HaveBaguetteFeu.enabled = true;
        if (playerI.HaveShield) // Si on a le bouclier alors on affiche l'image du bouclier
            HaveShield.enabled = true;

        if (playerC.SelectBaguetteEau && playerI.HaveBaguetteEau) //Si on a la baguette et qu'on la s'éléctionne alors on affiche l'image de séléction
        {
            SelectBaguetteEau.enabled = true;
            SelectBaguetteFeu.enabled = false;
            SelectSword.enabled = false;
            SelectShield.enabled = false;
        }
        if (playerC.SelectBaguetteFeu && playerI.HaveBaguetteFeu) //Si on a la baguette et qu'on la s'éléctionne alors on affiche l'image de séléction
        {
            SelectBaguetteFeu.enabled = true;
            SelectBaguetteEau.enabled = false;
            SelectSword.enabled = false;
            SelectShield.enabled = false;
        }
        if (playerC.SelectSword)// Si on séléctionne l'épée alors on affiche l'image de séléction
        {
            SelectSword.enabled = true;
            SelectBaguetteEau.enabled = false;
            SelectBaguetteFeu.enabled = false;
            SelectShield.enabled = false;
        }
        if (playerC.SelectShield)// Si on séléctionne le bouclier alors on affiche l'image de séléction
        {
            SelectShield.enabled = true;
            SelectBaguetteEau.enabled = false;
            SelectBaguetteFeu.enabled = false;
            SelectSword.enabled = false;
        }

    }
}