using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EauGlace : MonoBehaviour
{
    //Script qui permet la création d'un bloc de galce
    GameObject Player;
    public Sprite Eau;//Affectation d'un sprite pour faire afficher de l'eau
    public Sprite Glace;//Affectation d'un sprite pour faire afficher de la glace
    SpriteRenderer spriteRDR;
  
    void Start()
    {
        //Initialisation
        spriteRDR = gameObject.GetComponent<SpriteRenderer>();
        spriteRDR.sprite = Eau;
        Player = GameObject.FindGameObjectWithTag("Player");
        
    }

    void OnMouseDown()
    {
        //Si le joueur a la baguette enmain est qu'il clic sur un bloc d'eau on transforme alors l'eau en glace
        //et son sprite est remplacé par de la glace
        if (Player.GetComponent<PlayerInventory>().HaveBaguetteEau && Player.GetComponent<PlayerController>().SelectBaguetteEau)
        {
            print("IsTrigger" + this.gameObject.name);
            this.gameObject.GetComponent<Collider2D>().isTrigger = true;
            spriteRDR.sprite = Glace;
        }
    }
}
